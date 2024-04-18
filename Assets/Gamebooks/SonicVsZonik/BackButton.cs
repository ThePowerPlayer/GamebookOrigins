using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private Button button;
	
	void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
	}
	
    private void TaskOnClick() {
		// Remove from section history
		SonicVsZonikGame.backButtonPressed = true;
		if (SonicVsZonikGame.sectionHistory.Count > 1) {
			SonicVsZonikGame.sectionHistory.Pop();
			
		}
		int previousIndex = SonicVsZonikGame.sectionHistory.Peek();
		SonicVsZonikGame.ChangeIndex(previousIndex.ToString());
	}
}
