using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Stats = SonicVsZonikVitalStatistics;

public class AbilityValue : MonoBehaviour
{
	private TMP_Text currentText;
	private Scene scene;
	[SerializeField] private string ability;
	
	void Start()
	{
		currentText = gameObject.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
		scene = SceneManager.GetActiveScene();
	}
	
    void Update()
    {
		currentText.text = Stats.abilities[ability].ToString();
    }
}
