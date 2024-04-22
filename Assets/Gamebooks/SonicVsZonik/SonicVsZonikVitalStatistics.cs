using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonicVsZonikVitalStatistics : MonoBehaviour
{
	public static Dictionary<string, int> abilities = new Dictionary<string, int>();
	public static int lives;
	public static int rings;
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		// Prevent more than one VitalStatisticsManager from existing
		if (!(SceneManager.GetActiveScene().name == "SonicVsZonikMenu"
			|| SceneManager.GetActiveScene().name == "SonicVsZonikGame")) {
			if (this.gameObject) Destroy(this.gameObject);	
		}
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
    }
}
