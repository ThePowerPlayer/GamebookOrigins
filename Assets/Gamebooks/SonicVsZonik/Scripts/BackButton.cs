using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVZGame = SonicVsZonikGame;
using SVZText = SonicVsZonikGameText;

public class BackButton : MonoBehaviour
{
    private Button button;
	[SerializeField] private SonicVsZonikSectionLogic SVZLogic;
	
	void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}
	
	void Update() {
		button.interactable = !DiceRollManager.diceBeingRolled;
	}
	
    private void TaskOnClick() {
		// Remove from section history
		SVZGame.backButtonPressed = true;
		SVZText.sectionLibrary[SVZGame.index].inHistory = false;
		SonicVsZonikSectionLogic.gameOver = false;
		if (SonicVsZonikSectionLogic.sectionHistory.Count > 1) {
			SVZLogic.RemoveFromHistory();
		}
	}
}