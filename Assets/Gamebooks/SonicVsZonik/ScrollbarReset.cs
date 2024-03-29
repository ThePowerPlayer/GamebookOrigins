using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarReset : MonoBehaviour
{
	private ScrollRect scroll;
	private int currentIndex;
	
	void Start() {
		scroll = GetComponent<ScrollRect>();
		currentIndex = SonicVsZonikMenu.index;
	}
	
    void Update() {
		if (SonicVsZonikMenu.index != currentIndex) {
			scroll.verticalNormalizedPosition = 1;
			currentIndex = SonicVsZonikMenu.index;
		}
	}
}
