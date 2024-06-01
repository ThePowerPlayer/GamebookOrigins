using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Stats = SonicVsZonikVitalStatistics;

public class BuyExtraLife : MonoBehaviour
{
	private AudioSource audioSource;
    private Button button;
	
	void Start() {
		audioSource = gameObject.GetComponent<AudioSource>();
		button = GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}

    void Update() {
		button.interactable = (Stats.rings >= 100);
	}
	
	private void TaskOnClick() {
		audioSource.Play();
		Stats.rings -= 100;
		Stats.lives++;
	}
}
