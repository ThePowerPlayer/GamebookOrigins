using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputField : MonoBehaviour
{
	public static TMP_InputField tmpInputField;
	
    void Start()
    {
       tmpInputField = GetComponent<TMP_InputField>();
    }
	
    public static void TaskOnEndEdit() {
		SonicVsZonikGame.ChangeIndex(tmpInputField.text);
	}
}
