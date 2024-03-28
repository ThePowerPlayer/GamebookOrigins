using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonicVsZonikMenuImages : MonoBehaviour
{
	[SerializeField] private Sprite image1;
	[SerializeField] private Sprite image2;
	[SerializeField] private Sprite image3;
	[SerializeField] private Sprite image4;
	[SerializeField] private Sprite image5;
	[SerializeField] private Sprite image6;
	[SerializeField] private Sprite image7;
	private int currentIndex;
	
	void Start() {
		currentIndex = SonicVsZonikMenu.index;
	}
	
	void Update() {
		if (SonicVsZonikMenu.index != currentIndex) {
			switch(SonicVsZonikMenu.index)
			{
				case 1:
					GetComponent<Image>().sprite = image1;
					break;
				case 2:
					GetComponent<Image>().sprite = image2;
					break;
				case 3:
					GetComponent<Image>().sprite = image3;
					break;
				case 4:
					GetComponent<Image>().sprite = image4;
					break;
				case 5:
					GetComponent<Image>().sprite = image5;
					break;
				case 6:
					GetComponent<Image>().sprite = image6;
					break;
				case 7:
					GetComponent<Image>().sprite = image7;
					break;
				default:
					GetComponent<Image>().sprite = image1;
					break;
			}
			currentIndex = SonicVsZonikMenu.index;
		}
	}
}
