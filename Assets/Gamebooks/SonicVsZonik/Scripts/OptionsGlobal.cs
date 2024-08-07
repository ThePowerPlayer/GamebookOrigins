using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsGlobal : MonoBehaviour
{
	public static float musicVolume = 1;
	public static float sfxVolume = 1;
	
	public static Dictionary<string, bool> options = new Dictionary<string, bool>
	{
		// Options for all gamebooks
		{"enableTurnToSection", true},
		{"enableBackButton", true},
		{"markVisitedSections", true},
		// DEBUG: Set these 4 options to false on release.
		{"speedrunTimer", true},
		{"customVitalStatistics", true},
		{"infiniteLives", false},
		{"infiniteRings", false},
		// Sonic vs. Zonik options
		{"fixFruitMachine", true},
		{"lenientPinball", true},
		{"fixRexonEncounter", true},
		{"fixWhiffyLiquid", true},
		{"fixSkyChase", true},
		{"fixCloudSkimmer", true},
		{"alwaysGetZoneChip", true},
		{"useZoneChipForFree", true},
		{"reEnterSpecialZoneDoors", true}
	};
	
	public static OptionsGlobal instance { get; private set; }

	// Prevent more than one OptionsGlobal from existing
	void Awake()
	{
		if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
		DontDestroyOnLoad(gameObject);
	}
	
	public static void ToggleOption(string option) {
		options[option] = !options[option];
	}
}