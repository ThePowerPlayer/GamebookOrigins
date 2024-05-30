using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Stats = SonicVsZonikVitalStatistics;

public class SonicsStuff : MonoBehaviour
{
	private TMP_Text currentText;
	public bool newItems;
	private string sonicsStuff;
	
	void Start()
    {
		newItems = true;
		sonicsStuff = "";
        currentText = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
		if (newItems) {
			newItems = false;
			sonicsStuff = "";
			if (Stats.SonicsStuff.Count > 0) {
				foreach (string item in Stats.SonicsStuff) {
					sonicsStuff += ("• " + item + "\n");
				}
			}
			else {
				sonicsStuff = "You don't have any stuff yet.";
			}
		}
		
        currentText.text = sonicsStuff;
    }
}
