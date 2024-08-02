using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHPCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text enemyName;
	[SerializeField] private TMP_Text enemyHP;
	[SerializeField] private UnityEngine.UI.Image Sprite;
	[SerializeField] private DiceRollManager DiceRollManager;

    void Update()
    {
		if (SonicVsZonikGameText.sectionLibrary[SonicVsZonikGame.index].fightSection
			&& DiceRollManager.diceMode) {
			Sprite.enabled = true;
			enemyName.enabled = true;
			enemyHP.enabled = true;
			if (DiceRollManager.currentEnemyList.Count != 0) {
				enemyName.text = DiceRollManager.currentEnemyList.Peek().name + " HP:";
				enemyHP.text = DiceRollManager.currentEnemyList.Peek().hp.ToString();
			}	
		}
        else {
			Sprite.enabled = false;
			enemyName.enabled = false;
			enemyHP.enabled = false;
		}
    }
}
