using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonicVsZonikVitalStatistics : MonoBehaviour
{
	public static Dictionary<string, int> abilities = new Dictionary<string, int>();
	public static int lives;
	public static int rings;
	public static int credits;
	public static int points;
	public static HashSet<string> SonicsStuff = new HashSet<string>();
	
    public static SonicVsZonikVitalStatistics instance { get; private set; }

	// Prevent more than one VitalStatisticsManager from existing
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
	
    void Start()
    {
		bool hasHistory = (SonicVsZonikSectionLogic.sectionHistory != null
			&& SonicVsZonikSectionLogic.sectionHistory.Count > 0);
		if (!hasHistory) {
			lives = 3;
			rings = 0;
			credits = 0;
			points = 0;
			
			abilities["Speed"] = 0;
			abilities["Agility"] = 0;
			abilities["Strength"] = 0;
			abilities["Coolness"] = 0;
			abilities["Quick Wits"] = 0;
			abilities["Good Looks"] = 0;
			abilities["Section 31"] = 7;
		}
		if (OptionsGlobal.options["infiniteLives"]) {
			lives = int.MaxValue;
		}
		if (OptionsGlobal.options["infiniteRings"]) {
			rings = int.MaxValue;
		}
    }
	
	void Update()
	{
		if (OptionsGlobal.options["infiniteLives"]) {
			lives = int.MaxValue;
		}
		else {
			lives = Mathf.Clamp(lives, 0, 999);
		}
		if (OptionsGlobal.options["infiniteRings"]) {
			rings = int.MaxValue;
		}
		else {
			rings = Mathf.Clamp(rings, 0, 999);
		}
		
		credits = Mathf.Clamp(credits, 0, 999);
		points = Mathf.Clamp(points, 0, 999);
		
		abilities["Speed"] = Mathf.Clamp(abilities["Speed"], 0, 99);
		abilities["Agility"] = Mathf.Clamp(abilities["Agility"], 0, 99);
		abilities["Strength"] = Mathf.Clamp(abilities["Strength"], 0, 99);
		abilities["Coolness"] = Mathf.Clamp(abilities["Coolness"], 0, 99);
		abilities["Quick Wits"] = Mathf.Clamp(abilities["Quick Wits"], 0, 99);
		abilities["Good Looks"] = Mathf.Clamp(abilities["Good Looks"], 0, 99);
	}
}
