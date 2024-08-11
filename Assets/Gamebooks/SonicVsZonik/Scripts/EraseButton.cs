using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EraseButton : MonoBehaviour
{
	[SerializeField] private AudioSource SFXAudioSource;
	[SerializeField] private AudioClip Explosion;
    [SerializeField] private Button thisButton;
	[SerializeField] private GameObject yesButton;
	[SerializeField] private GameObject noButton;
	[SerializeField] private TMP_Text reallyErase;
	private bool reallyEraseMode;
	
	void Start() {
		thisButton.onClick.AddListener(TaskOnClick);
	}
	
	void Update() {
		yesButton.SetActive(reallyEraseMode);
		noButton.SetActive(reallyEraseMode);
		reallyErase.enabled = reallyEraseMode;
	}
	
    private void TaskOnClick() {
		reallyEraseMode = true;
	}
	
	public void ExitReallyEraseMode() {
		reallyEraseMode = false;
	}
	
	public void EraseSaveData() {
		SFXAudioSource.clip = Explosion;
		SFXAudioSource.Play();
		SonicVsZonikSectionLogic.EraseSVZData();
		ExitReallyEraseMode();
	}
}