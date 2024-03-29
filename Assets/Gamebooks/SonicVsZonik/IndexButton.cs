using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndexButton : MonoBehaviour
{
	private TMP_Text currentText;
	
	void Start() {
		currentText = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
	}
	
    public void ButtonGoToIndex() {
		int newIndex = 0;
		if (int.TryParse(currentText.text, out newIndex)) {
			SonicVsZonikGame.index = newIndex;
		}
	}
}
