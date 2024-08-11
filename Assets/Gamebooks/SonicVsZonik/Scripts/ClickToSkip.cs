using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickToSkip : MonoBehaviour
{
	[SerializeField] private TMP_Text currentText;
	
    void Update()
    {
        if (DiceRollManager.diceBeingRolled) {
			currentText.text = "(Click to skip)";
		}
		else {
			currentText.text = "";
		}
    }
}
