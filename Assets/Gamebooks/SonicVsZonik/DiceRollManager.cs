using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SVZGame = SonicVsZonikGame;
using SVZText = SonicVsZonikGameText;
using SVZStats = SonicVsZonikVitalStatistics;

public class DiceRollManager : MonoBehaviour
{
	[SerializeField] private SonicVsZonikGame SVZGameScript;
	[SerializeField] private GameObject DiceRoll;
	[SerializeField] private GameObject MonitorDice;
	[SerializeField] private GameObject MonitorAbility;
	[SerializeField] private GameObject MonitorTails;
	[SerializeField] private DiceRollMonitor MonitorDiceScript;
	[SerializeField] private DiceRollMonitor MonitorAbilityScript;
	[SerializeField] private DiceRollMonitor MonitorTailsScript;
	[SerializeField] private GameObject Sum;
	[SerializeField] private GameObject ComparisonSymbol;
	[SerializeField] private GameObject GoalValue;
	
	public static bool diceMode;
	public static bool diceRollComplete;
	private int mostRecentIndex;
	
	private bool usesAbility;
	private bool usesTails;
	public static bool allMonitorsBroken;
	
	public static bool diceBeingRolled;
	private float sumRoutineTimer;
	private int sum;
	private int goalValue;
	public static bool rollSuccess;
	
    void Start()
    {
		mostRecentIndex = 0;
		diceMode = false;
		DiceRoll.SetActive(false);
		sumRoutineTimer = 1.5f;
    }
	
	void ResetMonitor(GameObject Monitor, int i) {
		Monitor.GetComponent<DiceRollMonitor>().ResetMonitor(i);
	}
	
    void Update()
    {
        if (SVZGame.index != mostRecentIndex) {
			mostRecentIndex = SVZGame.index;
			
			if (SVZText.sectionLibrary[mostRecentIndex].diceSection) {
				// Update monitor values for dice sections
				DiceRoll.SetActive(true);
				diceMode = true;
				diceBeingRolled = false;
				rollSuccess = false;
				sumRoutineTimer = 1.5f;
				
				ResetMonitor(MonitorDice, Random.Range(1, 7));
				
				// Include value of ability and Tails monitors (if applicable)
				usesAbility = (SVZText.sectionLibrary[mostRecentIndex].diceAbility != "");
				if (usesAbility) {
					ResetMonitor(MonitorAbility, SVZStats.abilities[SVZText.sectionLibrary[mostRecentIndex].diceAbility]);
				}
				usesTails = (SVZText.sectionLibrary[mostRecentIndex].tailsSection);
				if (usesTails) {
					ResetMonitor(MonitorTails, SVZText.sectionLibrary[mostRecentIndex].tailsValue);
				}
				
				// Calculate and display sum of monitor values
				sum = MonitorDice.GetComponent<DiceRollMonitor>().monitorValue
					+ MonitorAbility.GetComponent<DiceRollMonitor>().monitorValue;
				goalValue = SVZText.sectionLibrary[mostRecentIndex].diceGoal;
				Sum.GetComponent<TMP_Text>().text = sum.ToString();
				GoalValue.GetComponent<TMP_Text>().text = goalValue.ToString();
				if (sum >= goalValue) {
					rollSuccess = true;
					ComparisonSymbol.GetComponent<TMP_Text>().text = "≥";
				}
				else {
					rollSuccess = false;
					ComparisonSymbol.GetComponent<TMP_Text>().text = "<";
				}
				Sum.GetComponent<TMP_Text>().enabled = false;
				ComparisonSymbol.GetComponent<TMP_Text>().enabled = false;
			}
			else {	
				DiceRoll.SetActive(false);
				diceMode = false;
			}
		}
		
		// Activate sum routine when all monitors are broken
		if (usesAbility && usesTails) {
			allMonitorsBroken = (MonitorDiceScript.monitorBroken
				&& MonitorAbilityScript.monitorBroken
				&& MonitorTailsScript.monitorBroken);
		}
		else if (usesAbility) {
			allMonitorsBroken = (MonitorDiceScript.monitorBroken
				&& MonitorAbilityScript.monitorBroken);
		}
		else {
			allMonitorsBroken = MonitorDiceScript.monitorBroken;
		}
		
		if (diceMode && allMonitorsBroken && !diceBeingRolled) {
			diceBeingRolled = true;
			Sum.GetComponent<TMP_Text>().enabled = true;
			ComparisonSymbol.GetComponent<TMP_Text>().enabled = true;
		}
		
		if (diceBeingRolled) {
			if (sumRoutineTimer > 0) {
				sumRoutineTimer -= Time.deltaTime;
			}
			else {
				// Leave dice mode and show available section buttons
				sumRoutineTimer = 0;
				diceBeingRolled = false;
				Debug.Log("Dice roll success: " + rollSuccess);
				SVZGameScript.ChangeButtonsDiceRoll(rollSuccess);
				diceMode = false;
				DiceRoll.SetActive(false);
			}
		}
    }
}