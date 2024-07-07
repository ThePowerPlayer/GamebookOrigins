using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonChangeStats : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool buttonPressed;
	private float incrementTimer = 0f;
	private const float incrementTimerMax = 0.15f;
	[SerializeField] private bool increaseValue;
	[SerializeField] private string abilityToChange;
	
	void Awake() {
		// Only enable stat-changing buttons if the proper setting is on
		this.gameObject.SetActive(OptionsGlobal.options["customVitalStatistics"]);
	}
	
	void Update() {
		if (buttonPressed) {
			incrementTimer -= Time.deltaTime;
			if (incrementTimer <= 0) {
				ChangeStat();
				incrementTimer = incrementTimerMax;
			}
		}
	}
	
	private void ChangeStat() {
		if (increaseValue && SonicVsZonikVitalStatistics.abilities[abilityToChange] <= 99) {
			SonicVsZonikVitalStatistics.abilities[abilityToChange]++;
		}
		else if (SonicVsZonikVitalStatistics.abilities[abilityToChange] > 0) {
			SonicVsZonikVitalStatistics.abilities[abilityToChange]--;
		}
	}
	
	public void OnPointerDown(PointerEventData eventData){
		buttonPressed = true;
	}
	 
	public void OnPointerUp(PointerEventData eventData){
		buttonPressed = false;
		incrementTimer = 0;
	}
}
