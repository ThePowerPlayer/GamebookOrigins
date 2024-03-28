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
	
	void Start()
    {
		index = 1;
		TextObject.GetComponent<SonicVsZonikGameText>().UpdateText();
		SectionObject.GetComponent<SonicVsZonikGameText>().UpdateText();
    }
	
	public void GoToIndex(string indexString) {
		int newIndex = 0;
		if (int.TryParse(indexString, out newIndex)) {
			if (newIndex >= indexMin && newIndex <= indexMax) {
				index = newIndex;
				TextObject.GetComponent<SonicVsZonikGameText>().UpdateText();
				SectionObject.GetComponent<SonicVsZonikGameText>().UpdateText();
			}
		}
    }
}
