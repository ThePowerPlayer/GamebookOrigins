using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVZGame = SonicVsZonikGame;
using SVZText = SonicVsZonikGameText;

public class BackButton : MonoBehaviour
{
    private Button button;
	
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
		if (SVZGame.sectionHistory.Count > 1) {
			SVZGame.sectionHistory.Pop();
			
		}
		
		// Subtract rings
		SonicVsZonikVitalStatistics.rings -= SVZText.sectionLibrary[SVZGame.index].rings;
		
		// Decrement counter for Mack sections
		if (SVZText.sectionLibrary[SVZGame.index].mackSection) {
			SVZGame.mackCounter--;
		}
		// Go to previous index
		int previousIndex = SVZGame.sectionHistory.Peek();
		SVZGame.ChangeIndex(previousIndex.ToString());
	}
}
