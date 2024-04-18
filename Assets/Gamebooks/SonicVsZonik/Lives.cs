using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stats = SonicVsZonikVitalStatistics;

public class Lives : MonoBehaviour
{
	[SerializeField] private int lifeNumber;
	private UnityEngine.UI.Image iRenderer;
	
	void Start() {
		iRenderer = gameObject.GetComponent<UnityEngine.UI.Image>();
	}
	
    void Update()
    {
		if (Stats.lives >= lifeNumber) {
			iRenderer.enabled = true;
		}
		else {
			iRenderer.enabled = false;
		}
    }
}
