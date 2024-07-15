using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsGlobal : MonoBehaviour
{
	public static Dictionary<string, bool> options = new Dictionary<string, bool>
	{
		// DEBUG: All options are set to true
		// For release, enable only "enableTurnToSection" and "enableBackButton"
		{"enableTurnToSection", true},
		{"enableBackButton", true},
		{"markVisitedSections", true},
		{"customVitalStatistics", true},
		{"lenientPinball", true},
		{"fixRexonEncounter", true},
		{"fixWhiffyLiquid", true},
		{"fixSkyChase", true},
		{"fixCloudSkimmer", true}
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