using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using SVZText = SonicVsZonikGameText;
using SVZStats = SonicVsZonikVitalStatistics;
using SVZLogic = SonicVsZonikSectionLogic;

public class SonicVsZonikSectionLogic : MonoBehaviour
{
	private int index;
	private int previousIndex;
	private int[] previousChoices;
	public static int zoneChipIndex;
	public static bool gameOver;
	private int[] gameOverSections = new int[] {41, 54, 231, 281};
	private int[] boomSections = new int[] {31, 60, 109, 140, 146, 160, 211, 268};
	
	public static int mackCounter;
	public static bool mackDoomed0;
	public static bool mackDoomed1;
	public static bool mackDoomed2;
	public static int mackDoomCounter;
	public static bool justLeftMackDoom;
	public static bool boatSunk;
	public static bool pinballSecondChanceUsed;
	public static string fakTorEeeLocation;
	public static bool bottleBankDestroyed;
	public static bool spineFieldsDestroyed;
	public static string skyChaseMethod;
	public static bool tailsInSpecialZone;
	public static bool zonikCrashLanded;
	public static HashSet<string> specialZoneDoors = new HashSet<string>();
	
	// All sections where the energy gun is fired
	// (and 10 rings are expended):
	// 121 = Rexon
	// 190 = Zonik's skimmer
	// 230 = Giant Badnik
	// 271 = Zonik
	// 289 = Robotnik's hover ship
	private int[] energyGunFired = new int[] {121, 190, 230, 271, 289};
	
	[SerializeField] private SonicVsZonikMusicManager MusicManager;
	[SerializeField] private AudioSource SFXAudioSource;
	[SerializeField] private SonicVsZonikJingleManager JingleManager;
	
	[SerializeField] private AudioClip Ring;
	[SerializeField] private AudioClip LoseRings;
	[SerializeField] private AudioClip ItemSound;
	[SerializeField] private AudioClip LoseLife;
	[SerializeField] private AudioClip Explosion;
	[SerializeField] private AudioClip MackSiren;
	[SerializeField] private AudioClip EnterZoneChipArea;
	[SerializeField] private AudioClip LeaveZoneChipArea;
	
	public class SectionSave
	{
		// Section number
		public int section = 0;
		
		// Sonic's Vital Statistics
		public int speed = 0;
		public int agility = 0;
		public int strength = 0;
		public int coolness = 0;
		public int quickWits = 0;
		public int goodLooks = 0;
		
		// Inventory
		public int lives = 0;
		public int rings = 0;
		public int credits = 0;
		public int points = 0;
		public HashSet<string> SonicsStuff = new HashSet<string>();
		
		// Global story flags
		public int mackCounter = 0;
		public bool mackDoomed0 = false;
		public bool mackDoomed1 = false;
		public bool mackDoomed2 = false;
		public int mackDoomCounter = 0;
		public bool justLeftMackDoom = false;
		public bool boatSunk = false;
		public bool pinballSecondChanceUsed = false;
		public string fakTorEeeLocation = "Bottle Bank";
		public bool bottleBankDestroyed = false;
		public bool spineFieldsDestroyed = false;
		public string skyChaseMethod = "Hovering";
		public bool tailsInSpecialZone = false;
		public HashSet<string> specialZoneDoors = new HashSet<string>();
		public bool zonikCrashLanded = false;
		
	}
	
	public static Stack<SectionSave> sectionHistory = new Stack<SectionSave>();
	
	void Start() {
		previousIndex = 1;
		previousChoices = new int[0] {};
		gameOver = false;
		
		mackCounter = 0;
		mackDoomed0 = false;
		mackDoomed1 = false;
		mackDoomed2 = false;
		mackDoomCounter = 0;
		boatSunk = false;
		pinballSecondChanceUsed = false;
		fakTorEeeLocation = "Bottle Bank";
		bottleBankDestroyed = false;
		spineFieldsDestroyed = false;
		skyChaseMethod = "Hovering";
		specialZoneDoors = new HashSet<string>();
		tailsInSpecialZone = false;
		zonikCrashLanded = false;
	}
	
	private void ForceToIndex(int newIndex) {
		SVZText.sectionLibrary[index].choices = new int[1] {newIndex};
	}
	
	private void BookmarkIndex() {
		previousIndex = index;
		previousChoices = SVZText.sectionLibrary[index].choices;
	}
	
	private void GoToPreviousIndex() {
		SVZText.sectionLibrary[index].choices = new int[1] {previousIndex};
		SVZText.sectionLibrary[previousIndex].choices = previousChoices;
		previousIndex = 1;
		previousChoices = new int[0] {};
	}
	
    public void SectionLogic() {
		// Static value of index
		index = SonicVsZonikGame.index;
		
		UpdateInventory();
		ItemLogic();
		EnergyGunLogic();
		MackLogic();
		BoatLogic();
		PinballLogic();
		AsteronLogic();
		MysticCaveLogic();
		//FakTorEeeLogic();
		SkyChaseLogic();
		ZoneChipLogic();
		OptionsLogic();
		BoomLogic();
		
		if (gameOverSections.Contains(index)) {
			gameOver = true;
		}
	}
	
	public void UpdateInventory() {
		// Add rings, credits, and points
		if (!SVZText.sectionLibrary[index].inHistory) {
			SVZStats.rings += SVZText.sectionLibrary[index].rings;
			SVZStats.credits += SVZText.sectionLibrary[index].credits;
			SVZStats.points += SVZText.sectionLibrary[index].points;
			// Manage audio for earning rings and losing rings/credits
			bool ringCost = false;
			if (index == 176 || index == 127 || index == 221) {
				ringCost = true;
			}
			foreach (int n in energyGunFired)
			{
				if (n == index)
				{
					ringCost = true;
					break;
				}
			}
			
			if (SVZText.sectionLibrary[index].rings > 0) {
				SFXAudioSource.clip = Ring;
				SFXAudioSource.Play();
			}
			else if ((SVZText.sectionLibrary[index].rings < 0
				|| SVZText.sectionLibrary[index].credits < 0)
				&& !ringCost) {
				SFXAudioSource.clip = LoseRings;
				SFXAudioSource.Play();
			}
			// Manage audio for earning points
			if (SVZText.sectionLibrary[index].points > 0) {
				if (SVZStats.points >= SonicVsZonikGame.maxPoints) {
					JingleManager.PlayJingle("Spinball100Points");
				}
				else {
					JingleManager.PlayJingle("SpinballPoints");
				}
			}
		}
		
		// Add items to Sonic's Stuff
		Debug.Log("index = " + index);
		if (SVZText.sectionLibrary[index].items != null
			&& SVZText.sectionLibrary[index].items.Length > 0) {
			if (index != 1) {
				SFXAudioSource.clip = ItemSound;
				SFXAudioSource.Play();
			}
			foreach(string item in SVZText.sectionLibrary[index].items) {
				SVZStats.SonicsStuff.Add(item);
			}
		}
		if (index == 234 || (OptionsGlobal.options["fixWhiffyLiquid"] && index == 180)) {
			SVZStats.SonicsStuff.Add("Chaos Emerald");
			JingleManager.PlayJingle("ChaosEmerald");
		}
		
		// Update Vital Statistics (if applicable)
		ChangeVitalStatistics();
	}
	
	public void AddToHistory() {
		SectionSave mostRecentSection = new SectionSave {
			section = index,
			
			speed = SVZStats.abilities["Speed"],
			agility = SVZStats.abilities["Agility"],
			strength = SVZStats.abilities["Strength"],
			coolness = SVZStats.abilities["Coolness"],
			quickWits = SVZStats.abilities["Quick Wits"],
			goodLooks = SVZStats.abilities["Good Looks"],
			
			lives = SVZStats.lives,
			rings = SVZStats.rings,
			credits = SVZStats.credits,
			points = SVZStats.points,
			
			mackCounter = SVZLogic.mackCounter,
			mackDoomed0 = SVZLogic.mackDoomed0,
			mackDoomed1 = SVZLogic.mackDoomed1,
			mackDoomed2 = SVZLogic.mackDoomed2,
			mackDoomCounter = SVZLogic.mackDoomCounter,
			justLeftMackDoom = SVZLogic.justLeftMackDoom,
			boatSunk = SVZLogic.boatSunk,
			pinballSecondChanceUsed = SVZLogic.pinballSecondChanceUsed,
			fakTorEeeLocation = SVZLogic.fakTorEeeLocation,
			bottleBankDestroyed = SVZLogic.bottleBankDestroyed,
			spineFieldsDestroyed = SVZLogic.spineFieldsDestroyed,
			skyChaseMethod = SVZLogic.skyChaseMethod,
			tailsInSpecialZone = SVZLogic.tailsInSpecialZone,
			zonikCrashLanded = SVZLogic.zonikCrashLanded
		};
		mostRecentSection.SonicsStuff.Clear();
		foreach (string item in SVZStats.SonicsStuff) {
			mostRecentSection.SonicsStuff.Add(item);
		}
		mostRecentSection.specialZoneDoors.Clear();
		foreach (string door in specialZoneDoors) {
			mostRecentSection.specialZoneDoors.Add(door);
		}
		sectionHistory.Push(mostRecentSection);
	}
	
	public void RemoveFromHistory() {
		sectionHistory.Pop();
		
		// Update values to match the section visited by the Back button			
		SVZStats.abilities["Speed"] = sectionHistory.Peek().speed;
		SVZStats.abilities["Agility"] = sectionHistory.Peek().agility;
		SVZStats.abilities["Strength"] = sectionHistory.Peek().strength;
		SVZStats.abilities["Coolness"] = sectionHistory.Peek().coolness;
		SVZStats.abilities["Quick Wits"] = sectionHistory.Peek().quickWits;
		SVZStats.abilities["Good Looks"] = sectionHistory.Peek().goodLooks;
			
		SVZStats.lives = sectionHistory.Peek().lives;
		SVZStats.rings = sectionHistory.Peek().rings;
		SVZStats.credits = sectionHistory.Peek().credits;
		SVZStats.points = sectionHistory.Peek().points;
		
		SVZStats.SonicsStuff.Clear();
		foreach (string item in sectionHistory.Peek().SonicsStuff) {
			SVZStats.SonicsStuff.Add(item);
		}
		specialZoneDoors.Clear();
		foreach (string door in sectionHistory.Peek().specialZoneDoors) {
			specialZoneDoors.Add(door);
		}
		
		mackCounter = sectionHistory.Peek().mackCounter;
		mackDoomed0 = sectionHistory.Peek().mackDoomed0;
		mackDoomed1 = sectionHistory.Peek().mackDoomed1;
		mackDoomed2 = sectionHistory.Peek().mackDoomed2;
		mackDoomCounter = sectionHistory.Peek().mackDoomCounter;
		justLeftMackDoom = sectionHistory.Peek().justLeftMackDoom;
		boatSunk = sectionHistory.Peek().boatSunk;
		pinballSecondChanceUsed = sectionHistory.Peek().pinballSecondChanceUsed;
		fakTorEeeLocation = sectionHistory.Peek().fakTorEeeLocation;
		bottleBankDestroyed = sectionHistory.Peek().bottleBankDestroyed;
		spineFieldsDestroyed = sectionHistory.Peek().spineFieldsDestroyed;
		skyChaseMethod = sectionHistory.Peek().skyChaseMethod;
		tailsInSpecialZone = sectionHistory.Peek().tailsInSpecialZone;
		zonikCrashLanded = sectionHistory.Peek().zonikCrashLanded;
		
		int backIndex = sectionHistory.Peek().section;
		SonicVsZonikGame.ChangeIndex(backIndex.ToString());
	}
	
	private void ChangeVitalStatistics() {
		if (index == 140) {
			if (SVZStats.abilities["Coolness"] < 99) {
				SVZStats.abilities["Coolness"]++;
			}
		}
		else if (index == 34) {
			if (SVZStats.abilities["Good Looks"] > 0) {
				SVZStats.abilities["Good Looks"]--;
			}
		}
		else if (index == 238) {
			if (SVZStats.abilities["Good Looks"] > 0) {
				SVZStats.abilities["Good Looks"]--;
			}
		}
		else if (index == 33) {
			if (SVZStats.abilities["Coolness"] < 99) {
				SVZStats.abilities["Coolness"]++;
			}
		}
		else if (index == 60) {
			if (SVZStats.rings >= 10) {
				EarnRings(-10);
			}
			else if (SVZStats.abilities["Strength"] > 0) {
				SVZStats.abilities["Strength"]--;
			}
		}
	}
	
	public void EarnRings(int rings) {
		if (rings >= 0) {
			SFXAudioSource.clip = Ring;
			SFXAudioSource.Play();
		}
		else {
			SFXAudioSource.clip = LoseRings;
			SFXAudioSource.Play();
		}
		SVZStats.rings += rings;
	}
	
	public void ObtainItem(string item) {
		SFXAudioSource.clip = ItemSound;
		SFXAudioSource.Play();
		SVZStats.SonicsStuff.Add(item);
	}
	
	public void GetHit() {
		if (SVZStats.rings > 0) {
			SFXAudioSource.clip = LoseRings;
			SFXAudioSource.Play();
			SVZStats.rings = 0;
		}
		else {
			SFXAudioSource.clip = LoseLife;
			SFXAudioSource.Play();
			SVZStats.lives--;
			if (SVZStats.lives == 0) {
				MusicManager.PlaySongForSection(54);
				gameOver = true;
			}
		}
	}
	
	public void EndOfDiceRollLogic(int diceIndex, bool rollSuccess, int sum, bool enemyDefeated) {
		// Faulty bridge at Green Hill
		if ((diceIndex == 117 || diceIndex == 173) && !rollSuccess) {
			GetHit();
		}
		// Missed the lever at Green Hill
		if (diceIndex == 162 && !rollSuccess) {
			GetHit();
		}
		// Dice roll fail at Sky Chase
		if (diceIndex == 165 && !rollSuccess) {
			MusicManager.PlaySongForSection(54);
			gameOver = true;
		}
		// Casino Night fruit machine payout
		if (diceIndex == 84) {
			EarnRings(sum);
		}
		// Badniks that drop rings upon being destroyed
		if (diceIndex == 57 && enemyDefeated) {
			EarnRings(10);
		}
		if (diceIndex == 275 && enemyDefeated) {
			EarnRings(20);
		}
		// Lose rings if hit by an Asteron missile
		if (diceIndex == 211 && !rollSuccess) {
			GetHit();
		}
		// Obtain the sky net after defeating the Special Badnik
		if (diceIndex == 147 && enemyDefeated) {
			ObtainItem("Sky net");
		}
	}
	
	private void ItemLogic() {
		// Torch
		if (index == 8) {
			if (SVZStats.SonicsStuff.Contains("Torch")) {
				ForceToIndex(79);
			}
			else {
				ForceToIndex(115);
			}
		}
		if (index == 15 || index == 118) {
			if (SVZStats.SonicsStuff.Contains("Torch")) {
				SVZText.sectionLibrary[index].diceSection = false;
			}
			else {
				SVZText.sectionLibrary[index].diceSection = true;
			}
		}
		
		// Tweezers
		if (index == 75) {
			if (!SVZStats.SonicsStuff.Contains("Tweezers")) {
				ForceToIndex(140);
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[2] {140, 219};
			}
		}
		
		// Whiffy liquid
		if (index == 180 && SVZStats.SonicsStuff.Contains("Bottle of Whiffy liquid")) {
			SVZStats.SonicsStuff.Remove("Bottle of Whiffy liquid");
		}
		
		// Tube of glue and energy bomb
		bool canUseGlue = (SVZStats.SonicsStuff.Contains("Tube of glue"));
		bool canUseEnergyBomb = (SVZStats.SonicsStuff.Contains("Energy bomb"));
		
		if (index == 248) {
			if (canUseGlue && canUseEnergyBomb) {
				SVZText.sectionLibrary[index].choices = new int[3] {134, 212, 197};
			}
			else if (canUseGlue && !canUseEnergyBomb) {
				SVZText.sectionLibrary[index].choices = new int[2] {134, 212};
			}
			else if (!canUseGlue && canUseEnergyBomb) {
				SVZText.sectionLibrary[index].choices = new int[2] {134, 197};
			}
			if (!canUseGlue && !canUseEnergyBomb) {
				SVZText.sectionLibrary[index].choices = new int[1] {134};
			}
		}
		if (index == 268) {
			if (canUseGlue) {
				SVZText.sectionLibrary[index].choices = new int[4] {14, 230, 107, 53};
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[3] {14, 230, 53};
			}
		}
		if ((index == 107 || index == 212) && canUseGlue) {
			SVZStats.SonicsStuff.Remove("Tube of glue");
		}
		if (index == 197 && canUseEnergyBomb) {
			SVZStats.SonicsStuff.Remove("Energy bomb");
		}
		
		// Using the sky net
		bool canUseSkyNet = (SVZStats.SonicsStuff.Contains("Sky net"));
		if (index == 87 && canUseSkyNet) {
			SVZStats.SonicsStuff.Remove("Sky net");
		}
		
		// Casino Night fruit machine requires 1 ring per play
		if (index == 171) {
			SVZStats.rings--;
		}
		if (index == 226) {
			if (SVZStats.rings > 0) {
				SVZText.sectionLibrary[index].choices = new int[2] {171, 66};
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[1] {66};
			}
		}
	}
	
	private void EnergyGunLogic() {
		bool canUseEnergyGun = (SVZStats.rings >= 10 && SVZStats.SonicsStuff.Contains("Energy gun"));
		bool canUseGlue = (SVZStats.SonicsStuff.Contains("Tube of glue"));
		
		// Special logic for sections 158 and 263
		// (Energy gun AND sky net)
		if (index == 158) {
			bool canUseSkyNet = SVZStats.SonicsStuff.Contains("Sky net");
			if (canUseSkyNet && canUseEnergyGun) {
				SVZText.sectionLibrary[index].choices = new int[3] {161, 87, 190};
			}
			else if (!canUseSkyNet && canUseEnergyGun) {
				SVZText.sectionLibrary[index].choices = new int[2] {161, 190};
			}
			else if (canUseSkyNet && !canUseEnergyGun) {
				SVZText.sectionLibrary[index].choices = new int[2] {161, 87};
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[1] {161};
			}
			return;
		}
		else if (index == 263) {
			if (canUseEnergyGun) {
				SVZText.sectionLibrary[index].choicesDiceLose = new int[2] {220, 121};
			}
			else {
				SVZText.sectionLibrary[index].choicesDiceLose = new int[1] {220};
			}
			return;
		}
		
		int[] choicesWithEnergyGun = new int[0] {};
		int[] choicesWithoutEnergyGun = new int[0] {};
		
		if (index == 14) {
			choicesWithEnergyGun = new int[4] {230, 107, 53, 249};
			choicesWithoutEnergyGun = new int[3] {107, 53, 249};
		}
		else if (index == 43) {
			choicesWithEnergyGun = new int[2] {289, 242};
			choicesWithoutEnergyGun = new int[1] {242};
		}
		else if (index == 107) {
			choicesWithEnergyGun = new int[3] {14, 230, 53};
			choicesWithoutEnergyGun = new int[2] {14, 53};
		}
		else if (index == 169) {
			choicesWithEnergyGun = new int[3] {271, 31, 180};
			choicesWithoutEnergyGun = new int[2] {31, 180};
		}
		
		if (choicesWithEnergyGun != null && choicesWithEnergyGun.Length > 0
			&& choicesWithoutEnergyGun != null && choicesWithoutEnergyGun.Length > 0) {
			if (canUseEnergyGun) {
				SVZText.sectionLibrary[index].choices = choicesWithEnergyGun;
			}
			else {
				SVZText.sectionLibrary[index].choices = choicesWithoutEnergyGun;
			}
		}
	}
	
	private void MackLogic() {
		if ((index == 188 || index == 239) && mackDoomed0 == false) {
			SFXAudioSource.clip = MackSiren;
			SFXAudioSource.Play();
			mackDoomed0 = true;
		}
		
		if (SVZText.sectionLibrary[index].mackSection) {
			// Increment counter for Mack sections
			mackCounter++;
			if (!mackDoomed1 && mackCounter == 21) {
				SFXAudioSource.clip = MackSiren;
				SFXAudioSource.Play();
				BookmarkIndex();
				ForceToIndex(288);
			}
			// 1st stage of Mack doom: Remove 1 ring for every section
			else if (mackDoomed1 && !mackDoomed2 && !justLeftMackDoom) {
				SFXAudioSource.clip = Ring;
				SFXAudioSource.Play();
				if (SVZStats.rings == 0) {
					SFXAudioSource.clip = MackSiren;
					SFXAudioSource.Play();
					BookmarkIndex();
					ForceToIndex(25);
				}
				else {
					SVZStats.rings--;
				}
			}
			// 2nd stage of Mack doom: Remove 1 life for every 5 sections until Game Over
			else if (mackDoomed2 && !justLeftMackDoom) {
				SVZText.sectionLibrary[index].rings = 0;
				mackDoomCounter++;
				if (mackDoomCounter == 5) {
					SFXAudioSource.clip = LoseLife;
					SFXAudioSource.Play();
					mackDoomCounter = 0;
					SVZStats.lives--;
					if (SVZStats.lives == 0) {
						ForceToIndex(231);
					}
				}
			}
			
			if (justLeftMackDoom) {
				justLeftMackDoom = false;
			}
		}
		else if (index == 288) {
			mackDoomed1 = true;
			justLeftMackDoom = true;
			GoToPreviousIndex();
		}
		else if (index == 25) {
			mackDoomed2 = true;
			justLeftMackDoom = true;
			GoToPreviousIndex();
		}
	}
	
	private void BoatLogic() {
		if (index == 52) {
			boatSunk = false;
		}
		else if (index == 166) {
			boatSunk = true;
		}
		else if (index == 40) {
			if (!boatSunk) {
				ForceToIndex(137);
			}
			else {
				ForceToIndex(273);
			}
		}
	}
	
	private void PinballLogic() {
		// Choices for Sections 185 and 283 (Lose credits)
		if (index == 185 || index == 283) {
			if (SVZStats.credits == 0 && !pinballSecondChanceUsed) {
				pinballSecondChanceUsed = true;
				ForceToIndex(126);
			}
			else if (SVZStats.credits == 0) {
				ForceToIndex(41);
			}
			else {
				ForceToIndex(124);
			}
		}
	}
	
	
	private void AsteronLogic() {
		if (SVZText.sectionLibrary[index].asteronSection) {
			previousIndex = index;
			SVZText.sectionLibrary[index].diceSection = true;
			SVZText.sectionLibrary[index].diceGoal = 2;
			SVZText.sectionLibrary[index].choicesDiceWin = SVZText.sectionLibrary[index].choices;
			SVZText.sectionLibrary[index].choicesDiceLose = new int[1] {211};
		}
		if (index == 211) {
			SVZText.sectionLibrary[index].choicesDiceWin = new int[1] {previousIndex};
			SVZText.sectionLibrary[index].choicesDiceLose = new int[1] {previousIndex};
		}
	}
	
	private void MysticCaveLogic() {
		if (index == 76) {
			GetHit();
			if (SVZStats.SonicsStuff.Contains("Energy gun")) {
				SVZStats.SonicsStuff.Remove("Energy gun");
			}
			SVZStats.SonicsStuff.Add("Energy gun (broken)");
		}
	}
	
	private void SkyChaseLogic() {
		if (index == 216) {
			skyChaseMethod = "Hovering";
		}
		else if (index == 85) {
			skyChaseMethod = "Tails";
		}
		else if (index == 68) {
			skyChaseMethod = "Sonic";
		}
		
		if (index == 192) {
			if (skyChaseMethod == "Sonic") {
				ForceToIndex(78);
			}
			else if (skyChaseMethod == "Tails") {
				ForceToIndex(170);
			}
			else if (skyChaseMethod == "Hovering") {
				ForceToIndex(51);
			}
		}
		
		if (index == 161) {
			if (skyChaseMethod == "Sonic") {
				ForceToIndex(116);
			}
			else if (skyChaseMethod == "Tails") {
				ForceToIndex(210);
			}
			else if (skyChaseMethod == "Hovering") {
				ForceToIndex(108);
			}
		}
		
		if (index == 136) {
			zonikCrashLanded = true;
		}
		if (index == 90) {
			zonikCrashLanded = false;
		}
		
		if (index == 214) {
			if (!SVZStats.SonicsStuff.Contains("Gloves")) {
				SVZText.sectionLibrary[index].fightSection = false;
				SVZText.sectionLibrary[index].chooseAbility = false;
				ForceToIndex(237);
			}
			else {
				SVZText.sectionLibrary[index].fightSection = true;
				SVZText.sectionLibrary[index].chooseAbility = true;
				SVZText.sectionLibrary[index].choices = new int[0] {};
				if (zonikCrashLanded) {
					SVZText.sectionLibrary[index].enemyList.Peek().fightingScore = 5;
				}
				else {
					SVZText.sectionLibrary[index].enemyList.Peek().fightingScore = 7;
				}
			}
		}
	}
	
	private void ZoneChipLogic() {
		// Always give Sonic the Zone Chip, if the option to do so is enabled
		if (OptionsGlobal.options["alwaysGetZoneChip"]
			&& index == 201 && !SVZStats.SonicsStuff.Contains("Zone Chip")) {
			ObtainItem("Zone Chip");
		}
		
		// Immediately after pressing "Use Zone Chip" button
		if (index == 237) {
			if (SVZStats.rings >= 20 || OptionsGlobal.options["useZoneChipForFree"]) {
				SVZText.sectionLibrary[index].choices = new int[3] {zoneChipIndex, 127, 221};
			}
			else if (SVZStats.rings >= 10) {
				SVZText.sectionLibrary[index].choices = new int[2] {zoneChipIndex, 127};
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[1] {zoneChipIndex};
			}
			
			if (OptionsGlobal.options["useZoneChipForFree"]) {
				SVZText.sectionLibrary[127].rings = 0;
				SVZText.sectionLibrary[221].rings = 0;
			}
			else {
				SVZText.sectionLibrary[127].rings = -10;
				SVZText.sectionLibrary[221].rings = -20;
			}
		}
		
		// After actually using the Zone Chip
		if (index == 127 || index == 221) {
			SFXAudioSource.clip = EnterZoneChipArea;
			SFXAudioSource.Play();
			if (index == 221) {
				tailsInSpecialZone = true;
			}
			else {
				tailsInSpecialZone = false;
			}
			// Sky net: Tails will only help fight the Special Badnik if he's there.
			SVZText.sectionLibrary[147].tailsSection = tailsInSpecialZone;
		}
		
		// Permanently close a door once it is used
		// (unless the option to prevent this is checked).
		if (index == 149) {
			specialZoneDoors.Add("Tweezers");
		}
		else if (index == 290) {
			specialZoneDoors.Add("Sky net");
		}
		else if (index == 252) {
			specialZoneDoors.Add("Gloves");
		}
		else if (index == 245) {
			specialZoneDoors.Add("Energy bomb");
		}
		
		// Tweezers
		if (index == 205) {
			if (tailsInSpecialZone) {
				SVZText.sectionLibrary[index].choices = new int[2] {187, 264};
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[2] {187, 138};
			}
		}
		if (index == 149) {
			if (tailsInSpecialZone) {
				SVZText.sectionLibrary[index].choicesDiceLose = new int[1] {176};
			}
			else {
				SVZText.sectionLibrary[index].choicesDiceLose = new int[1] {50};
			}
		}
		
		// Gloves
		if (index == 178) {
			if (tailsInSpecialZone) {
				ForceToIndex(167);
			}
			else {
				ForceToIndex(232);
			}
		}
		
		// For Section 138, only collect the tweezers if BOTH dice scores are above 6
		// (see DiceRollManager.cs).
		
		// After pressing the red button in any Zone Chip area
		if (index == 187) {
			SFXAudioSource.clip = LeaveZoneChipArea;
			SFXAudioSource.Play();
			ForceToIndex(zoneChipIndex);
		}
	}
	
	private bool doorOpen(string door) {
		return !specialZoneDoors.Contains(door);
	}
	
	private void OptionsLogic() {
		// Choices for section 244 (Easier river escape)
		if (index == 244) {
			if (OptionsGlobal.options["easierRiverEscape"]) {
				SVZText.sectionLibrary[index].text = "BAD NEWS!!! Sonic's worst nightmare comes true! The river is ice cold and already Sonic can feel himself slowly sinking. The cold is severely limiting his aquatic abilities. There's only one thing for it: he calls out and hopes Tails will come to the rescue. Roll the die and add the result to Sonic's Good Looks. If the score is 5 or more, then turn to <b>104</b>. If the score is less than 5, turn to <b>131</b>.";
				SVZText.sectionLibrary[index].diceGoal = 5;
			}
			else {
				SVZText.sectionLibrary[index].text = "BAD NEWS!!! Sonic's worst nightmare comes true! The river is ice cold and already Sonic can feel himself slowly sinking. The cold is severely limiting his aquatic abilities. There's only one thing for it: he calls out and hopes Tails will come to the rescue. Roll the die and add the result to Sonic's Good Looks. If the score is 10 or more, then turn to <b>104</b>. If the score is less than 10, turn to <b>131</b>.";
				SVZText.sectionLibrary[index].diceGoal = 10;
			}
		}
		
		// Choices for Section 26 (Varied treasure)
		if (index == 26) {
			if (OptionsGlobal.options["variedTreasure"]) {
				SVZText.sectionLibrary[index].text = "The sandy path leads into the jungle, running beneath huge palm trees. This is the sort of place that Coconuts would like to hang out in and both of them keep a wary eye on the tree-tops. In fact, they are so intent looking above them that the first either knew of the treasure chest was when Tails walked straight into it with a THUMP!\n\n'Ow!' says Tails, stubbing his paw against the half-buried chest.\n\nSonic looks at the large wooden chest that stands right in the middle of the pathway. 'Now, who would want to put a treasure chest in such an obvious position?'\n\n'Perhaps they dropped it,' says Tails rubbing his paw.\n\n'Or,' says Sonic, 'they, whoever they are, wanted us to find it.'\n\nDo you want Sonic to open the chest and see what's inside it (turn to <b>60</b>), or to leave the chest where it is (turn to <b>80</b>)?";
				SVZText.sectionLibrary[index].choices = new int[2] {60, 80};
			}
			else {
				SVZText.sectionLibrary[index].text = "The sandy path leads into the jungle, running beneath huge palm trees. This is the sort of place that Coconuts would like to hang out in and both of them keep a wary eye on the tree-tops. In fact, they are so intent looking above them that the first either knew of the treasure chest was when Tails walked straight into it with a THUMP!\n\n'Ow!' says Tails, stubbing his paw against the half-buried chest.\n\nSonic looks at the large wooden chest that stands right in the middle of the pathway. 'Now, who would want to put a treasure chest in such an obvious position?'\n\n'Perhaps they dropped it,' says Tails rubbing his paw.\n\n'Or,' says Sonic, 'they, whoever they are, wanted us to find it.'\n\nDo you want Sonic to open the chest and see what's inside it (turn to <b>254</b>), or to leave the chest where it is (turn to <b>80</b>)?";
				SVZText.sectionLibrary[index].choices = new int[2] {254, 80};
			}
		}
		
		// Choices for Section 124 (Pinball spinner)
		else if (index == 124) {
			SVZText.sectionLibrary[index].text = "Sonic and Tails find themselves in the game's central spinner. It looks like a massive fairground roundabout. There are five exits from the spinner back into the game, each of which is spring loaded, so make sure our friends are careful! Both of them have played the game already, but they must remember that Zonik has been here before them, which makes it an altogether more dangerous place to be!\n\nSonic and Tails are now committed to playing the game. There are only two ways out, and one of them is <i>unthinkable</i>! Each time they visit a part of the game, write down the number of the section so that you know they have been there already. They may not use the gold exit until they have scored " + SonicVsZonikGame.maxPoints + " points in the game. Make a note of the points they score. Which exit should they use to leave the game:\n\nThe red exit?\t\t\tTurn to <b>295</b>\nThe yellow exit?\t\t\tTurn to <b>299</b>\nThe blue exit?\t\t\tTurn to <b>229</b>\nThe green exit?\t\t\tTurn to <b>86</b>\nThe gold exit?\t\t\tTurn to <b>45</b>";
			if (SVZStats.points >= SonicVsZonikGame.maxPoints) {
				JingleManager.PlayJingle("SpinballComplete");
				ForceToIndex(45);
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[4] {295, 299, 229, 86};
			}
		}
		
		// Choices for Section 84 (Fruit machine)
		if (index == 84) {
			if (OptionsGlobal.options["fixFruitMachine"]) {
				SVZText.sectionLibrary[index].text = "The fruit machine whirrs into action, while Sonic and Tails stare at it. A WINNER!!! Roll the die twice and add the scores together. This is the number of rings that the fruit machine pays out! Add these to Sonic's Stuff.\n\nIf you want Sonic to play the fruit machine again, turn to <b>171</b>. If you think he should stop wasting time, turn to <b>66</b>.";
				if (SVZStats.rings > 0) {
					SVZText.sectionLibrary[index].choices = new int[2] {171, 66};
				}
				else {
					SVZText.sectionLibrary[index].choices = new int[1] {66};
				}
			}
			else {
				SVZText.sectionLibrary[index].text = "The fruit machine whirrs into action, while Sonic and Tails stare at it. A WINNER!!! Roll the die twice and add the scores together. This is the number of rings that the fruit machine pays out! Add these to Sonic's Stuff.\n\nIf you want Sonic to play the fruit machine again, turn to <b>171</b>. If you think he should stop wasting time, turn to <b>97</b>.";
				if (SVZStats.rings > 0) {
					SVZText.sectionLibrary[index].choices = new int[2] {171, 97};
				}
				else {
					SVZText.sectionLibrary[index].choices = new int[1] {97};
				}
			}
		}
		if (index == 199) {
			if (OptionsGlobal.options["fixFruitMachine"]) {
				SVZText.sectionLibrary[index].text = "The fruit machine whirrs into action while Sonic and Tails are staring at it. Sonic loses. If Sonic plays the fruit machine again, turn to <b>171</b>. If he thinks it's a waste of time, turn to <b>66</b>.";
				if (SVZStats.rings > 0) {
					SVZText.sectionLibrary[index].choices = new int[2] {171, 66};
				}
				else {
					SVZText.sectionLibrary[index].choices = new int[1] {66};
				}
			}
			else {
				SVZText.sectionLibrary[index].text = "The fruit machine whirrs into action while Sonic and Tails are staring at it. Sonic loses. If Sonic plays the fruit machine again, turn to <b>171</b>. If he thinks it's a waste of time, turn to <b>97</b>.";
				if (SVZStats.rings > 0) {
					SVZText.sectionLibrary[index].choices = new int[2] {171, 97};
				}
				else {
					SVZText.sectionLibrary[index].choices = new int[1] {97};
				}
			}
		}
		
		// Choices for Section 82 (Rexon encounter)
		if (index == 82) {
			if (OptionsGlobal.options["fixRexonEncounter"]) {
				SVZText.sectionLibrary[index].text = "Soon, the casino is left far behind and the heli-chopper is cruising high above the peaks and volcanoes of the Hilltop Zone.\n\n\'I'm pleased we don't have to get through that lot on foot,' says Tails.\n\n'Yeah, me too,' agrees Sonic, remembering a previous run-in with a Rexon. Down below, something glints among the hills.\n\n'I wonder what that is,' says Sonic, pointing to the object through the window.\n\n'Well, there's a lever here that says \"Land\", if you want to have a look ...' suggests Tails.\n\nShould Sonic land the heli-chopper (turn to <b>105</b>), or should they ignore whatever it is and carry on towards the Mystic Caves (turn to <b>121</b>)?";
				SVZText.sectionLibrary[index].choices = new int[2] {105, 121};
			}
			else {
				SVZText.sectionLibrary[index].text = "Soon, the casino is left far behind and the heli-chopper is cruising high above the peaks and volcanoes of the Hilltop Zone.\n\n\'I'm pleased we don't have to get through that lot on foot,' says Tails.\n\n'Yeah, me too,' agrees Sonic, remembering a previous run-in with a Rexon. Down below, something glints among the hills.\n\n'I wonder what that is,' says Sonic, pointing to the object through the window.\n\n'Well, there's a lever here that says \"Land\", if you want to have a look ...' suggests Tails.\n\nShould Sonic land the heli-chopper (turn to <b>105</b>), or should they ignore whatever it is and carry on towards the Mystic Caves (turn to <b>67</b>)?";
				SVZText.sectionLibrary[index].choices = new int[2] {105, 67};
			}
		}
		
		// Choices for Section 180 (Whiffy liquid)
		if (index == 180) {
			if (OptionsGlobal.options["fixWhiffyLiquid"]) {
				SVZText.sectionLibrary[index].text = "Sonic pulls out the glass bottle of liquid that Whiffy gave him. He throws it at Zonik. He misses, but the bottle shatters on the ground, splashing Zonik's trainers! For a second or so, nothing happens, then the smell hits them!\n\n'OH, wow man!' is all that Sonic can manage. Tails doesn't even do that well and goes a funny shade of green. As for Zonik, well he starts to puff and jerk like he's got an ice cube down his back. Now he's hopping about on one foot. Then WHOOOSH ... Zonik runs from the cavern like nothing Sonic or Tails have ever seen before, dropping the Chaos Emerald in his haste.\n\nWith a paw firmly clamped over his nose, Sonic walks over to where Zonik had been standing and picks up the emerald. 'Good stuff that,' he says, pointing to the broken bottle. Tails just nods, and thinks he is going to be sick.\n\nTurn to <b>191</b>.";
				ForceToIndex(191);
			}
			else {
				SVZText.sectionLibrary[index].text = "Sonic pulls out the glass bottle of liquid that Whiffy gave him. He throws it at Zonik. He misses, but the bottle shatters on the ground, splashing Zonik's trainers! For a second or so, nothing happens, then the smell hits them!\n\n'OH, wow man!' is all that Sonic can manage. Tails doesn't even do that well and goes a funny shade of green. As for Zonik, well he starts to puff and jerk like he's got an ice cube down his back. Now he's hopping about on one foot. Then WHOOOSH ... Zonik runs from the cavern like nothing Sonic or Tails have ever seen before, dropping the Chaos Emerald in his haste.\n\nWith a paw firmly clamped over his nose, Sonic walks over to where Zonik had been standing and picks up the emerald. 'Good stuff that,' he says, pointing to the broken bottle. Tails just nods, and thinks he is going to be sick.\n\nTurn to <b>76</b>.";
				ForceToIndex(76);
			}
		}
		
		// Choices for Sections 216, 85, 119, and 68 (Sky Chase zone)
		if (index == 216) {
			if (OptionsGlobal.options["fixSkyChase"]) {
				SVZText.sectionLibrary[index].text = "'Come on, Tails, fly after him!' yells Sonic. Tails flies into the air holding out a paw for Sonic to grab. Zonik is already just a dot on the horizon. Our friends will have to move fast to catch him! Turn to <b>227</b>.";
				ForceToIndex(227);
			}
			else {
				SVZText.sectionLibrary[index].text = "'Come on, Tails, fly after him!' yells Sonic. Tails flies into the air holding out a paw for Sonic to grab. Zonik is already just a dot on the horizon. Our friends will have to move fast to catch him! Turn to <b>114</b>.";
				ForceToIndex(114);
			}
		}
		if (index == 85) {
			if (OptionsGlobal.options["fixSkyChase"]) {
				SVZText.sectionLibrary[index].text = "Tails climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, but Tails has the advantage of being a natural flyer. Reaching out, he presses the red button, and the skimmer's engines spring to life. Then he pulls the joystick back and the skimmer flies into the air. Turn to <b>227</b>.";
				ForceToIndex(227);
			}
			else {
				SVZText.sectionLibrary[index].text = "Tails climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, but Tails has the advantage of being a natural flyer. Reaching out, he presses the red button, and the skimmer's engines spring to life. Then he pulls the joystick back and the skimmer flies into the air. Turn to <b>68</b>.";
				ForceToIndex(68);
			}
		}
		if (index == 119) {
			if (OptionsGlobal.options["fixSkyChase"]) {
				SVZText.sectionLibrary[index].text = "Sonic climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, which wasn't really Sonic's style anyway. Roll the die and add the result to Sonic's Quick Wits. If the score is 7 or more, turn to <b>68</b>. If the score is less than 7, turn to <b>114</b>.";
				ForceToIndex(114);
			}
			else {
				SVZText.sectionLibrary[index].text = "Sonic climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, which wasn't really Sonic's style anyway. Roll the die and add the result to Sonic's Quick Wits. If the score is 7 or more, turn to <b>68</b>. If the score is less than 7, turn to <b>227</b>.";
				ForceToIndex(227);
			}
		}
		if (index == 68) {
			if (OptionsGlobal.options["fixSkyChase"]) {
				SVZText.sectionLibrary[index].text = "Sonic reaches out and presses the red button. The skimmer's engines spring to life. Sonic pulls the joystick back and the skimmer flies into the air.\n\n'See, old friend, nothing to this flying. Anyone can do it!' The skimmer judders and wobbles as Sonic struggles to control it.\n\n'Push the stick forward!' shouts Tails. Sonic does it and the skimmer moves off after Zonik. Even Sonic thinks it might have been better to have let Tails fly the skimmer! Turn to <b>227</b>.";
				ForceToIndex(227);
			}
			else {
				SVZText.sectionLibrary[index].text = "Sonic reaches out and presses the red button. The skimmer's engines spring to life. Sonic pulls the joystick back and the skimmer flies into the air.\n\n'See, old friend, nothing to this flying. Anyone can do it!' The skimmer judders and wobbles as Sonic struggles to control it.\n\n'Push the stick forward!' shouts Tails. Sonic does it and the skimmer moves off after Zonik. Even Sonic thinks it might have been better to have let Tails fly the skimmer! Turn to <b>114</b>.";
				ForceToIndex(114);
			}
		}
		
		// Choices for Sections 153 (Cloud skimmer jumps back in time)
		if (index == 153) {
			if (OptionsGlobal.options["fixCloudSkimmer"]) {
				SVZText.sectionLibrary[index].text = "Using the advantage of height, Sonic and Tails swoop down on Zonik's cloud skimmer, passing it with only centimetres to spare! Turn to <b>158</b>.";
				ForceToIndex(158);
			}
			else {
				SVZText.sectionLibrary[index].text = "Using the advantage of height, Sonic and Tails swoop down on Zonik's cloud skimmer, passing it with only centimetres to spare! Turn to <b>268</b>.";
				ForceToIndex(268);
			}
		}
		
		// Choices for Sections 127 and 221 (Entering the Special Zone)
		if (index == 127) {
			if (OptionsGlobal.options["reEnterSpecialZoneDoors"]) {
				SVZText.sectionLibrary[index].text = "The chip starts to flash with red lights, emitting a quiet humming sound. Suddenly, Sonic feels a little dizzy. The next thing he knows, he's standing in a square room. Everything shines with a bright white light. This isn't anywhere Sonic's been before, in fact it doesn't even look like a 'normal' Zone.\n\nThere are four doors, one in each wall. Above each door is a different picture. Sonic must choose carefully. Which door do you think Sonic should go through:\n\nThe one with a pair of tweezers?\t\t\tTurn to <b>149</b>\nThe one with a sky net?\t\t\tTurn to <b>290</b>\nThe one with a pair of gloves?\t\t\tTurn to <b>252</b>\nThe one with an energy bomb?\t\t\tTurn to <b>245</b>";
			}
			else {
				SVZText.sectionLibrary[index].text = "The chip starts to flash with red lights, emitting a quiet humming sound. Suddenly, Sonic feels a little dizzy. The next thing he knows, he's standing in a square room. Everything shines with a bright white light. This isn't anywhere Sonic's been before, in fact it doesn't even look like a 'normal' Zone.\n\nThere are four doors, one in each wall. Above each door is a different picture. Sonic must choose carefully. He will only be allowed to go through a door once. Then it will seal shut for ever. Once you have decided which one he should go through, write its number down so that you don't use it again! Which door do you think Sonic should go through:\n\nThe one with a pair of tweezers?\t\t\tTurn to <b>149</b>\nThe one with a sky net?\t\t\tTurn to <b>290</b>\nThe one with a pair of gloves?\t\t\tTurn to <b>252</b>\nThe one with an energy bomb?\t\t\tTurn to <b>245</b>";
			}
		}
		if (index == 221) {
			if (OptionsGlobal.options["reEnterSpecialZoneDoors"]) {
				SVZText.sectionLibrary[index].text = "The chip starts to flash with red lights and emit a quiet humming sound. Suddenly, Sonic feels a little dizzy and Tails starts to sway from side to side. The next thing they know, they're standing in a square room. Everything shines with a bright white light. This isn't anywhere Sonic's been before, in fact it doesn't even look like a 'normal' Zone.\n\nThere are four doors, one in each wall. Above each door is a different picture. Sonic and Tails must choose carefully. Which door do you think Sonic and Tails should go through:\n\nThe one with a pair of tweezers?\t\t\tTurn to <b>149</b>\nThe one with a sky net?\t\t\tTurn to <b>290</b>\nThe one with a pair of gloves?\t\t\tTurn to <b>252</b>\nThe one with an energy bomb?\t\t\tTurn to <b>245</b>";
			}
			else {
				SVZText.sectionLibrary[index].text = "The chip starts to flash with red lights and emit a quiet humming sound. Suddenly, Sonic feels a little dizzy and Tails starts to sway from side to side. The next thing they know, they're standing in a square room. Everything shines with a bright white light. This isn't anywhere Sonic's been before, in fact it doesn't even look like a 'normal' Zone.\n\nThere are four doors, one in each wall. Above each door is a different picture. Sonic and Tails must choose carefully. They will only be allowed to go through a door once. It will seal shut for ever afterwards. Once they have decided which one to go through, put its number down so that they do not try and use it again! Which door do you think Sonic and Tails should go through:\n\nThe one with a pair of tweezers?\t\t\tTurn to <b>149</b>\nThe one with a sky net?\t\t\tTurn to <b>290</b>\nThe one with a pair of gloves?\t\t\tTurn to <b>252</b>\nThe one with an energy bomb?\t\t\tTurn to <b>245</b>";
			}
		}
		
		if (index == 127 || index == 221) {
			// Permanently close Special Zone doors
			int[] doorChoices = new int[4] {149, 290, 252, 245};
			if (!OptionsGlobal.options["reEnterSpecialZoneDoors"]) {
				List<int> doorList = new List<int>();
				if (doorOpen("Tweezers")) {
					doorList.Add(149);
				}
				if (doorOpen("Sky net")) {
					doorList.Add(290);
				}
				if (doorOpen("Gloves")) {
					doorList.Add(252);
				}
				if (doorOpen("Energy bomb")) {
					doorList.Add(245);
				}
				doorChoices = doorList.ToArray();
			}
			SVZText.sectionLibrary[index].choices = doorChoices;
		}
	}
	
	private void BoomLogic() {
		if (index == 140 || index == 160) {
			GetHit();
		}
		if (index == 146) {
			if (SVZStats.rings > 0) {
				EarnRings(-20);
			}
			else {
				SVZStats.lives--;
				if (SVZStats.lives == 0) {
					MusicManager.PlaySongForSection(54);
					gameOver = true;
				}
			}
		}
		if (boomSections.Contains(index)) {
			SFXAudioSource.clip = Explosion;
			SFXAudioSource.Play();
		}
	}
}