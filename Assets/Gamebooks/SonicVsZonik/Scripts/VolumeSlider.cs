using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
	[SerializeField] private Slider _slider;
	[SerializeField] private AudioMixer _audioMixer;
	[SerializeField] private TextMeshProUGUI _sliderText;
	[SerializeField] private string sliderType;
	
    void Start()
    {	
        _slider.onValueChanged.AddListener((v) => {
			if (sliderType == "Music") {
				_audioMixer.SetFloat("mixerMusicVolume", Mathf.Log10(_slider.value) * 20);
			}
			else if (sliderType == "SFX") {
				_audioMixer.SetFloat("mixerSFXVolume", Mathf.Log10(_slider.value) * 20);
			}
			_sliderText.text = v.ToString("0%");
		});
    }
}
