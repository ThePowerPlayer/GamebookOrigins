using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseASection : MonoBehaviour
{
	[SerializeField] private TMP_Text currentText;

    void Update()
    {
        if (DiceRollManager.diceMode) {
			currentText.text = "Roll the die:";
		}
		else {
			currentText.text = "Choose a section:";
		}
    }
}
