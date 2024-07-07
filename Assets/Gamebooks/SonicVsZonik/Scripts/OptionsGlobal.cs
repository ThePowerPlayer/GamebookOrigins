using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsGlobal : MonoBehaviour
{
	public static Dictionary<string, bool> options = new Dictionary<string, bool>
	{
		{"enableTurnToSection", false},
		{"enableBackButton", false},
		{"markVisitedSections", false},
		{"customVitalStatistics", false},
		{"lenientPinball", false},
		{"fixRexonEncounter", false},
		{"fixWhiffyLiquid", false},
		{"fixSkyChase", false},
		{"fixCloudSkimmer", false}
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