using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsGlobal : MonoBehaviour
{
	public static bool enableTurnToSection;
	public static bool enableBackButton;
	public static bool markVisitedSections;
	public static bool customVitalStatistics;
	
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
	
    void Start()
    {
        enableTurnToSection = false;
		enableBackButton = false;
		markVisitedSections = false;
		customVitalStatistics = false;
    }
	
	public static void ToggleTurnToSection() {
		enableTurnToSection = !enableTurnToSection;
	}
	
	public static void ToggleBackButton() {
		enableBackButton = !enableBackButton;
	}
	
	public static void ToggleMarkVisitedSections() {
		markVisitedSections = !markVisitedSections;
	}
	
	public static void ToggleCustomVitalStatistics() {
		customVitalStatistics = !customVitalStatistics;
	}
	
}