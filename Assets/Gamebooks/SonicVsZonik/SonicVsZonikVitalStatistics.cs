using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicVsZonikVitalStatistics : MonoBehaviour
{
	Dictionary<string, int> abilities = new Dictionary<string, int>(); 
	
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
