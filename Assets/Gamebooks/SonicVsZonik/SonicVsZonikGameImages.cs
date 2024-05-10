using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonicVsZonikGameImages : MonoBehaviour
{
	[SerializeField] private Sprite section1;
	[SerializeField] private Sprite section12;
	[SerializeField] private Sprite section23;
	[SerializeField] private Sprite section34;
	[SerializeField] private Sprite section46;
	[SerializeField] private Sprite section58;
	[SerializeField] private Sprite section69;
	[SerializeField] private Sprite section80;
	[SerializeField] private Sprite section91;
	[SerializeField] private Sprite section102;
	[SerializeField] private Sprite section113;
	[SerializeField] private Sprite section124;
	[SerializeField] private Sprite section135;
	[SerializeField] private Sprite section146;
	[SerializeField] private Sprite section157;
	[SerializeField] private Sprite section169;
	[SerializeField] private Sprite section180;
	[SerializeField] private Sprite section191;
	[SerializeField] private Sprite section202;
	[SerializeField] private Sprite section213;
	[SerializeField] private Sprite section225;
	[SerializeField] private Sprite section236;
	[SerializeField] private Sprite section248;
	[SerializeField] private Sprite section269;
	[SerializeField] private Sprite section290;
	private int currentIndex;
	
   void Start() {
		currentIndex = SonicVsZonikGame.index;
	}
	
	void Update() {
		if (SonicVsZonikGame.index != currentIndex) {
			switch(SonicVsZonikGame.index)
			{
				case 1:
					GetComponent<Image>().sprite = section1;
					break;
				case 12:
					GetComponent<Image>().sprite = section12;
					break;
				case 23:
					GetComponent<Image>().sprite = section23;
					break;
				case 34:
					GetComponent<Image>().sprite = section34;
					break;
				case 46:
					GetComponent<Image>().sprite = section46;
					break;
				case 58:
					GetComponent<Image>().sprite = section58;
					break;
				case 69:
					GetComponent<Image>().sprite = section69;
					break;
				case 80:
					GetComponent<Image>().sprite = section80;
					break;
				case 91:
					GetComponent<Image>().sprite = section91;
					break;
				case 102:
					GetComponent<Image>().sprite = section102;
					break;
				case 113:
					GetComponent<Image>().sprite = section113;
					break;
				case 124:
					GetComponent<Image>().sprite = section124;
					break;
				case 135:
					GetComponent<Image>().sprite = section135;
					break;
				case 146:
					GetComponent<Image>().sprite = section146;
					break;
				case 157:
					GetComponent<Image>().sprite = section157;
					break;
				case 169:
					GetComponent<Image>().sprite = section169;
					break;
				case 180:
					GetComponent<Image>().sprite = section180;
					break;
				case 191:
					GetComponent<Image>().sprite = section191;
					break;
				case 202:
					GetComponent<Image>().sprite = section202;
					break;
				case 213:
					GetComponent<Image>().sprite = section213;
					break;
				case 225:
					GetComponent<Image>().sprite = section225;
					break;
				case 236:
					GetComponent<Image>().sprite = section236;
					break;
				case 248:
					GetComponent<Image>().sprite = section248;
					break;
				case 269:
					GetComponent<Image>().sprite = section269;
					break;
				case 290:
					GetComponent<Image>().sprite = section290;
					break;
			}
			currentIndex = SonicVsZonikGame.index;
		}
	}
}
