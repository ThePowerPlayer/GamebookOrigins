using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBackground : MonoBehaviour
{
	[SerializeField] private GameObject BlankBG;
	[SerializeField] private GameObject CheckeredBGScroll;
	[SerializeField] private GameObject CheckeredBG;
	
    void OnEnable()
    {
		BlankBG.SetActive(OptionsGlobal.options["scrollingBG"]);
		CheckeredBGScroll.SetActive(OptionsGlobal.options["scrollingBG"]);
		CheckeredBG.SetActive(!OptionsGlobal.options["scrollingBG"]);
    }
}
