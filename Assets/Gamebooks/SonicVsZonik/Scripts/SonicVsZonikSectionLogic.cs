using System.Collections;
using System.Collections.Generic;
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
	
	// All sections where the energy gun is fired
	// (and 10 rings are expended):
	// 121 = Rexon
	// 190 = Zonik's skimmer
	// 230 = Giant Badnik
	// 271 = Zonik
	// 289 = Robotnik's hover ship
	private int[] energyGunFired = new int[] {121, 190, 230, 271, 289};
	
	[SerializeField] private AudioSource SFXAudioSource;
	[SerializeField] private SonicVsZonikJingleManager JingleManager;
	
	[SerializeField] private AudioClip Ring;
	[SerializeField] private AudioClip LoseRings;
	[SerializeField] private AudioClip ObtainItem;
	[SerializeField] private AudioClip LoseLife;
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
	}
	
	public static Stack<SectionSave> sectionHistory = new Stack<SectionSave>();
	
	void Start() {
		previousIndex = 1;
		previousChoices = new int[0] {};
		
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
		EnergyGunLogic();
		MackLogic();
		BoatLogic();
		PinballLogic();
		AsteronLogic();
		MysticCaveLogic();
		//FakTorEeeLogic();
		//SkyChaseLogic();
		ZoneChipLogic();
		OptionsLogic();
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
			SFXAudioSource.clip = ObtainItem;
			SFXAudioSource.Play();
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
			SonicsStuff = SVZStats.SonicsStuff,
			
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
			skyChaseMethod = SVZLogic.skyChaseMethod
		};
		sectionHistory.Push(mostRecentSection);
	}
	
	public void RemoveFromHistory() {
		if (sectionHistory.Count > 1) {
			sectionHistory.Pop();
		}
		
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
			if (SVZStats.lives <= 0) {
				Debug.Log("TODO: Implement Game Over!");
			}
		}
	}
	
	private void EnergyGunLogic() {
		bool canUseEnergyGun = (SVZStats.rings >= 10 && SVZStats.SonicsStuff.Contains("Energy gun"));
		
		// Special logic for sections 158 and 263
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
				// TODO: Only make Section 121 cost 10 rings if the dice roll fails
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
		// TODO: Lose rings if hit by a missile
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
	
	private void ZoneChipLogic() {
		// Always give Sonic the Zone Chip, if the option to do so is enabled
		if (OptionsGlobal.options["alwaysGetZoneChip"]
			&& index == 201 && !SVZStats.SonicsStuff.Contains("Zone Chip")) {
			SVZStats.SonicsStuff.Add("Zone Chip");
		}
		
		// Immediately after pressing "Use Zone Chip" button
		if (index == 237) {
			SVZText.sectionLibrary[index].choices = new int[3] {zoneChipIndex, 127, 221};
		}
		// After actually using the Zone Chip
		if (index == 127 || index == 221) {
			SFXAudioSource.clip = EnterZoneChipArea;
			SFXAudioSource.Play();
		}
		// After pressing the red button in any Zone Chip area
		else if (index == 187) {
			SFXAudioSource.clip = LeaveZoneChipArea;
			SFXAudioSource.Play();
			ForceToIndex(zoneChipIndex);
		}
	}
	
	private void OptionsLogic() {
		// Choices for Section 124 (Pinball spinner)
		if (index == 124) {
			SVZText.sectionLibrary[index].text = "Sonic and Tails find themselves in the game's central spinner. It looks like a massive fairground roundabout. There are five exits from the spinner back into the game, each of which is spring loaded, so make sure our friends are careful! Both of them have played the game already, but they must remember that Zonik has been here before them, which makes it an altogether more dangerous place to be!\n\nSonic and Tails are now committed to playing the game. There are only two ways out, and one of them is <i>unthinkable</i>! Each time they visit a part of the game, write down the number of the section so that you know they have been there already. They may not use the gold exit until they have scored " + SonicVsZonikGame.maxPoints + " points in the game. Make a note of the points they score. Which exit should they use to leave the game:\n\nThe red exit?\t\t\tTurn to <b>295</b>\nThe yellow exit?\t\t\tTurn to <b>299</b>\nThe blue exit?\t\t\tTurn to <b>229</b>\nThe green exit?\t\t\tTurn to <b>86</b>\nThe gold exit?\t\t\tTurn to <b>45</b>";
			if (SVZStats.points >= SonicVsZonikGame.maxPoints) {
				JingleManager.PlayJingle("SpinballComplete");
				ForceToIndex(45);
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[4] {295, 299, 229, 86};
			}
		}
		
		// Choices for Sections 84 (Fruit machine)
		if (index == 84) {
			if (OptionsGlobal.options["fixFruitMachine"]) {
				SVZText.sectionLibrary[index].text = "The fruit machine whirrs into action, while Sonic and Tails stare at it. A WINNER!!! Roll the die twice and add the scores together. This is the number of rings that the fruit machine pays out! Add these to Sonic's Stuff.\n\nIf you want Sonic to play the fruit machine again, turn to <b>171</b>. If you think he should stop wasting time, turn to <b>66</b>.";
				SVZText.sectionLibrary[index].choices = new int[2] {171, 66};
			}
			else {
				SVZText.sectionLibrary[index].text = "The fruit machine whirrs into action, while Sonic and Tails stare at it. A WINNER!!! Roll the die twice and add the scores together. This is the number of rings that the fruit machine pays out! Add these to Sonic's Stuff.\n\nIf you want Sonic to play the fruit machine again, turn to <b>171</b>. If you think he should stop wasting time, turn to <b>97</b>.";
				SVZText.sectionLibrary[index].choices = new int[2] {171, 97};
			}
		}
		if (index == 199) {
			if (OptionsGlobal.options["fixFruitMachine"]) {
				SVZText.sectionLibrary[index].text = "The fruit machine whirrs into action while Sonic and Tails are staring at it. Sonic loses. If Sonic plays the fruit machine again, turn to <b>171</b>. If he thinks it's a waste of time, turn to <b>66</b>.";
				SVZText.sectionLibrary[index].choices = new int[2] {171, 66};
			}
			else {
				SVZText.sectionLibrary[index].text = "The fruit machine whirrs into action while Sonic and Tails are staring at it. Sonic loses. If Sonic plays the fruit machine again, turn to <b>171</b>. If he thinks it's a waste of time, turn to <b>97</b>.";
				SVZText.sectionLibrary[index].choices = new int[2] {171, 97};
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
	}
}
