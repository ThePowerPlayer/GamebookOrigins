using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicVsZonikVitalStatistics : MonoBehaviour
{
	public static Dictionary<string, int> abilities = new Dictionary<string, int>();
	public static int lives = 3;
	public static int rings = 0;
	
    void Start()
    {
        abilities.Add("Speed", 0);
		abilities.Add("Strength", 0);
		abilities.Add("Agility", 0);
		abilities.Add("Coolness", 0);
		abilities.Add("Quick Wits", 0);
		abilities.Add("Good Looks", 0);
    }
	
    void Update()
    {
        abilities["Speed"] = 1;
    }
}
