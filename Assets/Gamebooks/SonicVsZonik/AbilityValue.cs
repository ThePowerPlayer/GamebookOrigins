using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Stats = SonicVsZonikVitalStatistics;

public class AbilityValue : MonoBehaviour
{
	private TMP_Text currentText;
	[SerializeField] private string ability;
	
	void Start()
	{
		currentText = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
	}
	
    void Update()
    {
        currentText.text = Stats.abilities[ability].ToString();
    }
}
