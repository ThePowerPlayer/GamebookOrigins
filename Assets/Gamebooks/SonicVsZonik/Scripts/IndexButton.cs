using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IndexButton : MonoBehaviour
{
	private Button button;
	private TMP_Text buttonText;
	
	void Start() {
		button = GetComponent<Button>();
		button.onClick.AddListener(TaskOnClick);
		buttonText = gameObject.transform.GetChild(0).GetComponent<TMP_Text>();
	}
	
    private void TaskOnClick() {
		SonicVsZonikGame.ChangeIndex(buttonText.text);
	}
}