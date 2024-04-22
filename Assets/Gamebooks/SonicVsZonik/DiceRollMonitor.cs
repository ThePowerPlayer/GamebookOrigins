using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DiceRollMonitor : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private Sprite BrokenMonitor;
	private UnityEngine.UI.Image iRenderer;
	private bool monitorBroken;
	private bool textAnimComplete;
	
	private int monitorValue;
	
	private TMP_Text currentText;
	private TextMeshProUGUI currentTextGUI;
	
	private float x;
	private float y;
	private float originalFontSize;
	private const int speed = 5;
	private const int height = 30;
	
	void Start() {
		iRenderer = GetComponent<UnityEngine.UI.Image>();
		currentText = transform.GetChild(0).GetComponent<TMP_Text>();
		currentText.text = "";
		originalFontSize = currentText.fontSize;
	}
	
	public void ResetMonitor(int i) {
		monitorBroken = false;
		textAnimComplete = false;
		x = 0;
		y = 0;
		monitorValue = i;
	}
	
	void FixedUpdate() {
		if (monitorBroken && !textAnimComplete) {
			// Follow graph y = sin(x) without changing sign
			x += (Time.fixedDeltaTime * speed);
			y = Mathf.Sin(x) * height;
			if (x >= Mathf.PI) {
				x = 0;
				y = 0;
				textAnimComplete = true;
			}
			currentText.fontSize = originalFontSize + y;
		}
	}
	
    public void OnPointerClick(PointerEventData eventData)
    {
		if (!monitorBroken) {
			monitorBroken = true;
			currentText.enabled = true;
			iRenderer.sprite = BrokenMonitor;
			currentText.text = monitorValue.ToString();
		}
    }
}