using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
	[SerializeField] private Slider _slider;
	[SerializeField] private TextMeshProUGUI _sliderText;
	[SerializeField] private string sliderType;
	[SerializeField] private AudioMixer masterMixer;
	
    void Start()
    {	
        _slider.onValueChanged.AddListener((v) => {
			if (sliderType == "Music") {
				OptionsGlobal.musicVolume = (Mathf.Log10(_slider.value) * 20);
				masterMixer.SetFloat("mixerMusicVolume", OptionsGlobal.musicVolume);
			}
			else if (sliderType == "SFX") {
				OptionsGlobal.sfxVolume = (Mathf.Log10(_slider.value) * 20);
				masterMixer.SetFloat("mixerSFXVolume", OptionsGlobal.sfxVolume);
			}
			_sliderText.text = v.ToString("0%");
		});
    }
}
