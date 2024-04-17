using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMode : MonoBehaviour
{
	public static bool inventoryMode;
	public GameObject[] GameplayObjects;
	public GameObject[] InventoryObjects;
	
	public void ToggleInventoryMode() {
		inventoryMode = !inventoryMode;
		Debug.Log("Inventory mode is " + inventoryMode);
		foreach(GameObject obj in GameplayObjects) {
			obj.SetActive(!inventoryMode);
		}
		foreach(GameObject obj in InventoryObjects) {
			obj.SetActive(inventoryMode);
		}
	}
}
