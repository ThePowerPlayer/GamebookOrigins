using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicVsZonikGame : MonoBehaviour
{
    public static int index;
	private const int indexMin = 1;
	private const int indexMax = 300;
	[SerializeField] private GameObject TextObject;
	[SerializeField] private GameObject SectionObject;
	[SerializeField] private GameObject ButtonSectionA;
	[SerializeField] private GameObject ButtonSectionB;
	[SerializeField] private GameObject ButtonSectionC;
	[SerializeField] private GameObject ButtonSectionD;
	
	void Start()
    {
		index = 1;
		TextObject.GetComponent<SonicVsZonikGameText>().UpdateText();
		SectionObject.GetComponent<SonicVsZonikGameText>().UpdateText();
		ChangeButtons();
    }
	
	public void UpdatePosX(GameObject Button, float x) {
		// TODO: Why does this transformation require a shift to the right by an additional 800 units?
		Button.transform.position = new Vector3(x + 800, Button.transform.position.y, Button.transform.position.z);
	}
	
	public void ChangeButtons() {
		// Determine how many choices are possible from the current section,
		// and update the number, position, and text of the buttons accordingly.
		// TODO: Change the text of the buttons, and make them actually work!
		int i = index;
		switch(SonicVsZonikGameText.choicesLibrary[i].Length)
		{
			case 1:
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(false);
				ButtonSectionC.SetActive(false);
				ButtonSectionD.SetActive(false);
				
				UpdatePosX(ButtonSectionA, 225);
				break;
			case 2:
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(true);
				ButtonSectionC.SetActive(false);
				ButtonSectionD.SetActive(false);
				
				UpdatePosX(ButtonSectionA, 100);
				UpdatePosX(ButtonSectionB, 400);
				break;
			case 3:
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(true);
				ButtonSectionC.SetActive(true);
				ButtonSectionD.SetActive(false);
				
				UpdatePosX(ButtonSectionA, -50);
				UpdatePosX(ButtonSectionB, 225);
				UpdatePosX(ButtonSectionC, 500);
				break;
			case 4:
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(true);
				ButtonSectionC.SetActive(true);
				ButtonSectionD.SetActive(true);
				
				UpdatePosX(ButtonSectionA, -140);
				UpdatePosX(ButtonSectionB, 120);
				UpdatePosX(ButtonSectionC, 380);
				UpdatePosX(ButtonSectionD, 640);
				break;
			default:
				ButtonSectionA.SetActive(false);
				ButtonSectionB.SetActive(false);
				ButtonSectionC.SetActive(false);
				ButtonSectionD.SetActive(false);
				break;
		}
		
	}
	
	public void GoToIndex(string indexString) {
		int newIndex = 0;
		if (int.TryParse(indexString, out newIndex)) {
			if (newIndex >= indexMin && newIndex <= indexMax) {
				index = newIndex;
				TextObject.GetComponent<SonicVsZonikGameText>().UpdateText();
				SectionObject.GetComponent<SonicVsZonikGameText>().UpdateText();
				ChangeButtons();
			}
		}
    }
}
