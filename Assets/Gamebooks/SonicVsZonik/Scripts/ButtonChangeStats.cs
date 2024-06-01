using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeStats : MonoBehaviour
{
    private Button button;
	[SerializeField] private bool increaseValue;
	[SerializeField] private string abilityToChange;
	
	void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}
	
	void Update() {
		Mathf.Clamp(SonicVsZonikVitalStatistics.abilities[abilityToChange], 0, 99);
	}
	
    private void TaskOnClick() {
		if (increaseValue) {
			SonicVsZonikVitalStatistics.abilities[abilityToChange]++;
		}
		else {
			SonicVsZonikVitalStatistics.abilities[abilityToChange]--;
		}
	}
}
