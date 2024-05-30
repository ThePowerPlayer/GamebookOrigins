using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryMode : MonoBehaviour
{
	public static bool inventoryMode;
	private bool diceBeingRolled;
	public GameObject GameplayObjects;
	public GameObject InventoryObjects;
	public SonicVsZonikMenu SVZMenu;
	public SonicVsZonikGame SVZGame;
	public SonicVsZonikGameText SVZText;
	private Scene scene;
	[SerializeField] private Button InventoryButton;
	
	void Start() {
		scene = SceneManager.GetActiveScene();
	}
	
	void Update() {
		if (scene.name == "SonicVsZonikGame") {	
			InventoryButton.interactable = !DiceRollManager.diceBeingRolled;
		}
	}
	
	public void ToggleInventoryMode() {
		inventoryMode = !inventoryMode;
		GameplayObjects.SetActive(!inventoryMode);
		InventoryObjects.SetActive(inventoryMode);
		
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
