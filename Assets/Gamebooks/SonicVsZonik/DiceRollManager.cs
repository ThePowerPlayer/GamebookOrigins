using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SVZGame = SonicVsZonikGame;
using SVZText = SonicVsZonikGameText;
using SVZStats = SonicVsZonikVitalStatistics;

public class DiceRollManager : MonoBehaviour
{
	[SerializeField] private GameObject DiceRoll;
	[SerializeField] private GameObject MonitorDice;
	[SerializeField] private GameObject MonitorAbility;
	[SerializeField] private GameObject MonitorTails;
	private DiceRollMonitor MonitorDiceScript;
	private DiceRollMonitor MonitorAbilityScript;
	private DiceRollMonitor MonitorTailsScript;
	[SerializeField] private GameObject Sum;
	[SerializeField] private GameObject ComparisonSymbol;
	[SerializeField] private GameObject GoalValue;
	
	public static bool diceMode;
	private int mostRecentIndex;
	
	private bool usesAbility;
	private bool usesTails;
	private bool allMonitorsBroken;
	
	private bool sumRoutine;
	private int sum;
	private int goalValue;
	
    void Start()
    {
		mostRecentIndex = 0;
		diceMode = false;
		DiceRoll.SetActive(false);
		MonitorDiceScript = MonitorDice.GetComponent<DiceRollMonitor>();
		MonitorAbilityScript = MonitorAbility.GetComponent<DiceRollMonitor>();
		MonitorTailsScript = MonitorTails.GetComponent<DiceRollMonitor>();
    }
	
	void ResetMonitor(GameObject Monitor, int i) {
		Monitor.GetComponent<DiceRollMonitor>().ResetMonitor(i);
	}
	
	void SumRoutine() {
		Debug.Log("Start sum routine");
		Sum.GetComponent<TMP_Text>().enabled = true;
		GoalValue.GetComponent<TMP_Text>().enabled = true;
		ComparisonSymbol.GetComponent<TMP_Text>().enabled = true;
	}
	
    void Update()
    {
        if (SVZGame.index != mostRecentIndex) {
			mostRecentIndex = SVZGame.index;
			// Update monitor values for dice sections
			if (SVZText.sectionLibrary[SVZGame.index].diceSection) {
				DiceRoll.SetActive(true);
				diceMode = true;
				
				ResetMonitor(MonitorDice, Random.Range(1, 7));
				
				// Include value of ability and Tails monitors (if applicable)
				Debug.Log("Dice ability of current section: " + SVZText.sectionLibrary[SVZGame.index].diceAbility);
				usesAbility = (SVZText.sectionLibrary[SVZGame.index].diceAbility != "");
				if (usesAbility) {
					ResetMonitor(MonitorAbility, SVZStats.abilities[SVZText.sectionLibrary[SVZGame.index].diceAbility]);
				}
				Debug.Log("Tails section: " + SVZText.sectionLibrary[SVZGame.index].tailsSection);
				usesTails = (SVZText.sectionLibrary[SVZGame.index].tailsSection);
				if (usesTails) {
					ResetMonitor(MonitorTails, SVZText.sectionLibrary[SVZGame.index].tailsValue);
				}
				
				// Calculate and display sum of monitor values
				sum = MonitorDice.GetComponent<DiceRollMonitor>().monitorValue
					+ MonitorAbility.GetComponent<DiceRollMonitor>().monitorValue;
				goalValue = SVZText.sectionLibrary[SVZGame.index].diceGoal;
				Sum.GetComponent<TMP_Text>().text = sum.ToString();
				GoalValue.GetComponent<TMP_Text>().text = goalValue.ToString();
				if (sum >= goalValue) {
					ComparisonSymbol.GetComponent<TMP_Text>().text = "≥";
				}
				else {
					ComparisonSymbol.GetComponent<TMP_Text>().text = "<";
				}
				Sum.GetComponent<TMP_Text>().enabled = false;
				GoalValue.GetComponent<TMP_Text>().enabled = false;
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
		
		Debug.Log("usesAbility: " + usesAbility
			+ ", usesTails: " + usesTails);
		Debug.Log("Dice: " + MonitorDiceScript.monitorBroken
			+ ", Ability: " + MonitorAbilityScript.monitorBroken
			+ ", Tails: " + MonitorTailsScript.monitorBroken);
		
		if (allMonitorsBroken && !sumRoutine) {
			sumRoutine = true;
			SumRoutine();
		}
    }
}