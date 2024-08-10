using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityRect : MonoBehaviour, IPointerDownHandler
{
	public string gamebook;
	public string ability;
	public AssignVitalStatistics StatManager;
	
    void Awake() {
		if (!OptionsGlobal.options["customVitalStatistics"]) {
			bool hasHistory = (SonicVsZonikSectionLogic.sectionHistory != null
				&& SonicVsZonikSectionLogic.sectionHistory.Count > 0);
			if (!hasHistory && gamebook == "SonicVsZonik") {
				SonicVsZonikVitalStatistics.abilities[ability] = 0;
			}
		}
	}
	
	public void OnPointerDown(PointerEventData eventData){
		if (!OptionsGlobal.options["customVitalStatistics"]) {
			if (StatManager.assignments[ability] == false) {
				StatManager.assignments[ability] = true;
				if (!StatManager.stat1Assigned) {
					SonicVsZonikVitalStatistics.abilities[ability] = 5;
					StatManager.stat1Assigned = true;
				}
				else if (!StatManager.stat2Assigned) {
					SonicVsZonikVitalStatistics.abilities[ability] = 4;
					StatManager.stat2Assigned = true;
				}
				else if (!StatManager.stat3Assigned) {
					SonicVsZonikVitalStatistics.abilities[ability] = 3;
					StatManager.stat3Assigned = true;
					if (gamebook == "SonicVsZonik") {
						SonicVsZonikMenu.allStatsAssigned = true;
					}
					StatManager.SetRemainingStatistics();
				}
			}
		}
	}
}