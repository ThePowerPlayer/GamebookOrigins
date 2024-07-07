using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetStatisticsButton : MonoBehaviour
{
	public AssignVitalStatistics StatManager;
    private Button button;
	
	void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}
	
	void Update() {
		if (OptionsGlobal.options["customVitalStatistics"]) {
			button.interactable = true;
		}
		else {
			button.interactable = StatManager.stat3Assigned;
		}
	}
	
    private void TaskOnClick() {
		StatManager.ResetStatistics();
	}
}
