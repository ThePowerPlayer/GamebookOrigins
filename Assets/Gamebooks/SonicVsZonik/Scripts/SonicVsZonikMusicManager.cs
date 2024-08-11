using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicVsZonikMusicManager : MonoBehaviour
{
	public AudioSource audioSource;
	
	// List of songs:
	
	// Emerald Hill Zone - Sonic the Hedgehog 2
	public AudioClip GreenHill;
	
	// Beatnik on the Ship - Streets of Rage
	public AudioClip TailsIsHurt;
	
	// Volcano Valley Zone Act 2 - Sonic 3D Blast
	public AudioClip ZoneChip;
	
	// Chemical Plant Zone - Sonic the Hedgehog 2
	public AudioClip ChemicalPlant;
	
	// Sandopolis Zone Act 2 - Sonic and Knuckles
	public AudioClip MackMadness;
	
	// Aquatic Ruin Zone - Sonic the Hedgehog 2
	public AudioClip AquaticRuin;
	
	// Miniboss - Sonic and Knuckles
	public AudioClip ChopChopFight;
	
	// Mushroom Hill Zone Act 1 - Sonic and Knuckles
	public AudioClip InTheWoods;
	
	// Never Return Alive - Streets of Rage 2
	public AudioClip RobotnikCloud;
	
	// Casino Night Zone - Sonic the Hedgehog 2
	public AudioClip CasinoNight;
	
	// In the Bar - Streets of Rage 2
	public AudioClip PinballHall;
	
	// Toxic Caves - Sonic Spinball
	public AudioClip PinballMachine;
	
	// Lava Powerhouse - Sonic Spinball
	public AudioClip PinballEnding;
	
	// Hill Top Zone - Sonic the Hedgehog 2
	public AudioClip HillTop;
	
	// Mystic Cave Zone - Sonic the Hedgehog 2
	public AudioClip MysticCave;
	
	// Metropolis Zone - Sonic the Hedgehog 2
	public AudioClip Metropolis;
	
	// Dilapidated Town - Streets of Rage
	public AudioClip SewerSystem;
	
	// Death Egg Zone Act 1 - Sonic and Knuckles
	public AudioClip RobotWars;
	
	// Death Egg Zone Act 2 - Sonic and Knuckles
	public AudioClip RobotWars2;
	
	// The Doomsday Zone - Sonic and Knuckles
	public AudioClip SkyChase;
	
	// Final Zone - Sonic the Hedgehog
	public AudioClip FinalShowdown;
	
	// Ending - Sonic the Hedgehog
	public AudioClip GameComplete;
	
	// Game Over - Sonic the Hedgehog
	public AudioClip GameOver;
	
	// Game Over - Sonic Spinball
	public AudioClip GameOverSpinball;
	
	// Section dictionary: Input is a song, output is a list of every section number with that song
	private static Dictionary<AudioClip, int[]> Section = new Dictionary<AudioClip, int[]>();
	
	// Song dictionary: Input is a section number, output is its corresponding song
	private static Dictionary<int, AudioClip> Song = new Dictionary<int, AudioClip>();
	
	void Start() {
		
		Section[GreenHill] = new int[] {1};
		Section[TailsIsHurt] = new int[] {200};
		Section[ChemicalPlant] = new int[] {201};
		Section[ZoneChip] = new int[] {127, 221};
		Section[MackMadness] = new int[] {46};
		Section[AquaticRuin] = new int[] {42};
		Section[ChopChopFight] = new int[] {69};
		Section[InTheWoods] = new int[] {128};
		Section[RobotnikCloud] = new int[] {28};
		Section[CasinoNight] = new int[] {65};
		Section[PinballHall] = new int[] {66, 97};
		Section[PinballMachine] = new int[] {274};
		Section[PinballEnding] = new int[] {45};
		Section[HillTop] = new int[] {82};
		Section[MysticCave] = new int[] {121};
		Section[Metropolis] = new int[] {191};
		Section[SewerSystem] = new int[] {64};
		Section[RobotWars] = new int[] {268};
		Section[RobotWars2] = new int[] {248};
		Section[SkyChase] = new int[] {269};
		Section[FinalShowdown] = new int[] {214};
		Section[GameComplete] = new int[] {300};
		Section[GameOver] = new int[] {54, 231, 281};
		Section[GameOverSpinball] = new int[] {41};
		
		// Assign keys and values to the Song dictionary
		foreach (KeyValuePair<AudioClip, int[]> entry in Section)
        {
            AudioClip clip = entry.Key;
            int[] sections = entry.Value;
			
			// For every value in the Section dictionary,
            // assign each integer in the array as a key in the Song dictionary
            foreach (int section in sections)
            {
                if (!Song.ContainsKey(section))
                {
                    Song.Add(section, clip);
                }
            }
        }
	}
	
	public void PlaySongForSection(int section) {
		if (Song.ContainsKey(section) && Song[section] != audioSource.clip) {
			if (audioSource.clip != GameOver && audioSource.clip != GameOverSpinball) {
				SonicVsZonikGame.mostRecentMusic = section;
			}
			audioSource.Stop();
			audioSource.clip = Song[section];
			if (audioSource.clip == GameOver || audioSource.clip == GameOverSpinball || audioSource.clip == GameComplete) {
				audioSource.loop = false;
			}
			else {
				audioSource.loop = true;
			}
			audioSource.Play();
		}
	}
}
