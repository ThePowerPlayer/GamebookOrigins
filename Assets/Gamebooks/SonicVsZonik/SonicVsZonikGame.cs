using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SVZ = SonicVsZonikGameText;

public class SonicVsZonikGame : MonoBehaviour
{
    public static int index;
	private int currentIndex;
	private const int indexMin = 1;
	private const int indexMax = 300;
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
		index = 1;
		TextObject.GetComponent<SVZ>().UpdateText();
		SectionObject.GetComponent<SVZ>().UpdateText();
		ChangeButtons();
    }
	
	void Update()
	{
		if (index != currentIndex) {
			currentIndex = index;
			GoToIndex(index.ToString());
		}
	}
	
	public void UpdatePosX(GameObject Button, float x) {
		// TODO: Why does this transformation require a shift to the right by an additional 800 units?
		Button.transform.position = new Vector3(x + 800, Button.transform.position.y, Button.transform.position.z);
	}
	
	public void ChangeButtons() {
		// Determine how many choices are possible from the current section,
		// and update the number, position, and text of the buttons accordingly.
		// TODO: Make the buttons actually work when pressed.
		int i = index;
		
		ButtonSectionA.SetActive(false);
		ButtonSectionB.SetActive(false);
		ButtonSectionC.SetActive(false);
		ButtonSectionD.SetActive(false);
		
		switch(SVZ.choicesLibrary[i].Length)
		{
			case 1:
				UpdatePosX(ButtonSectionA, 225);
				
				ButtonSectionAText.text = SVZ.choicesLibrary[i][0].ToString();
				
				ButtonSectionA.SetActive(true);
				break;
			case 2:
				UpdatePosX(ButtonSectionA, 100);
				UpdatePosX(ButtonSectionB, 400);
				
				ButtonSectionAText.text = SVZ.choicesLibrary[i][0].ToString();
				ButtonSectionBText.text = SVZ.choicesLibrary[i][1].ToString();
				
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(true);
				break;
			case 3:
				UpdatePosX(ButtonSectionA, -50);
				UpdatePosX(ButtonSectionB, 225);
				UpdatePosX(ButtonSectionC, 500);
				
				ButtonSectionAText.text = SVZ.choicesLibrary[i][0].ToString();
				ButtonSectionBText.text = SVZ.choicesLibrary[i][1].ToString();
				ButtonSectionCText.text = SVZ.choicesLibrary[i][2].ToString();
				
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(true);
				ButtonSectionC.SetActive(true);
				break;
			case 4:
				UpdatePosX(ButtonSectionA, -140);
				UpdatePosX(ButtonSectionB, 120);
				UpdatePosX(ButtonSectionC, 380);
				UpdatePosX(ButtonSectionD, 640);
				
				ButtonSectionAText.text = SVZ.choicesLibrary[i][0].ToString();
				ButtonSectionBText.text = SVZ.choicesLibrary[i][1].ToString();
				ButtonSectionCText.text = SVZ.choicesLibrary[i][2].ToString();
				ButtonSectionDText.text = SVZ.choicesLibrary[i][3].ToString();
				
				ButtonSectionA.SetActive(true);
				ButtonSectionB.SetActive(true);
				ButtonSectionC.SetActive(true);
				ButtonSectionD.SetActive(true);
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
