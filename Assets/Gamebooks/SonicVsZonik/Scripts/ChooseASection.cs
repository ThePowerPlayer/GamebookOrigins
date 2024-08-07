using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ChooseASection : MonoBehaviour
{
	[SerializeField] private TMP_Text currentText;
	private int[] gameEndSections = new int[5] {41, 54, 231, 281, 300};
	
    void Update()
    {
		if (gameEndSections.Contains(SonicVsZonikGame.index)) {
			currentText.text = "";
		}
		else if (DiceRollManager.fightMode && DiceRollManager.enemyTurn) {
			currentText.text = "Enemy's turn to fight:";
		}
		else if (DiceRollManager.fightMode) {
			currentText.text = "Sonic's turn to fight:";
		}
        else if (DiceRollManager.diceMode) {
			currentText.text = "Roll the die:";
		}
		else if (DiceRollManager.chooseAbilityMode) {
			currentText.text = "Choose an ability to use:";
		}
		else {
			currentText.text = "Choose a section:";
		}
    }
}
