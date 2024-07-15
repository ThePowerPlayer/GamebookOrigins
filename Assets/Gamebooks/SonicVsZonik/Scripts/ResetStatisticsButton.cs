using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetStatisticsButton : MonoBehaviour
{
	public AssignVitalStatistics StatManager;
    private Button button;
	[SerializeField] private GameObject maxButton;
	
	// Only enable "Max Statistics" button if statistics can be freely customized
	void Awake() {
		maxButton.SetActive(OptionsGlobal.options["customVitalStatistics"]);
	}
	
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
