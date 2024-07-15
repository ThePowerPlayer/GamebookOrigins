using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxStatisticsButton : MonoBehaviour
{
	public AssignVitalStatistics StatManager;
	[SerializeField] private AudioSource audioSource;
    private Button button;
	
	void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}
	
    private void TaskOnClick() {
		if (OptionsGlobal.options["customVitalStatistics"]) {
			audioSource.Play();
			SonicVsZonikVitalStatistics.abilities["Speed"] = 99;
			SonicVsZonikVitalStatistics.abilities["Agility"] = 99;
			SonicVsZonikVitalStatistics.abilities["Strength"] = 99;
			SonicVsZonikVitalStatistics.abilities["Coolness"] = 99;
			SonicVsZonikVitalStatistics.abilities["Quick Wits"] = 99;
			SonicVsZonikVitalStatistics.abilities["Good Looks"] = 99;
		}
	}
}
