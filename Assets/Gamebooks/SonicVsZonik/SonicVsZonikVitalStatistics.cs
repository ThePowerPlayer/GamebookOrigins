using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonicVsZonikVitalStatistics : MonoBehaviour
{
	public static Dictionary<string, int> abilities = new Dictionary<string, int>();
	public static int lives;
	public static int rings;
	
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
		
		abilities["Speed"] = 1;
		abilities["Agility"] = 2;
		abilities["Strength"] = 3;
		abilities["Coolness"] = 4;
		abilities["Quick Wits"] = 5;
		abilities["Good Looks"] = 6;
		abilities["Section 31"] = 7;
    }
}
