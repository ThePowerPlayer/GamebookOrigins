using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinText : MonoBehaviour
{
	[SerializeField] private TMP_Text winText;
	[SerializeField] private TMP_Text congratulations;
	
    void Update()
    {
		winText.enabled = (SonicVsZonikGame.index == 300);
		congratulations.enabled = (SonicVsZonikGame.index == 300);
    }
}
