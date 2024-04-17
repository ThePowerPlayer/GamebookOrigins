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
	private Scene scene;
	
	void Start() {
		scene = SceneManager.GetActiveScene();
	}
	
	public void ToggleInventoryMode() {
		inventoryMode = !inventoryMode;
		Debug.Log("Inventory mode is " + inventoryMode);
		foreach (GameObject obj in GameplayObjects) {
			obj.SetActive(!inventoryMode);
		}
		foreach (GameObject obj in InventoryObjects) {
			obj.SetActive(inventoryMode);
		}
		
		if (scene.name == "SonicVsZonikMenu" && !inventoryMode) {
			SVZMenu.ChangeButtons();
		}
	}
}
