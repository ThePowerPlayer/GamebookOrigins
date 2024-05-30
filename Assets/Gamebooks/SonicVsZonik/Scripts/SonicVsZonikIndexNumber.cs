using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SonicVsZonikIndexNumber : MonoBehaviour
{
	[SerializeField] private TMP_Text currentText;
	private int currentIndex;
	
	void Start() {
		currentIndex = SonicVsZonikMenu.index;
		currentText.text = "(" + currentIndex + "/" + SonicVsZonikMenu.indexMax + ")";
	}
	
    void Update() {
		if (SonicVsZonikMenu.index != currentIndex) {
			currentIndex = SonicVsZonikMenu.index;
			currentText.text = "(" + currentIndex + "/" + SonicVsZonikMenu.indexMax + ")";
		}
	}
}
