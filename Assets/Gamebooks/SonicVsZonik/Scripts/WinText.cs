using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinText : MonoBehaviour
{
	[SerializeField] private TMP_Text winText;
	[SerializeField] private TMP_Text congratulations;
	private bool gameEnded;
	
    void Update()
    {
		gameEnded = (SonicVsZonikSectionLogic.gameOver || SonicVsZonikGame.index == 300);
		winText.enabled = gameEnded;
		congratulations.enabled = gameEnded;
		if (gameEnded) {
			if (SonicVsZonikSectionLogic.gameOver) {
				winText.text = "GAME OVER";
				congratulations.text = "Better luck next time!";
			}
			else if (SonicVsZonikGame.index == 300) {
				winText.text = "THE END";
				congratulations.text = "Congratulations!";
			}
		}
    }
}