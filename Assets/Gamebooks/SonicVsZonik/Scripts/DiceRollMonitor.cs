using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using SVZGame = SonicVsZonikGame;
using SVZText = SonicVsZonikGameText;

public class DiceRollMonitor : MonoBehaviour, IPointerClickHandler
{
	private AudioSource audioSource;
	
	private UnityEngine.UI.Image iRenderer;
	[SerializeField] private Sprite BrokenMonitor;
	[SerializeField] private Sprite SpeedMonitor;
	[SerializeField] private Sprite AgilityMonitor;
	[SerializeField] private Sprite StrengthMonitor;
	[SerializeField] private Sprite CoolnessMonitor;
	[SerializeField] private Sprite QuickWitsMonitor;
	[SerializeField] private Sprite GoodLooksMonitor;
	[SerializeField] private Sprite DiceMonitor;
	[SerializeField] private Sprite TailsMonitor;
	[SerializeField] private Sprite FightingScoreMonitor;
	[SerializeField] private Sprite GoalMonitor;
	private Sprite currentSprite;
	
	public int monitorValue;
	public bool monitorBroken;
	private bool textAnimComplete;
	private TMP_Text currentText;
	private TextMeshProUGUI currentTextGUI;
	private float originalFontSize;
	
	private float x;
	private float y;
	private const int speed = 5;
	private const int height = 30;
	
	void Start() {
		audioSource = gameObject.GetComponent<AudioSource>();
		iRenderer = GetComponent<UnityEngine.UI.Image>();
		currentText = transform.GetChild(0).GetComponent<TMP_Text>();
		currentText.text = "";
		originalFontSize = currentText.fontSize;
	}
	
	public void ResetMonitor(int i, int timesDiceRolled) {
		monitorBroken = false;
		textAnimComplete = false;
		x = 0;
		y = 0;
		monitorValue = i;
		string currentAbility = "";
		if (timesDiceRolled == 0 || SVZText.sectionLibrary[SVZGame.index].fightSection) {
			currentAbility = SVZText.sectionLibrary[SVZGame.index].diceAbility;
		}
		else {
			currentAbility = SVZText.sectionLibrary[SVZGame.index].diceAbility2;
		}
		
		switch (gameObject.name) {
			case "MonitorDice":
				currentSprite = DiceMonitor;
				break;
			case "MonitorDice2":
				currentSprite = DiceMonitor;
				break;
			case "MonitorAbility":
				switch (currentAbility) {
					case "Speed":
						currentSprite = SpeedMonitor;
						break;
					case "Agility":
						currentSprite = AgilityMonitor;
						break;
					case "Strength":
						currentSprite = StrengthMonitor;
						break;
					case "Coolness":
						currentSprite = CoolnessMonitor;
						break;
					case "Quick Wits":
						currentSprite = QuickWitsMonitor;
						break;
					case "Good Looks":
						currentSprite = GoodLooksMonitor;
						break;
					case "Section 31":
						currentSprite = TailsMonitor;
						break;
				}
				break;
			case "MonitorTails":
				currentSprite = TailsMonitor;
				break;
			case "MonitorFightingScore":
				currentSprite = FightingScoreMonitor;
				break;
		}
	}
	
	void Update() {
		iRenderer.sprite = currentSprite;
		if (!monitorBroken) {
			currentText.text = "";
		}
		else {
			if (!textAnimComplete) {
				// Follow graph y = sin(x) without changing sign
				x += (Time.deltaTime * speed);
				y = Mathf.Sin(x) * height;
				if (x >= Mathf.PI) {
					x = 0;
					y = 0;
					textAnimComplete = true;
				}
				currentText.fontSize = originalFontSize + y;
			}
		}
	}
	
    public void OnPointerClick(PointerEventData eventData)
    {
		if (!monitorBroken) {
			audioSource.Play();
			monitorBroken = true;
			currentText.enabled = true;
			currentSprite = BrokenMonitor;
			currentText.text = monitorValue.ToString();
		}
    }
}