using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVZGame = SonicVsZonikGame;
using SVZText = SonicVsZonikGameText;
using SVZStats = SonicVsZonikVitalStatistics;

public class DiceRollManager : MonoBehaviour
{
	[SerializeField] private GameObject DiceRoll;
	[SerializeField] private GameObject MonitorDice;
	[SerializeField] private GameObject MonitorAbility;
	[SerializeField] private GameObject MonitorTails;
	private int mostRecentIndex;
	public static bool diceMode;
	
    void Start()
    {
		mostRecentIndex = 0;
		diceMode = false;
		DiceRoll.SetActive(false);
    }
	
	void ResetMonitor(GameObject Monitor, int i) {
		Monitor.GetComponent<DiceRollMonitor>().ResetMonitor(i);
	}
	
    void Update()
    {
        if (SVZGame.index != mostRecentIndex) {
			mostRecentIndex = SVZGame.index;
			// Update monitor values for dice sections
			// TODO: Set proper values to monitors, including random dice roll
			// TODO: Reset sprites for monitors
			// TODO: Properly hide choice buttons when DiceRoll GameObject is visible
			if (SVZText.sectionLibrary[SVZGame.index].diceSection) {
				DiceRoll.SetActive(true);
				diceMode = true;
				
				ResetMonitor(MonitorDice, SVZText.sectionLibrary[SVZGame.index].diceGoal);
				ResetMonitor(MonitorAbility, SVZStats.abilities[SVZText.sectionLibrary[SVZGame.index].diceAbility]);
				ResetMonitor(MonitorTails, SVZText.sectionLibrary[SVZGame.index].tailsValue);
			}
		}
    }
}