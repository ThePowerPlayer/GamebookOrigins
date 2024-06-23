using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Checkbox : MonoBehaviour
{
	public Sprite CheckboxUnchecked;
	public Sprite CheckboxChecked;
	public string option;
	private Image image;
	
	void CheckboxSprite(ref Image image, bool variable) {
		if (variable) {
			image.sprite = CheckboxChecked;
		}
		else {
			image.sprite = CheckboxUnchecked;
		}
	}
	
    void Start()
    {
        image = GetComponent<Image>();
    }
	
    void Update()
    {
		
        switch (option) {
			case "enableTurnToSection":
				CheckboxSprite(ref image, OptionsGlobal.enableTurnToSection);
				break;
			case "enableBackButton":
				CheckboxSprite(ref image, OptionsGlobal.enableBackButton);
				break;
			case "markVisitedSections":
				CheckboxSprite(ref image, OptionsGlobal.markVisitedSections);
				break;
			case "customVitalStatistics":
				CheckboxSprite(ref image, OptionsGlobal.customVitalStatistics);
				break;
		}
    }
}
