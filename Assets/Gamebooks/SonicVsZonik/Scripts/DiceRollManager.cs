using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SVZGame = SonicVsZonikGame;
using SVZText = SonicVsZonikGameText;
using SVZStats = SonicVsZonikVitalStatistics;

public class DiceRollManager : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip DiceRollSuccess;
	[SerializeField] private AudioClip DiceRollFail;
	
	[SerializeField] private SonicVsZonikGame SVZGameScript;
	[SerializeField] private SonicVsZonikSectionLogic SVZLogicScript;
	
	[SerializeField] private AudioSource SFXAudioSource;
	[SerializeField] private AudioClip EnemyHit;
	[SerializeField] private AudioClip EnemyDestroyed;
	
	[SerializeField] private GameObject DiceRoll;
	[SerializeField] private GameObject MonitorDice;
	[SerializeField] private GameObject MonitorDice2;
	[SerializeField] private GameObject MonitorAbility;
	[SerializeField] private GameObject MonitorTails;
	[SerializeField] private GameObject MonitorFightingScore;
	[SerializeField] private DiceRollMonitor MonitorDiceScript;
	[SerializeField] private DiceRollMonitor MonitorDice2Script;
	[SerializeField] private DiceRollMonitor MonitorAbilityScript;
	[SerializeField] private DiceRollMonitor MonitorTailsScript;
	[SerializeField] private DiceRollMonitor MonitorFightingScoreScript;
	[SerializeField] private GameObject FirstPlus;
	[SerializeField] private GameObject SecondPlus;
	[SerializeField] private GameObject EqualsObj;
	[SerializeField] private GameObject ThumbsUp;
	[SerializeField] private ThumbsUp ThumbsUpScript;
	[SerializeField] private GameObject GoalValueSprite;
	[SerializeField] private GameObject Sum;
	[SerializeField] private GameObject ComparisonSymbol;
	[SerializeField] private GameObject GoalValue;
	[SerializeField] private GameObject ClickRect;
	
	[SerializeField] private GameObject ChooseAbilityMenu;
	[SerializeField] private GameObject MonitorChooseSpeed;
	[SerializeField] private GameObject MonitorChooseAgility;
	[SerializeField] private GameObject MonitorChooseStrength;
	[SerializeField] private GameObject MonitorChooseCoolness;
	[SerializeField] private GameObject MonitorChooseQuickWits;
	[SerializeField] private GameObject MonitorChooseGoodLooks;
	
	public static bool diceMode;
	public static bool fightMode;
	public static bool chooseAbilityMode;
	public static bool diceRollComplete;
	private int mostRecentIndex;
	
	private bool usesAbility;
	private bool usesTails;
	private bool usesTwoDice;
	public static bool allMonitorsBroken;
	
	public static bool diceBeingRolled;
	private int timesDiceRolled;
	public static bool enemyTurn;
	private int numEnemyAttacks;
	private float sumRoutineTimer;
	private const float sumRoutineTimerMax = 2f;
	private int sum;
	private int goalValue;
	public static bool rollSuccess;
	
	public Queue<SVZText.Enemy> currentEnemyList = new Queue<SVZText.Enemy>();
	
	// Pass by value, NOT by reference
	public Queue<SVZText.Enemy> NewQueue(Queue<SVZText.Enemy> oldQueue) {
		Queue<SVZText.Enemy> newQueue = new Queue<SVZText.Enemy>();
		foreach (SVZText.Enemy enemy in oldQueue) {
			SVZText.Enemy newEnemy = new SVZText.Enemy {
				name = enemy.name,
				hp = enemy.hp,
				fightingScore = enemy.fightingScore,
				staggeredAttacks = enemy.staggeredAttacks,
				attacksPerTurn = enemy.attacksPerTurn
			};
			newQueue.Enqueue(newEnemy);
		}
		return newQueue;
	}
	
    void Start()
    {
		mostRecentIndex = 0;
		diceMode = false;
		chooseAbilityMode = false;
		DiceRoll.SetActive(false);
		ChooseAbilityMenu.SetActive(false);
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
	
	private void OpenAbilityMenu() {
		chooseAbilityMode = true;
		DiceRoll.SetActive(false);
		ChooseAbilityMenu.SetActive(true);
		if (mostRecentIndex != 129) {
			MonitorChooseSpeed.SetActive(true);
			MonitorChooseAgility.SetActive(true);
			MonitorChooseStrength.SetActive(true);
			MonitorChooseCoolness.SetActive(true);
			MonitorChooseQuickWits.SetActive(true);
			MonitorChooseGoodLooks.SetActive(true);
		}
		else {
			MonitorChooseSpeed.SetActive(true);
			MonitorChooseAgility.SetActive(false);
			MonitorChooseStrength.SetActive(true);
			MonitorChooseCoolness.SetActive(false);
			MonitorChooseQuickWits.SetActive(false);
			MonitorChooseGoodLooks.SetActive(false);
		}
	}
	
	public void SelectAbility(string ability) {
		chooseAbilityMode = false;
		ChooseAbilityMenu.SetActive(false);
		SVZText.sectionLibrary[mostRecentIndex].diceAbility = ability;
		SetFirstDiceRoll();
	}
	
	private void SetMonitorsActive() {
		// Change ability depending on if die is rolled twice
		string currentAbility = "";
		if (timesDiceRolled == 0 || fightMode) {
			currentAbility = SVZText.sectionLibrary[mostRecentIndex].diceAbility;
		}
		else {
			currentAbility = SVZText.sectionLibrary[mostRecentIndex].diceAbility2;
		}
		
		if (enemyTurn) {
			MonitorFightingScore.SetActive(true);
			ResetMonitor(MonitorFightingScore, currentEnemyList.Peek().fightingScore, timesDiceRolled);
		}
		else {
			MonitorFightingScore.SetActive(false);
		}
		
		//Debug.Log("timesDiceRolled = " + timesDiceRolled + ", currentAbility = " + currentAbility);
		
		usesAbility = (!string.IsNullOrEmpty(currentAbility));
		if (!enemyTurn && usesAbility) {
			MonitorAbility.SetActive(true);
			ResetMonitor(MonitorAbility, SVZStats.abilities[currentAbility], timesDiceRolled);
		}
		else {
			MonitorAbility.SetActive(false);
		}
		
		usesTails = (SVZText.sectionLibrary[mostRecentIndex].tailsSection);
		if (!enemyTurn && usesTails) {
			MonitorTails.SetActive(true);
			ResetMonitor(MonitorTails, SVZText.sectionLibrary[mostRecentIndex].tailsValue, timesDiceRolled);
		}
		else {
			MonitorTails.SetActive(false);
		}
		
		usesTwoDice = (SVZText.sectionLibrary[mostRecentIndex].twoDice);
		if (!enemyTurn && usesTwoDice) {
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
		if (enemyTurn) {
			// Dice + enemy's fighting score
			FirstPlus.SetActive(true);
			SecondPlus.SetActive(false);
			UpdatePosX(MonitorDice, -230);
			UpdatePosX(FirstPlus, -115);
			UpdatePosX(MonitorFightingScore, -5);
			UpdatePosX(EqualsObj, 100);
			UpdatePosX(Sum, 190);
			UpdatePosX(ThumbsUp, 190);
			UpdatePosX(GoalValueSprite, 190);
			UpdatePosX(ComparisonSymbol, 280);
			UpdatePosX(GoalValue, 370);
			
			sum = MonitorDiceScript.monitorValue
			+ currentEnemyList.Peek().fightingScore;
		}
		else if (usesTails) {
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
			
			if (mostRecentIndex == 214 && SVZStats.SonicsStuff.Contains("Chaos Emerald")) {
				MonitorDiceScript.monitorValue += 2;
				MonitorAbilityScript.monitorValue += 2;
			}
			if (!SonicVsZonikSectionLogic.zonikCrashLanded) {
				MonitorDiceScript.monitorValue--;
				MonitorAbilityScript.monitorValue--;
			}
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
		if (SVZText.sectionLibrary[mostRecentIndex].fightSection) {
			if (!enemyTurn) {
				goalValue = currentEnemyList.Peek().fightingScore;
			}
			else {
				goalValue = 11;
			}
		}
		else {
			goalValue = SVZText.sectionLibrary[mostRecentIndex].diceGoal;
		}
		
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
		
		if (fightMode) {
			Debug.Log("Current enemy HP = " + SVZText.sectionLibrary[mostRecentIndex].enemyList.Peek().hp);
		}
		
		if (enemyTurn || mostRecentIndex == 171) {
			rollSuccess = !rollSuccess;
			ThumbsUpScript.thumbPointsUp = !ThumbsUpScript.thumbPointsUp;
		}
	}
	
	private bool CheckAllMonitorsBroken() {
		if (enemyTurn) {
			return (MonitorDiceScript.monitorBroken
				&& MonitorFightingScoreScript.monitorBroken);
		}
		else if (usesTails) {
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
		if (SVZText.sectionLibrary[mostRecentIndex].fightSection) {
			SVZText.sectionLibrary[mostRecentIndex].diceSection = true;
			fightMode = true;
			enemyTurn = false;
			numEnemyAttacks = 0;
			
			// Pass by value, NOT by reference
			// (so that enemy HP is automatically reset upon leaving the section)
			Debug.Log("Setting first dice roll...");
			if (SVZText.sectionLibrary[mostRecentIndex].enemyList != null
				&& SVZText.sectionLibrary[mostRecentIndex].enemyList.Count > 0) {
				currentEnemyList = NewQueue(SVZText.sectionLibrary[mostRecentIndex].enemyList);
			}
			else {
				currentEnemyList = new Queue<SVZText.Enemy>();
			}
		}
		
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
	
	private void RollDice() {
		if (rollSuccess) {
			audioSource.clip = DiceRollSuccess;
		}
		else {
			audioSource.clip = DiceRollFail;
		}
		audioSource.Play();
		
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
	
	public void SkipDiceRoll() {
		sumRoutineTimer = 0;
	}
	
	private void FinishDiceRoll() {
		diceBeingRolled = false;
		ThumbsUpScript.visible = false;
		
		timesDiceRolled++;
		//Debug.Log("timesDiceRolled = " + timesDiceRolled
		//	+ ", numDiceRolls = " + SVZText.sectionLibrary[mostRecentIndex].numDiceRolls);
		
		// Decrease enemy HP if Sonic has hit it
		if (fightMode && rollSuccess && !enemyTurn) {
			SFXAudioSource.clip = EnemyHit;
			SFXAudioSource.Play();
			currentEnemyList.Peek().hp--;
		}
		// Make Sonic get hit by an enemy
		if (fightMode && !rollSuccess && enemyTurn) {
			SVZLogicScript.GetHit();
		}
		
		bool enemyDefeated = (fightMode && currentEnemyList.Peek().hp == 0);
		SVZLogicScript.EndOfDiceRollLogic(mostRecentIndex, rollSuccess, sum, enemyDefeated);
		if (SonicVsZonikSectionLogic.gameOver) {
			fightMode = false;
			enemyTurn = false;
			numEnemyAttacks = 0;
			DiceRoll.SetActive(false);
		}
		
		if (fightMode) {
			numEnemyAttacks++;
			bool enemyStaggered = currentEnemyList.Peek().staggeredAttacks;
			bool attackQuotaMet = (numEnemyAttacks == currentEnemyList.Peek().attacksPerTurn);
			
			// If current turn is Sonic's:
			if (!enemyTurn) {
				// Allow non-staggered enemies to attack right away.
				// Wait for enemies with staggered attack patterns.
				if (!enemyStaggered || (enemyStaggered && attackQuotaMet)) {
					numEnemyAttacks = 0;
					enemyTurn = !enemyTurn;
				}
			}
			// If current turn is enemy's:
			else if (enemyTurn) {
				// Allow Sonic to attack right away against staggered enemies.
				// Allow non-staggered enemies to attack multiple times.
				if (enemyStaggered || (!enemyStaggered && attackQuotaMet)) {
					numEnemyAttacks = 0;
					enemyTurn = !enemyTurn;
				}
			}
		}
		
		// Decide whether to keep rolling
		bool allDiceRolled = (!fightMode
			&& timesDiceRolled == SVZText.sectionLibrary[mostRecentIndex].numDiceRolls);
		bool allEnemiesDefeated = false;
		if (enemyDefeated) {
			SFXAudioSource.clip = EnemyDestroyed;
			SFXAudioSource.Play();
			currentEnemyList.Dequeue();
			enemyTurn = false;
			numEnemyAttacks = 0;
		}
		if (currentEnemyList.Count == 0) {
			allEnemiesDefeated = true;
		}
		
		// Leave dice mode and show available section buttons
		if (allDiceRolled || allEnemiesDefeated) {
			fightMode = false;
			SVZText.sectionLibrary[mostRecentIndex].rollComplete = true;
			SVZText.sectionLibrary[mostRecentIndex].rollSuccess = rollSuccess;
			SVZGameScript.ChangeButtons();
			diceMode = false;
			DiceRoll.SetActive(false);
			// Obtain tweezers on Section 138 only if BOTH dice rolls succeed
			if (mostRecentIndex == 138 && rollSuccess) {
				SVZLogicScript.ObtainItem("Tweezers");
			}
		}
		else {
			SetDiceRoll();
		}
	}
	
    void Update()
    {	
		if (SVZGame.index != mostRecentIndex) {
			mostRecentIndex = SVZGame.index;
			diceMode = false;
			fightMode = false;
			chooseAbilityMode = false;
			enemyTurn = false;
			if (SVZText.sectionLibrary[mostRecentIndex].chooseAbility) {
				OpenAbilityMenu();
			}
			else {
				ChooseAbilityMenu.SetActive(false);
				SetFirstDiceRoll();
			}
		}
		
		// Activate sum routine when all monitors are broken
		allMonitorsBroken = CheckAllMonitorsBroken();
		
		// Visualize the dice roll to the player and display sum value
		if (diceMode && allMonitorsBroken && !diceBeingRolled) {
			RollDice();
		}
		
		// Display thumbs-up icon on screen (unless the player clicks to skip it)
		if (diceBeingRolled) {
			ClickRect.SetActive(true);
			
			if (sumRoutineTimer > 0) {
				sumRoutineTimer -= Time.deltaTime;
			}
			else {
				sumRoutineTimer = 0;
				FinishDiceRoll();
			}
		}
		else {
			ClickRect.SetActive(false);
		}
    }
}