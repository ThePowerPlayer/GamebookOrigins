using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicVsZonikJingleManager : MonoBehaviour
{
	public AudioSource musicAudioSource;
	public AudioSource jingleAudioSource;
	
	public AudioClip SpinballPoints;
	public AudioClip Spinball100Points;
	public AudioClip SpinballComplete;
	public AudioClip ChaosEmerald;
	
	private float musicVolume;
	private float jingleVolume;
	private float jingleTimer;
	private const float fadeSpeed = 3f;
	private bool jinglePlaying = false;
	
	void OnEnable()
	{
		musicVolume = musicAudioSource.volume;
	}
	
    void Update()
    {
        if (jinglePlaying) {
			if (jingleTimer > 0) {
				jingleTimer -= Time.deltaTime;
				if (jingleTimer < 0) {
					jingleTimer = 0;
				}
			}
			else if (musicAudioSource.volume < musicVolume) {
				musicAudioSource.volume += (Time.deltaTime * musicVolume * fadeSpeed);
				if (musicAudioSource.volume > musicVolume) {
					musicAudioSource.volume = musicVolume;
					jinglePlaying = false;
				}
			}
		}
    }
	
	public void PlayJingle(string jingle) {
		if (jingle == "SpinballPoints") {
			jingleAudioSource.clip = SpinballPoints;
			jingleVolume = 1f;
		}
		else if (jingle == "Spinball100Points") {
			jingleAudioSource.clip = Spinball100Points;
			jingleVolume = 1f;
		}
		else if (jingle == "SpinballComplete") {
			jingleAudioSource.clip = SpinballComplete;
			jingleVolume = 1f;
		}
		else if (jingle == "ChaosEmerald") {
			jingleAudioSource.clip = ChaosEmerald;
			jingleVolume = 0.6f;
		}
		jingleTimer = jingleAudioSource.clip.length;
		jingleAudioSource.volume = jingleVolume;
		jingleAudioSource.Play();
		jinglePlaying = true;
		
		musicAudioSource.volume = 0;
	}
}
