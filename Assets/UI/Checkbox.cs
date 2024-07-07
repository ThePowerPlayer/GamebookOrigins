using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Checkbox : MonoBehaviour
{
	public Sprite CheckboxUnchecked;
	public Sprite CheckboxChecked;
	public string option;
	private Image image;
	
    void Start()
    {
        image = GetComponent<Image>();
    }
	
    void Update()
    {
        if (OptionsGlobal.options[option]) {
			image.sprite = CheckboxChecked;
		}
		else {
			image.sprite = CheckboxUnchecked;
		}
    }
}
