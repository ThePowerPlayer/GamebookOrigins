using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrollbarReset : MonoBehaviour
{
	private Scene scene;
	private ScrollRect scroll;
	private int currentIndex;
	
	int sceneIndex() {
		if (scene.name == "SonicVsZonikMenu") {
			return SonicVsZonikMenu.index;
		}
		else {
			return SonicVsZonikGame.index;
		}
	}
	
	void Start() {
		scene = SceneManager.GetActiveScene();
		scroll = GetComponent<ScrollRect>();
		currentIndex = sceneIndex();
	}
	
    void Update() {
		if (sceneIndex() != currentIndex) {
			scroll.verticalNormalizedPosition = 1;
			currentIndex = sceneIndex();
		}
	}
}
