using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeAdjust : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicVolume;
	[SerializeField] private AudioMixerGroup sfxVolume;
}
