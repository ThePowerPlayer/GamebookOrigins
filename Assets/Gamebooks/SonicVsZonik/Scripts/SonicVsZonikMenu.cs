using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonicVsZonikMenu : MonoBehaviour
{
	public static int index;
	public const int indexMin = 1;
	public const int indexMax = 7;
	public static bool allStatsAssigned;
	
	[SerializeField] private GameObject ButtonExit;
	[SerializeField] private GameObject ButtonNext;
	[SerializeField] private GameObject ButtonPrevious;
	[SerializeField] private GameObject ButtonStart;
	[SerializeField] private GameObject TextObject;
	[SerializeField] private GameObject HeaderObject;
	[SerializeField] private AssignVitalStatistics AssignVitalStatistics;
	
	void Start()
    {
		allStatsAssigned = false;
		index = 1;
		ButtonExit.SetActive(true);
		ButtonNext.SetActive(true);
		ButtonPrevious.SetActive(false);
		ButtonStart.SetActive(false);
		ChangeButtons();
		TextObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
		HeaderObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
    }
	
	public void ChangeButtons() {
		if (index == indexMin) {
			ButtonExit.SetActive(true);
			ButtonPrevious.SetActive(false);
		}
		else {
			ButtonExit.SetActive(false);
			ButtonPrevious.SetActive(true);
		}
		
		if (index == indexMax) {
			ButtonStart.SetActive(true);
			ButtonNext.SetActive(false);
		}
		else {
			ButtonStart.SetActive(false);
			ButtonNext.SetActive(true);
		}
		
		// Prevent progressing until all Vital Statistics have been assigned
		if (OptionsGlobal.options["customVitalStatistics"] == false) {
			if (index >= 2 && index <= 6) {
				ButtonNext.GetComponent<Button>().interactable = allStatsAssigned;
			}
			else if (index == 7) {
				ButtonStart.GetComponent<Button>().interactable = allStatsAssigned;
			}
		}
	}
	
    public void NextIndex()
    {
        if (index < indexMax) {
			index++;
		}
		ChangeButtons();
		TextObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
		HeaderObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
    }
	
	public void PreviousIndex()
    {
        if (index > indexMin) {
			index--;
		}
		ChangeButtons();
		TextObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
		HeaderObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
    }
}
