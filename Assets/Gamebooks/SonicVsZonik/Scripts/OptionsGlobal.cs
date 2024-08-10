using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class OptionsGlobal : MonoBehaviour
{
	// Note that these values range from 0 dB (full volume) to -80 dB (silence).
	// They are also reset upon quitting the game.
	public static float musicVolume;
	public static float sfxVolume;
	
	public static Dictionary<string, bool> options = new Dictionary<string, bool>
	{
		// Options for all gamebooks
		{"enableTurnToSection", true},
		{"enableBackButton", true},
		{"markVisitedSections", true},
		{"easierFights", false},
		{"speedrunTimer", false},
		{"customVitalStatistics", false},
		{"infiniteLives", false},
		{"infiniteRings", false},
		// Sonic vs. Zonik options
		{"easierRiverEscape", true},
		{"variedTreasure", true},
		{"fixFruitMachine", true},
		{"lenientPinball", true},
		{"fixRexonEncounter", true},
		{"fixWhiffyLiquid", true},
		{"fixSkyChase", true},
		{"fixCloudSkimmer", true},
		{"alwaysGetZoneChip", true},
		{"reEnterSpecialZoneDoors", true},
		{"useZoneChipForFree", false}
	};
	
	public class OptionsClass
	{
		public Dictionary<string, bool> options = new Dictionary<string, bool>();
	}
	
	public static OptionsGlobal instance { get; private set; }

	// Prevent more than one OptionsGlobal from existing
	void Awake()
	{
		musicVolume = 0;
		sfxVolume = 0;
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
	
	public static void SaveOptions() {
		string filePath = Application.persistentDataPath + "/Options.json";
		OptionsClass data = new OptionsClass();
		data.options = options;
		string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(filePath, json);
	}
	
	public static void LoadOptions(string filePath) {
		if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            OptionsClass data = JsonConvert.DeserializeObject<OptionsClass>(json);
			options = data.options;
        }
	}
}