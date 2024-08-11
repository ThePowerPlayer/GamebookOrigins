using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AssignVitalStatistics : MonoBehaviour
{
	public Dictionary<string, bool> assignments = new Dictionary<string, bool>();
	
	public bool stat1Assigned;
	public bool stat2Assigned;
	public bool stat3Assigned;
	public string gamebook;
	public TMP_Text description;
	
    void Awake()
    {
		bool hasHistory = (SonicVsZonikSectionLogic.sectionHistory != null
			&& SonicVsZonikSectionLogic.sectionHistory.Count > 0);
		if (hasHistory) {
			SetAssignments(true);
		}
		else {
			SetAssignments(false);
		}
        
		if (OptionsGlobal.options["customVitalStatistics"]) {
			description.text = "Click the arrows to increase or decrease Sonic's abilities.";
		}
    }
	
	void Update()
	{
		if (!OptionsGlobal.options["customVitalStatistics"]) {
			if (!stat1Assigned) {
				description.text = "Click to assign Sonic's strongest ability (5 points).";
			}
			else if (!stat2Assigned) {
				description.text = "Click to assign Sonic's 2nd-strongest ability (4 points).";
			}
			else if (!stat3Assigned) {
				description.text = "Click to assign Sonic's 3rd-strongest ability (3 points).";
			}
			else {
				description.text = "Are these OK?\nClick the Reset Statistics button to start over.";
			}
		}
	}
	
	private void SetAssignments(bool assign) {
		stat1Assigned = assign;
		stat2Assigned = assign;
		stat3Assigned = assign;
		
		assignments["Speed"] = assign;
		assignments["Agility"] = assign;
		assignments["Strength"] = assign;
		assignments["Coolness"] = assign;
		assignments["Quick Wits"] = assign;
		assignments["Good Looks"] = assign;
	}
	
	public void SetRemainingStatistics() {
		foreach(KeyValuePair<string, bool> item in assignments)
		{
			// If an ability is still unassigned, set it to 2 by default
			if (item.Value == false) {
				if (gamebook == "SonicVsZonik") {
					SonicVsZonikVitalStatistics.abilities[item.Key] = 2;
				}
			}
		}
	}
	
    public void ResetStatistics() {
		SetAssignments(false);
		
		if (gamebook == "SonicVsZonik") {
			SonicVsZonikMenu.allStatsAssigned = false;
			SonicVsZonikVitalStatistics.abilities["Speed"] = 0;
			SonicVsZonikVitalStatistics.abilities["Agility"] = 0;
			SonicVsZonikVitalStatistics.abilities["Strength"] = 0;
			SonicVsZonikVitalStatistics.abilities["Coolness"] = 0;
			SonicVsZonikVitalStatistics.abilities["Quick Wits"] = 0;
			SonicVsZonikVitalStatistics.abilities["Good Looks"] = 0;
		}
	}
}