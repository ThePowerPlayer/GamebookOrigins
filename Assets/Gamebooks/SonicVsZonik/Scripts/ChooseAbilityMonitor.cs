using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ChooseAbilityMonitor : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private string ability;
	public DiceRollManager DiceRollScript;
	private TMP_Text currentText;
	private int abilityValue;
	
	void Start() {
		currentText = transform.GetChild(0).GetComponent<TMP_Text>();
		currentText.text = "";
	}
	
	void Update() {
		abilityValue = SonicVsZonikVitalStatistics.abilities[ability];
		currentText.text = abilityValue.ToString();
	}
	
	public void OnPointerClick(PointerEventData eventData)
    {
		DiceRollScript.SelectAbility(ability);	
    }
}