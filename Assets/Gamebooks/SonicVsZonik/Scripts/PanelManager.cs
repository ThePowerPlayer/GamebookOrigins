using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
	public GameObject[] panelList;
	
	public void SwitchPanel(string newPanel) {
		foreach(GameObject panel in panelList) {
			panel.SetActive(panel.name == newPanel);
		}
	}
}