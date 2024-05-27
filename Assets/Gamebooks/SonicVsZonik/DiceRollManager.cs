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
	[SerializeField] private GameObject ThumbsUp;
	[SerializeField] private ThumbsUp ThumbsUpScript;
	[SerializeField] private GameObject GoalValueSprite;
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
	private int timesDiceRolled;
	private float sumRoutineTimer;
	private const float sumRoutineTimerMax = 2f;
	private int sum;
	private int goalValue;
	public static bool rollSuccess;
	
    void Start()
    {
		mostRecentIndex = 0;
		diceMode = false;
		DiceRoll.SetActive(false);
		sumRoutineTimer = sumRoutineTimerMax;
		timesDiceRolled = 0;
    }
	
	private void ResetMonitor(GameObject Monitor, int i, int timesDiceRolled) {
		Monitor.GetComponent<DiceRollMonitor>().ResetMonitor(i, timesDiceRolled);
	}
	
	private void UpdatePosX(GameObject obj, float x) {
		// Change RectTransform, NOT regular transform.position
		RectTransform ObjRectTransform = obj.GetComponent<RectTransform>();
		ObjRectTransform.anchoredPosition =
			new Vector2(x, ObjRectTransform.anchoredPosition.y);
	}
	
	private void SetMonitorsActive() {
		// Change ability depending on if die is rolled twice
		string currentAbility = "";
		if (timesDiceRolled == 0) {
			currentAbility = SVZText.sectionLibrary[mostRecentIndex].diceAbility;
		}
		else {
			currentAbility = SVZText.sectionLibrary[mostRecentIndex].diceAbility2;
		}
		
		Debug.Log("timesDiceRolled = " + timesDiceRolled + ", currentAbility = " + currentAbility);
		
		usesAbility = (!string.IsNullOrEmpty(currentAbility));
		if (usesAbility) {
			MonitorAbility.SetActive(true);
			ResetMonitor(MonitorAbility, SVZStats.abilities[currentAbility], timesDiceRolled);
		}
		else {
			MonitorAbility.SetActive(false);
		}
		
		usesTails = (SVZText.sectionLibrary[mostRecentIndex].tailsSection);
		if (usesTails) {
			MonitorTails.SetActive(true);
			ResetMonitor(MonitorTails, SVZText.sectionLibrary[mostRecentIndex].tailsValue, timesDiceRolled);
		}
		else {
			MonitorTails.SetActive(false);
		}
		
		usesTwoDice = (SVZText.sectionLibrary[mostRecentIndex].twoDice);
		if (usesTwoDice) {
			MonitorDice2.SetActive(true);
			ResetMonitor(MonitorDice2, Random.Range(1, 7), timesDiceRolled);
		}
		else {
			MonitorDice2.SetActive(false);
		}
	}
	
	private void SetMonitorPositions() {
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
			UpdatePosX(ThumbsUp, 260);
			UpdatePosX(GoalValueSprite, 260);
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
			UpdatePosX(ThumbsUp, 260);
			UpdatePosX(GoalValueSprite, 260);
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
			UpdatePosX(ThumbsUp, 190);
			UpdatePosX(GoalValueSprite, 190);
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
			UpdatePosX(ThumbsUp, 190);
			UpdatePosX(GoalValueSprite, 190);
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
			UpdatePosX(ThumbsUp, 50);
			UpdatePosX(GoalValueSprite, 50);
			UpdatePosX(ComparisonSymbol, 140);
			UpdatePosX(GoalValue, 240);
			
			sum = MonitorDiceScript.monitorValue;
		}
	}
	
	private void DetermineRollSuccess() {
		// Compare sum to goal value
		goalValue = SVZText.sectionLibrary[mostRecentIndex].diceGoal;
		Sum.GetComponent<TMP_Text>().text = sum.ToString();
		GoalValue.GetComponent<TMP_Text>().text = goalValue.ToString();
		if (sum >= goalValue) {
			rollSuccess = true;
			ThumbsUpScript.thumbPointsUp = true;
			ComparisonSymbol.GetComponent<TMP_Text>().text = "≥";
		}
		else {
			rollSuccess = false;
			ThumbsUpScript.thumbPointsUp = false;
			ComparisonSymbol.GetComponent<TMP_Text>().text = "<";
		}
	}
	
	private bool CheckAllMonitorsBroken() {
		if (usesTails) {
			return (MonitorDiceScript.monitorBroken
				&& MonitorAbilityScript.monitorBroken
				&& MonitorTailsScript.monitorBroken);
		}
		else if (usesAbility && usesTwoDice) {
			return (MonitorDiceScript.monitorBroken
				&& MonitorDice2Script.monitorBroken
				&& MonitorAbilityScript.monitorBroken);
		}
		else if (usesAbility) {
			return (MonitorDiceScript.monitorBroken
				&& MonitorAbilityScript.monitorBroken);
		}
		else if (usesTwoDice) {
			return (MonitorDiceScript.monitorBroken
				&& MonitorDice2Script.monitorBroken);
		}
		else {
			return MonitorDiceScript.monitorBroken;
		}
	}
	
	private void SetDiceRoll() {
		// Update monitor values for dice sections
		diceBeingRolled = false;
		rollSuccess = false;
		sumRoutineTimer = sumRoutineTimerMax;
		
		ResetMonitor(MonitorDice, Random.Range(1, 7), timesDiceRolled);
		
		// Include ability and Tails monitors (if applicable)
		// Also calculate sum of dice rolls
		SetMonitorsActive();
		SetMonitorPositions();
		
		// Determine whether roll is successful
		DetermineRollSuccess();
		
		// Hide sum and comparison symbol before all monitors are broken
		Sum.GetComponent<TMP_Text>().enabled = false;
		ComparisonSymbol.GetComponent<TMP_Text>().enabled = false;
	}
	
	private void SetFirstDiceRoll() {
		if (SVZGame.index != mostRecentIndex) {
			mostRecentIndex = SVZGame.index;
			
			if (SVZText.sectionLibrary[mostRecentIndex].diceSection) {
				DiceRoll.SetActive(true);
				diceMode = true;
				timesDiceRolled = 0;
				SetDiceRoll();
			}
			else {	
				DiceRoll.SetActive(false);
				diceMode = false;
			}
		}
	}
	
	private void RollDice() {
		if (diceMode && allMonitorsBroken && !diceBeingRolled) {
			diceBeingRolled = true;
			Sum.GetComponent<TMP_Text>().enabled = true;
			int monitorValue = int.Parse(Sum.GetComponent<TMP_Text>().text);
			if (monitorValue < 10) {
				Sum.GetComponent<TMP_Text>().fontSize = 72;
			}
			else {
				Sum.GetComponent<TMP_Text>().fontSize = 58;
			}
			ThumbsUpScript.xExp = 0;
			ThumbsUpScript.sizeMultiplier = 0;
			ThumbsUpScript.startedShrinking = false;
			ThumbsUpScript.visibilityTimer = 1f;
			ThumbsUpScript.visible = true;
			ComparisonSymbol.GetComponent<TMP_Text>().enabled = true;
		}
	}
	
    void Update()
    {	
		SetFirstDiceRoll();
		
		// Activate sum routine when all monitors are broken
		allMonitorsBroken = CheckAllMonitorsBroken();
		
		// Visualize the dice roll to the player and display sum value
		RollDice();
		
		// Display thumbs-up icon on screen (unless the player clicks to skip it)
		if (diceBeingRolled) {
			// if (player clicks on dice roll area) {
				//sumRoutineTimer = 0;
			//}
			
			if (sumRoutineTimer > 0) {
				sumRoutineTimer -= Time.deltaTime;
			}
			else {
				sumRoutineTimer = 0;
				diceBeingRolled = false;
				ThumbsUpScript.visible = false;
				
				// Decide whether to keep rolling
				timesDiceRolled++;
				Debug.Log("timesDiceRolled = " + timesDiceRolled
					+ ", numDiceRolls = " + SVZText.sectionLibrary[mostRecentIndex].numDiceRolls);
				
				bool isFightSection = SVZText.sectionLibrary[mostRecentIndex].fightSection;
				if ((isFightSection && SVZText.sectionLibrary[mostRecentIndex].enemyHPCurrent > 0)
					|| (!isFightSection && timesDiceRolled == SVZText.sectionLibrary[mostRecentIndex].numDiceRolls)) {
					// Leave dice mode and show available section buttons
					SVZText.sectionLibrary[mostRecentIndex].rollComplete = true;
					SVZText.sectionLibrary[mostRecentIndex].rollSuccess = rollSuccess;
					SVZGameScript.ChangeButtons();
					diceMode = false;
					DiceRoll.SetActive(false);
				}
				else {
					SetDiceRoll();
				}
			}
		}
    }
}