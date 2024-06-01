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
		lives = 3;
		rings = 0;
		credits = 50;
		points = 0;
		
		abilities["Speed"] = 0;
		abilities["Agility"] = 0;
		abilities["Strength"] = 0;
		abilities["Coolness"] = 0;
		abilities["Quick Wits"] = 0;
		abilities["Good Looks"] = 0;
		abilities["Section 31"] = 7;
    }
}
