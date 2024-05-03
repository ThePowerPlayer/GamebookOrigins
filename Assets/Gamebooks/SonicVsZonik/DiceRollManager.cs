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
	[SerializeField] private GameObject MonitorDice2;
	[SerializeField] private GameObject MonitorAbility;
	[SerializeField] private GameObject MonitorTails;
	[SerializeField] private DiceRollMonitor MonitorDiceScript;
	[SerializeField] private DiceRollMonitor MonitorDice2Script;
	[SerializeField] private DiceRollMonitor MonitorAbilityScript;
	[SerializeField] private DiceRollMonitor MonitorTailsScript;
	[SerializeField] private GameObject FirstPlus;
	[SerializeField] private GameObject SecondPlus;
	[SerializeField] private GameObject EqualsObj;
	[SerializeField] private GameObject Sum;
	[SerializeField] private GameObject ComparisonSymbol;
	[SerializeField] private GameObject GoalValue;
	
	public static bool diceMode;
	public static bool diceRollComplete;
	private int mostRecentIndex;
	
	private bool usesAbility;
	private bool usesTails;
	private bool usesTwoDice;
	public static bool allMonitorsBroken;
	
	public static bool diceBeingRolled;
	private float sumRoutineTimer;
	private const float sumRoutineTimerMax = 1.5f;
	private int sum;
	private int goalValue;
	public static bool rollSuccess;
	
    void Start()
    {
		mostRecentIndex = 0;
		diceMode = false;
		DiceRoll.SetActive(false);
		sumRoutineTimer = sumRoutineTimerMax;
    }
	
	private void ResetMonitor(GameObject Monitor, int i) {
		Monitor.GetComponent<DiceRollMonitor>().ResetMonitor(i);
	}
	
	private void UpdatePosX(GameObject obj, float x) {
		// Change RectTransform, NOT regular transform.position
		RectTransform ObjRectTransform = obj.GetComponent<RectTransform>();
		ObjRectTransform.anchoredPosition =
			new Vector2(x, ObjRectTransform.anchoredPosition.y);
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
				sumRoutineTimer = sumRoutineTimerMax;
				
				ResetMonitor(MonitorDice, Random.Range(1, 7));
				
				// Include ability and Tails monitors (if applicable)
				usesAbility = (!string.IsNullOrEmpty(SVZText.sectionLibrary[mostRecentIndex].diceAbility));
				if (usesAbility) {
					MonitorAbility.SetActive(true);
					ResetMonitor(MonitorAbility, SVZStats.abilities[SVZText.sectionLibrary[mostRecentIndex].diceAbility]);
				}
				else {
					MonitorAbility.SetActive(false);
				}
				
				usesTails = (SVZText.sectionLibrary[mostRecentIndex].tailsSection);
				if (usesTails) {
					MonitorTails.SetActive(true);
					ResetMonitor(MonitorTails, SVZText.sectionLibrary[mostRecentIndex].tailsValue);
				}
				else {
					MonitorTails.SetActive(false);
				}
				
				usesTwoDice = (SVZText.sectionLibrary[mostRecentIndex].twoDice);
				if (usesTwoDice) {
					MonitorDice2.SetActive(true);
					ResetMonitor(MonitorDice2, Random.Range(1, 7));
				}
				else {
					MonitorDice2.SetActive(false);
				}
				
				// Update positions of all monitors depending on which are active
				// Calculate sum of monitor values
				if (usesTails) {
					// Dice + ability + Tails
					FirstPlus.SetActive(true);
					SecondPlus.SetActive(true);
					UpdatePosX(MonitorDice, -325);
					UpdatePosX(FirstPlus, -225);
					UpdatePosX(MonitorAbility, -125);
					UpdatePosX(SecondPlus, -25);
					UpdatePosX(MonitorTails, 75);
					UpdatePosX(EqualsObj, 175);
					UpdatePosX(Sum, 260);
					UpdatePosX(ComparisonSymbol, 340);
					UpdatePosX(GoalValue, 420);
					
					sum = MonitorDiceScript.monitorValue
					+ MonitorAbilityScript.monitorValue
					+ MonitorTailsScript.monitorValue;
				}
				else if (usesAbility && usesTwoDice) {
					// Dice + dice + ability
					FirstPlus.SetActive(true);
					SecondPlus.SetActive(true);
					UpdatePosX(MonitorDice, -325);
					UpdatePosX(FirstPlus, -225);
					UpdatePosX(MonitorDice2, -125);
					UpdatePosX(SecondPlus, -25);
					UpdatePosX(MonitorAbility, 75);
					UpdatePosX(EqualsObj, 175);
					UpdatePosX(Sum, 260);
					UpdatePosX(ComparisonSymbol, 340);
					UpdatePosX(GoalValue, 420);
					
					sum = MonitorDiceScript.monitorValue
					+ MonitorDice2Script.monitorValue
					+ MonitorAbilityScript.monitorValue;
				}
				else if (usesAbility) {
					// Dice + ability
					FirstPlus.SetActive(true);
					SecondPlus.SetActive(false);
					UpdatePosX(MonitorDice, -230);
					UpdatePosX(FirstPlus, -115);
					UpdatePosX(MonitorAbility, -5);
					UpdatePosX(EqualsObj, 100);
					UpdatePosX(Sum, 190);
					UpdatePosX(ComparisonSymbol, 280);
					UpdatePosX(GoalValue, 370);
					
					sum = MonitorDiceScript.monitorValue
					+ MonitorAbilityScript.monitorValue;
				}
				else if (usesTwoDice) {
					// Dice + dice
					FirstPlus.SetActive(true);
					SecondPlus.SetActive(false);
					UpdatePosX(MonitorDice, -230);
					UpdatePosX(FirstPlus, -115);
					UpdatePosX(MonitorDice2, -5);
					UpdatePosX(EqualsObj, 100);
					UpdatePosX(Sum, 190);
					UpdatePosX(ComparisonSymbol, 280);
					UpdatePosX(GoalValue, 370);
					
					sum = MonitorDiceScript.monitorValue
					+ MonitorDice2Script.monitorValue;
				}
				else {
					// Dice only
					FirstPlus.SetActive(false);
					SecondPlus.SetActive(false);
					UpdatePosX(MonitorDice, -140);
					UpdatePosX(EqualsObj, -30);
					UpdatePosX(Sum, 50);
					UpdatePosX(ComparisonSymbol, 140);
					UpdatePosX(GoalValue, 240);
					
					sum = MonitorDiceScript.monitorValue;
				}
				
				// Compare sum to goal value
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
		if (usesTails) {
			allMonitorsBroken = (MonitorDiceScript.monitorBroken
				&& MonitorAbilityScript.monitorBroken
				&& MonitorTailsScript.monitorBroken);
		}
		else if (usesAbility && usesTwoDice) {
			allMonitorsBroken = (MonitorDiceScript.monitorBroken
				&& MonitorDice2Script.monitorBroken
				&& MonitorAbilityScript.monitorBroken);
		}
		else if (usesAbility) {
			allMonitorsBroken = (MonitorDiceScript.monitorBroken
				&& MonitorAbilityScript.monitorBroken);
		}
		else if (usesTwoDice) {
			allMonitorsBroken = (MonitorDiceScript.monitorBroken
				&& MonitorDice2Script.monitorBroken);
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
				SVZGameScript.ChangeButtonsDiceRoll(rollSuccess);
				diceMode = false;
				DiceRoll.SetActive(false);
			}
		}
    }
}