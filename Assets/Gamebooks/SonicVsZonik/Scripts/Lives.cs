using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Stats = SonicVsZonikVitalStatistics;

public class Lives : MonoBehaviour
{
	private TMP_Text currentText;
	
    void Start()
    {
        currentText = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
		if (Stats.lives == int.MaxValue) {
			currentText.text = "∞";
		}
		else if (Stats.lives >= 0) {
			currentText.text = Stats.lives.ToString();
		}
    }
}
