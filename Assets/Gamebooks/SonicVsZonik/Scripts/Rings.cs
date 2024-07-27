using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Stats = SonicVsZonikVitalStatistics;

public class Rings : MonoBehaviour
{
	private TMP_Text currentText;
	
    void Start()
    {
        currentText = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (Stats.rings == int.MaxValue) {
			currentText.text = "∞";
		}
		else if (Stats.rings >= 0) {
			currentText.text = Stats.rings.ToString();
		}
    }
}
