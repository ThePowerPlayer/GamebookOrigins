using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MackCounter : MonoBehaviour
{
	private TMP_Text currentText;
	private UnityEngine.UI.Image MackCounterSprite;
	
    void Start()
    {
        currentText = gameObject.GetComponent<TMP_Text>();
		MackCounterSprite = gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
    }

    void Update()
    {
		if (SonicVsZonikGameText.sectionLibrary[SonicVsZonikGame.index].mackSection) {
			currentText.enabled = true;
			currentText.text = SonicVsZonikGame.mackCounter.ToString();
			MackCounterSprite.enabled = true;
		}
        else {
			currentText.enabled = false;
			MackCounterSprite.enabled = false;
		}
    }
}
