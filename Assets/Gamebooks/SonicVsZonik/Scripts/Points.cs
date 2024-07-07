using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Stats = SonicVsZonikVitalStatistics;

public class Points : MonoBehaviour
{
	private TMP_Text currentText;
	[SerializeField] private TMP_Text maxPointsText;
	
    void Start()
    {
        currentText = gameObject.GetComponent<TMP_Text>();
		if (OptionsGlobal.options["lenientPinball"]) {
			maxPointsText.text = "/50";
		}
		else {
			maxPointsText.text = "/100";
		}
    }

    void Update()
    {
        currentText.text = Stats.points.ToString();
    }
}