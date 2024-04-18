using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryMode : MonoBehaviour
{
	public static bool inventoryMode;
	public GameObject[] GameplayObjects;
	public GameObject[] InventoryObjects;
	public SonicVsZonikMenu SVZMenu;
	public SonicVsZonikGame SVZGame;
	private Scene scene;
	
	void Start() {
		scene = SceneManager.GetActiveScene();
	}
	
	public void ToggleInventoryMode() {
		inventoryMode = !inventoryMode;
		foreach (GameObject obj in GameplayObjects) {
			obj.SetActive(!inventoryMode);
		}
		foreach (GameObject obj in InventoryObjects) {
			obj.SetActive(inventoryMode);
		}
		
		if (!inventoryMode) {
			if (scene.name == "SonicVsZonikMenu" && SVZMenu != null) {
				SVZMenu.ChangeButtons();
			}
			else if (scene.name == "SonicVsZonikGame" && SVZGame != null) {
				SVZGame.ChangeButtons();
			}
		}
	}
}
