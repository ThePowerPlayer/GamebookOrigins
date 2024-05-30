using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stats = SonicVsZonikVitalStatistics;

public class BuyExtraLife : MonoBehaviour
{
    private Button button;
	
	void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}

    void Update() {
		button.interactable = (Stats.rings >= 100);
	}
	
	private void TaskOnClick() {
		Stats.rings -= 100;
		Stats.lives++;
	}
}
