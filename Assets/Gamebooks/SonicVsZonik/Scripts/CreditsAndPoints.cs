using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditsAndPoints : MonoBehaviour
{
	private TMP_Text currentText;
	[SerializeField] private GameObject Credits;
	[SerializeField] private GameObject Points;
	
    void Start()
    {
        currentText = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
		if (SonicVsZonikGameText.sectionLibrary[SonicVsZonikGame.index].pinballSection) {
			Credits.SetActive(true);
			Points.SetActive(true);
		}
        else {
			Credits.SetActive(false);
			Points.SetActive(false);
		}
    }
}
