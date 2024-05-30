using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicVsZonikMusicManager : MonoBehaviour
{
	public AudioSource audioSource;
	
	// List of songs
	public AudioClip GreenHill;
	public AudioClip TailsIsHurt;
	public AudioClip ChemicalPlant;
	
	// Dictionary: Input is a section number, output is its corresponding song
	// TODO: Update this to include every section
	private static Dictionary<int, AudioClip> Song = new Dictionary<int, AudioClip>();
	
	void Start() {
		Song[1] = GreenHill;
		Song[200] = TailsIsHurt;
		Song[201] = ChemicalPlant;
	}
	
	public void PlaySongForSection(int section) {
		if (Song.ContainsKey(section) && Song[section] != audioSource.clip) {
			audioSource.Stop();
			audioSource.clip = Song[section];
			audioSource.Play();
		}
	}
}
