using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Stats = SonicVsZonikVitalStatistics;

public class SonicsStuff : MonoBehaviour
{
	[SerializeField] public TMP_Text currentText;
	private string sonicsStuff;
	
	void OnEnable()
    {
		sonicsStuff = "";
		if (Stats.SonicsStuff.Count > 0) {
			foreach (string item in Stats.SonicsStuff) {
				sonicsStuff += ("• " + item + "\n");
			}
		}
		else {
			sonicsStuff = "You don't have any stuff yet.";
		}
		currentText.text = sonicsStuff;
    }
}
