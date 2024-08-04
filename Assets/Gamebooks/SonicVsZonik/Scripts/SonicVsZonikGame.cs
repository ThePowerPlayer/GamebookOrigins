using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SVZText = SonicVsZonikGameText;

public class SonicVsZonikGame : MonoBehaviour
{
	[SerializeField] private GameObject TurnToSection;
	[SerializeField] private GameObject ButtonBack;
	
    public static int index;
	private int mostRecentIndex;
	private const int indexMin = 1;
	private const int indexMax = 300;
	public static bool backButtonPressed;
	public static int maxPoints;
	public SonicsStuff SonicsStuff;
	public SonicVsZonikMusicManager MusicManager;
	public SonicVsZonikSectionLogic SVZLogicScript;
	
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
			maxPoints = 70;
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
	
	private void VisitIndex() {		
		// Update music (if applicable)
		MusicManager.PlaySongForSection(index);
		
		// Reset dice roll for visited section
		SVZText.sectionLibrary[mostRecentIndex].rollComplete = false;
		SVZText.sectionLibrary[mostRecentIndex].rollSuccess = false;
		
		if (!backButtonPressed) {
			SVZLogicScript.UpdateInventory();
			SVZLogicScript.SectionLogic();
			SVZLogicScript.AddToHistory();
			
			// Mark section as visited (independent of section history)
			SVZText.sectionLibrary[index].visited = true;
			// Mark section as in history (dependent on current section history)
			SVZText.sectionLibrary[index].inHistory = true;
		}
		else {
			// For more logic involving returning to the previous section,
			// see BackButton.cs.
			backButtonPressed = false;
		}
		TextObject.GetComponent<SonicVsZonikGameText>().UpdateText();
		SectionObject.GetComponent<SonicVsZonikGameText>().UpdateText();
		ChangeButtons();
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
		
		int[] choices = new int[0] {};
		
		//Debug.Log("diceSection = " + SVZText.sectionLibrary[index].diceSection
		//	+ ", rollComplete = " + SVZText.sectionLibrary[index].rollComplete
		//	+ ", rollSuccess = " + SVZText.sectionLibrary[index].rollSuccess);
		
		if (SVZText.sectionLibrary[index].diceSection) {
			// Dice sections
			if (SVZText.sectionLibrary[index].rollComplete) {
				if (SVZText.sectionLibrary[index].rollSuccess) {
					//Debug.Log("choicesDiceWin = " + SVZText.sectionLibrary[index].choicesDiceWin);
					choices = SVZText.sectionLibrary[index].choicesDiceWin;
				}
				else {
					//Debug.Log("choicesDiceLose = " + SVZText.sectionLibrary[index].choicesDiceLose);
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
