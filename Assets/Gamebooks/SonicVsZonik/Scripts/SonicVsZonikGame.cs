using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SVZText = SonicVsZonikGameText;

public class SonicVsZonikGame : MonoBehaviour
{
	[SerializeField] private AudioSource ringAudioSource;
	[SerializeField] private AudioClip Ring;
	[SerializeField] private AudioClip LoseRings;
	[SerializeField] private AudioClip EarnPoints;
	[SerializeField] private GameObject TurnToSection;
	[SerializeField] private GameObject ButtonBack;
	
    public static int index;
	private int mostRecentIndex;
	private const int indexMin = 1;
	private const int indexMax = 300;
	public static bool backButtonPressed;
	public static Stack<int> sectionHistory = new Stack<int>();
	public static int mackCounter = 0;
	public static int maxPoints;
	public SonicsStuff SonicsStuff;
	public SonicVsZonikMusicManager MusicManager;
	public SonicVsZonikJingleManager JingleManager;
	
	[SerializeField] private GameObject TextObject;
	[SerializeField] private GameObject SectionObject;
	[SerializeField] private GameObject ButtonSectionA;
	[SerializeField] private GameObject ButtonSectionB;
	[SerializeField] private GameObject ButtonSectionC;
	[SerializeField] private GameObject ButtonSectionD;
	[SerializeField] private TMP_Text ButtonSectionAText;
	[SerializeField] private TMP_Text ButtonSectionBText;
	[SerializeField] private TMP_Text ButtonSectionCText;
	[SerializeField] private TMP_Text ButtonSectionDText;
	
	void Start()
    {
		TurnToSection.SetActive(OptionsGlobal.options["enableTurnToSection"]);
		ButtonBack.SetActive(OptionsGlobal.options["enableBackButton"]);
		if (OptionsGlobal.options["lenientPinball"]) {
			maxPoints = 50;
		}
		else {
			maxPoints = 100;
		}
		index = 1;
		mostRecentIndex = 0;
    }
	
	public static void ChangeIndex(string indexString) {
		//Debug.Log("ChangeIndex(" + indexString + ")");
		int newIndex = 0;
		if (int.TryParse(indexString, out newIndex)
			&& newIndex >= indexMin && newIndex <= indexMax) {
			//Debug.Log("Index changed to " + newIndex);
			SonicVsZonikGame.index = newIndex;
		}
	}
	
	void Update()
	{
		if (mostRecentIndex != index) {
			//Debug.Log("Update: The index has changed!");
			mostRecentIndex = index;
			VisitIndex();
		}
	}
	
	private void UpdateInventory() {
		// Add rings, credits, and points
		if (SVZText.sectionLibrary[mostRecentIndex].rings > 0) {
			ringAudioSource.clip = Ring;
			ringAudioSource.Play();
		}
		else if (SVZText.sectionLibrary[mostRecentIndex].rings < 0
			|| SVZText.sectionLibrary[mostRecentIndex].credits < 0) {
			ringAudioSource.clip = LoseRings;
			ringAudioSource.Play();
		}
		
		SonicVsZonikVitalStatistics.rings += SVZText.sectionLibrary[mostRecentIndex].rings;
		SonicVsZonikVitalStatistics.credits += SVZText.sectionLibrary[mostRecentIndex].credits;
		if (!SVZText.sectionLibrary[mostRecentIndex].inHistory) {
			SonicVsZonikVitalStatistics.points += SVZText.sectionLibrary[mostRecentIndex].points;
			// Manage audio for earning points
			if (SVZText.sectionLibrary[mostRecentIndex].points > 0) {
				if (SonicVsZonikVitalStatistics.points >= maxPoints) {
					JingleManager.PlayJingle("Spinball100Points");
				}
				else {
					JingleManager.PlayJingle("SpinballPoints");
				}
			}
		}
		
		// Add items to Sonic's Stuff
		SonicsStuff.newItems = true;
		if (SVZText.sectionLibrary[mostRecentIndex].items != null) {
			foreach(string item in SVZText.sectionLibrary[mostRecentIndex].items) {
				SonicVsZonikVitalStatistics.SonicsStuff.Add(item);
			}
		}
		if (index == 234 || (OptionsGlobal.options["fixWhiffyLiquid"] && index == 180)) {
			JingleManager.PlayJingle("ChaosEmerald");
		}
	}
	
	private void SectionLogic() {
		// Increment counter for Mack sections
		if (SVZText.sectionLibrary[index].mackSection) {
			mackCounter++;
		}
		
		// Choices for Sections 185 and 283 (Lose credits)
		if (index == 185 || index == 283) {
			if (SonicVsZonikVitalStatistics.credits == 0 && !SonicVsZonikVitalStatistics.pinballSecondChanceUsed) {
				SonicVsZonikVitalStatistics.pinballSecondChanceUsed = true;
				SVZText.sectionLibrary[index].choices = new int[1] {126};
			}
			else if (SonicVsZonikVitalStatistics.credits == 0) {
				SVZText.sectionLibrary[index].choices = new int[1] {41};
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[1] {124};
			}
		}
	}
	
	private void OptionsLogic() {
		// Choices for Section 124 (Pinball spinner)
		if (index == 124) {
			SVZText.sectionLibrary[index].text = "Sonic and Tails find themselves in the game's central spinner. It looks like a massive fairground roundabout. There are five exits from the spinner back into the game, each of which is spring loaded, so make sure our friends are careful! Both of them have played the game already, but they must remember that Zonik has been here before them, which makes it an altogether more dangerous place to be!\n\nSonic and Tails are now committed to playing the game. There are only two ways out, and one of them is <i>unthinkable</i>! Each time they visit a part of the game, write down the number of the section so that you know they have been there already. They may not use the gold exit until they have scored " + maxPoints + " points in the game. Make a note of the points they score. Which exit should they use to leave the game:\n\nThe red exit?\t\t\tTurn to <b>295</b>\nThe yellow exit?\t\t\tTurn to <b>299</b>\nThe blue exit?\t\t\tTurn to <b>229</b>\nThe green exit?\t\t\tTurn to <b>86</b>\nThe gold exit?\t\t\tTurn to <b>45</b>";
			if (SonicVsZonikVitalStatistics.points >= maxPoints) {
				SVZText.sectionLibrary[index].choices = new int[1] {45};
			}
			else {
				SVZText.sectionLibrary[index].choices = new int[4] {295, 299, 229, 86};
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
				SVZText.sectionLibrary[index].choices = new int[1] {191};
			}
			else {
				SVZText.sectionLibrary[index].text = "Sonic pulls out the glass bottle of liquid that Whiffy gave him. He throws it at Zonik. He misses, but the bottle shatters on the ground, splashing Zonik's trainers! For a second or so, nothing happens, then the smell hits them!\n\n'OH, wow man!' is all that Sonic can manage. Tails doesn't even do that well and goes a funny shade of green. As for Zonik, well he starts to puff and jerk like he's got an ice cube down his back. Now he's hopping about on one foot. Then WHOOOSH ... Zonik runs from the cavern like nothing Sonic or Tails have ever seen before, dropping the Chaos Emerald in his haste.\n\nWith a paw firmly clamped over his nose, Sonic walks over to where Zonik had been standing and picks up the emerald. 'Good stuff that,' he says, pointing to the broken bottle. Tails just nods, and thinks he is going to be sick.\n\nTurn to <b>76</b>.";
				SVZText.sectionLibrary[index].choices = new int[1] {76};
			}
		}
		
		// Choices for Sections 216, 85, 119, and 68 (Sky Chase zone)
		if (index == 216) {
			if (OptionsGlobal.options["fixSkyChase"]) {
				SVZText.sectionLibrary[index].text = "'Come on, Tails, fly after him!' yells Sonic. Tails flies into the air holding out a paw for Sonic to grab. Zonik is already just a dot on the horizon. Our friends will have to move fast to catch him! Turn to <b>227</b>.";
				SVZText.sectionLibrary[index].choices = new int[1] {227};
			}
			else {
				SVZText.sectionLibrary[index].text = "'Come on, Tails, fly after him!' yells Sonic. Tails flies into the air holding out a paw for Sonic to grab. Zonik is already just a dot on the horizon. Our friends will have to move fast to catch him! Turn to <b>114</b>.";
				SVZText.sectionLibrary[index].choices = new int[1] {114};
			}
		}
		if (index == 85) {
			if (OptionsGlobal.options["fixSkyChase"]) {
				SVZText.sectionLibrary[index].text = "Tails climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, but Tails has the advantage of being a natural flyer. Reaching out, he presses the red button, and the skimmer's engines spring to life. Then he pulls the joystick back and the skimmer flies into the air. Turn to <b>227</b>.";
				SVZText.sectionLibrary[index].choices = new int[1] {227};
			}
			else {
				SVZText.sectionLibrary[index].text = "Tails climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, but Tails has the advantage of being a natural flyer. Reaching out, he presses the red button, and the skimmer's engines spring to life. Then he pulls the joystick back and the skimmer flies into the air. Turn to <b>68</b>.";
				SVZText.sectionLibrary[index].choices = new int[1] {68};
			}
		}
		if (index == 119) {
			if (OptionsGlobal.options["fixSkyChase"]) {
				SVZText.sectionLibrary[index].text = "Sonic climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, which wasn't really Sonic's style anyway. Roll the die and add the result to Sonic's Quick Wits. If the score is 7 or more, turn to <b>68</b>. If the score is less than 7, turn to <b>114</b>.";
				SVZText.sectionLibrary[index].choicesDiceLose = new int[1] {114};
			}
			else {
				SVZText.sectionLibrary[index].text = "Sonic climbs into the pilot's seat and looks at the controls. As well as the joystick, there are several weird-looking dials and a big red button. This is all very complicated! There isn't time to sit and think things out, which wasn't really Sonic's style anyway. Roll the die and add the result to Sonic's Quick Wits. If the score is 7 or more, turn to <b>68</b>. If the score is less than 7, turn to <b>227</b>.";
				SVZText.sectionLibrary[index].choicesDiceLose = new int[1] {227};
			}
		}
		if (index == 68) {
			if (OptionsGlobal.options["fixSkyChase"]) {
				SVZText.sectionLibrary[index].text = "Sonic reaches out and presses the red button. The skimmer's engines spring to life. Sonic pulls the joystick back and the skimmer flies into the air.\n\n'See, old friend, nothing to this flying. Anyone can do it!' The skimmer judders and wobbles as Sonic struggles to control it.\n\n'Push the stick forward!' shouts Tails. Sonic does it and the skimmer moves off after Zonik. Even Sonic thinks it might have been better to have let Tails fly the skimmer! Turn to <b>227</b>.";
				SVZText.sectionLibrary[index].choices = new int[1] {227};
			}
			else {
				SVZText.sectionLibrary[index].text = "Sonic reaches out and presses the red button. The skimmer's engines spring to life. Sonic pulls the joystick back and the skimmer flies into the air.\n\n'See, old friend, nothing to this flying. Anyone can do it!' The skimmer judders and wobbles as Sonic struggles to control it.\n\n'Push the stick forward!' shouts Tails. Sonic does it and the skimmer moves off after Zonik. Even Sonic thinks it might have been better to have let Tails fly the skimmer! Turn to <b>114</b>.";
				SVZText.sectionLibrary[index].choices = new int[1] {114};
			}
		}
		
		// Choices for Sections 153 (Cloud skimmer jumps back in time)
		if (index == 153) {
			if (OptionsGlobal.options["fixCloudSkimmer"]) {
				SVZText.sectionLibrary[index].text = "Using the advantage of height, Sonic and Tails swoop down on Zonik's cloud skimmer, passing it with only centimetres to spare! Turn to <b>158</b>.";
				SVZText.sectionLibrary[index].choices = new int[1] {158};
			}
			else {
				SVZText.sectionLibrary[index].text = "Using the advantage of height, Sonic and Tails swoop down on Zonik's cloud skimmer, passing it with only centimetres to spare! Turn to <b>268</b>.";
				SVZText.sectionLibrary[index].choices = new int[1] {268};
			}
		}
	}
	
	private void VisitIndex() {
		// Update music (if applicable)
		MusicManager.PlaySongForSection(index);
		
		// Reset dice roll for visited section
		SVZText.sectionLibrary[mostRecentIndex].rollComplete = false;
		SVZText.sectionLibrary[mostRecentIndex].rollSuccess = false;
		
		if (backButtonPressed) {
			// For more logic involving returning to the previous section,
			// see BackButton.cs.
			backButtonPressed = false;
		}
		else {
			// Add to section history
			sectionHistory.Push(index);
			
			UpdateInventory();
			SectionLogic();
			OptionsLogic();
			
			// Mark section as visited (independent of section history)
			SVZText.sectionLibrary[index].visited = true;
			// Mark section as in history (dependent on current section history)
			SVZText.sectionLibrary[index].inHistory = true;
		}
		//PrintSectionHistory(); // DEBUG
		TextObject.GetComponent<SonicVsZonikGameText>().UpdateText();
		SectionObject.GetComponent<SonicVsZonikGameText>().UpdateText();
		ChangeButtons();
    }
	
	private void PrintSectionHistory() {
		string sectionHistoryStr = "Section History: ";
		foreach(int section in sectionHistory) {
			sectionHistoryStr += (section + " ");
		}
		Debug.Log(sectionHistoryStr);
	}
	
	private void UpdatePosX(GameObject Button, float x) {
		// Change RectTransform, NOT regular transform.position
		RectTransform ButtonRectTransform = Button.GetComponent<RectTransform>();
		ButtonRectTransform.anchoredPosition =
			new Vector2(x, ButtonRectTransform.anchoredPosition.y);
		//Debug.Log("GameObject " + Button.name + " changed to X position = " + x);
	}
	
	public void SetButtonVisited(GameObject ButtonSection, int i) {
		//Debug.Log(OptionsGlobal.markVisitedSections + " " + ButtonSection.activeInHierarchy + " " + SVZText.sectionLibrary[i].visited);
		if (OptionsGlobal.options["markVisitedSections"] && ButtonSection.activeInHierarchy && SVZText.sectionLibrary[i].visited) {
			ButtonSection.GetComponent<UnityEngine.UI.Image>().color = Color.yellow;
		}
		else {
			ButtonSection.GetComponent<UnityEngine.UI.Image>().color = Color.white;
		}
	}
	
	private void SetButtonPositions(GameObject ButtonSectionA, GameObject ButtonSectionB,
		GameObject ButtonSectionC, GameObject ButtonSectionD, int i, int[] choices) {
		switch(choices.Length)
		{
			case 1:
				UpdatePosX(ButtonSectionA, 245);
				
				ButtonSectionAText.text = choices[0].ToString();
				
				ButtonSectionA.SetActive(true);
				break;
			case 2:
				UpdatePosX(ButtonSectionA, 100);
				UpdatePosX(ButtonSectionB, 400);
				
				ButtonSectionAText.text = choices[0].ToString();
				ButtonSectionBText.text = choices[1].ToString();
				
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(true);
				break;
			case 3:
				UpdatePosX(ButtonSectionA, -30);
				UpdatePosX(ButtonSectionB, 245);
				UpdatePosX(ButtonSectionC, 520);
				
				ButtonSectionAText.text = choices[0].ToString();
				ButtonSectionBText.text = choices[1].ToString();
				ButtonSectionCText.text = choices[2].ToString();
				
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(true);
				ButtonSectionC.SetActive(true);
				break;
			case 4:
				UpdatePosX(ButtonSectionA, -140);
				UpdatePosX(ButtonSectionB, 120);
				UpdatePosX(ButtonSectionC, 380);
				UpdatePosX(ButtonSectionD, 640);
				
				ButtonSectionAText.text = choices[0].ToString();
				ButtonSectionBText.text = choices[1].ToString();
				ButtonSectionCText.text = choices[2].ToString();
				ButtonSectionDText.text = choices[3].ToString();
				
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(true);
				ButtonSectionC.SetActive(true);
				ButtonSectionD.SetActive(true);
				break;
		}
	
		// Mark buttons as yellow if their sections have been visited
		SetButtonVisited(ButtonSectionA, int.Parse(ButtonSectionAText.text));
		SetButtonVisited(ButtonSectionB, int.Parse(ButtonSectionBText.text));
		SetButtonVisited(ButtonSectionC, int.Parse(ButtonSectionCText.text));
		SetButtonVisited(ButtonSectionD, int.Parse(ButtonSectionDText.text));
	}
	
	public void ChangeButtons() {
		// Determine how many choices are possible from the current section,
		// and update the number, position, and text of the buttons accordingly.
		ButtonSectionA.SetActive(false);
		ButtonSectionB.SetActive(false);
		ButtonSectionC.SetActive(false);
		ButtonSectionD.SetActive(false);
		
		int[] choices;
		
		//Debug.Log("diceSection = " + SVZText.sectionLibrary[index].diceSection
		//	+ ", rollComplete = " + SVZText.sectionLibrary[index].rollComplete
		//	+ ", rollSuccess = " + SVZText.sectionLibrary[index].rollSuccess);
		if (SVZText.sectionLibrary[index].diceSection) {
			// Dice sections
			if (SVZText.sectionLibrary[index].rollComplete) {
				if (SVZText.sectionLibrary[index].rollSuccess) {
					choices = SVZText.sectionLibrary[index].choicesDiceWin;
				}
				else {
					choices = SVZText.sectionLibrary[index].choicesDiceLose;
				}
			}
			else {
				return;
			}
		}
		else {
			// Non-dice sections
			choices = SVZText.sectionLibrary[index].choices;
		}
		
		SetButtonPositions(ButtonSectionA, ButtonSectionB, ButtonSectionC,
			ButtonSectionD, index, choices);
	}
}
