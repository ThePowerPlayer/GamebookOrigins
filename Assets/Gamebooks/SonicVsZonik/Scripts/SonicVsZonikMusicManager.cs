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
	public AudioClip MackMadness;
	public AudioClip AquaticRuin;
	public AudioClip ChopChopFight;
	public AudioClip InTheWoods;
	public AudioClip RobotnikCloud;
	public AudioClip CasinoNight;
	public AudioClip PinballHall;
	public AudioClip PinballMachine;
	public AudioClip PinballEnding;
	public AudioClip HillTop;
	public AudioClip MysticCave;
	public AudioClip Metropolis;
	public AudioClip SewerSystem;
	public AudioClip RobotWars;
	public AudioClip RobotWars2;
	public AudioClip SkyChase;
	public AudioClip FinalShowdown;
	public AudioClip GameComplete;
	public AudioClip GameOver;
	
	// Dictionary: Input is a section number, output is its corresponding song
	// TODO: Update this to include every section
	private static Dictionary<int, AudioClip> Song = new Dictionary<int, AudioClip>();
	
	void Start() {
		Song[1] = GreenHill;
		Song[200] = TailsIsHurt;
		Song[201] = ChemicalPlant;
		Song[46] = MackMadness;
		Song[42] = AquaticRuin;
		Song[69] = ChopChopFight;
		Song[128] = InTheWoods;
		Song[28] = RobotnikCloud;
		Song[65] = CasinoNight;
		Song[66] = PinballHall;
		Song[274] = PinballMachine;
		Song[45] = PinballEnding;
		Song[82] = HillTop;
		Song[121] = MysticCave;
		Song[191] = Metropolis;
		Song[64] = SewerSystem;
		Song[268] = RobotWars;
		Song[248] = RobotWars2;
		Song[269] = SkyChase;
		Song[214] = FinalShowdown;
		Song[300] = GameComplete;
		
		Song[41] = GameOver;
		Song[54] = GameOver;
		Song[231] = GameOver;
		Song[281] = GameOver;
	}
	
	public void PlaySongForSection(int section) {
		if (Song.ContainsKey(section) && Song[section] != audioSource.clip) {
			audioSource.Stop();
			audioSource.clip = Song[section];
			if (audioSource.clip == GameOver || audioSource.clip == GameComplete) {
				audioSource.loop = false;
			}
			else {
				audioSource.loop = true;
			}
			audioSource.Play();
		}
	}
}
