using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollArrowHorizontal : MonoBehaviour
{
	public static float x;
	public static float y;
	private float originalPosX;
	private const int speed = 10;
	private const int height = 10;
	RectTransform ArrowRect;
	private UnityEngine.UI.Image iRenderer;
	
    void Start()
    {
        x = 0;
		y = 0;
		ArrowRect = GetComponent<RectTransform>();
		originalPosX = ArrowRect.anchoredPosition.x;
		iRenderer = GetComponent<UnityEngine.UI.Image>();
    }
	void Update()
	{
		// Follow graph y = sin(x) without changing sign
		x += (Time.deltaTime * speed);
		if (x >= Mathf.PI) {
			x = 0;
		}
		y = Mathf.Sin(x) * height;
		
		// Specific code for SonicVsZonikMenu scene
		if (SonicVsZonikMenu.index >= 2) {
			if (OptionsGlobal.options["customVitalStatistics"] == false
				&& SonicVsZonikMenu.allStatsAssigned) {
				iRenderer.enabled = false;
			}
			else {
				iRenderer.enabled = true;
			}
		}
		else {
			iRenderer.enabled = false;
		}
		
		if (iRenderer.enabled) {
			ArrowRect.anchoredPosition = new Vector2(
				originalPosX + y,
				ArrowRect.anchoredPosition.y);
		}
	}
}