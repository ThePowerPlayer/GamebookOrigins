using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Stats = SonicVsZonikVitalStatistics;

public class Points : MonoBehaviour
{
	private TMP_Text currentText;
	
    void Start()
    {
        currentText = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        currentText.text = Stats.points.ToString();
    }
}
