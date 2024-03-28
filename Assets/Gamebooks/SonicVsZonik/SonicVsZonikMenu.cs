using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicVsZonikMenu : MonoBehaviour
{
	public static int index;
	private const int indexMin = 1;
	private const int indexMax = 7;
	[SerializeField] private GameObject ButtonExit;
	[SerializeField] private GameObject ButtonNext;
	[SerializeField] private GameObject ButtonPrevious;
	[SerializeField] private GameObject ButtonStart;
	[SerializeField] private GameObject TextObject;
	[SerializeField] private GameObject HeaderObject;
	
	void Start()
    {
		index = 1;
		ButtonExit.SetActive(true);
		ButtonNext.SetActive(true);
		ButtonPrevious.SetActive(false);
		ButtonStart.SetActive(false);
		CheckButtons();
		TextObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
		HeaderObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
    }
	
	public void CheckButtons() {
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
	}
	
    public void NextIndex()
    {
        if (index < indexMax) {
			index++;
		}
		CheckButtons();
		TextObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
		HeaderObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
    }
	
	public void PreviousIndex()
    {
        if (index > indexMin) {
			index--;
		}
		CheckButtons();
		TextObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
		HeaderObject.GetComponent<SonicVsZonikMenuText>().UpdateText();
    }
}
