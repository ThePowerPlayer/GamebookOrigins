using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbsUp : MonoBehaviour
{
	private float x;
	private float y;
	private float originalPosY;
	private const int speed = 20;
	private const int height = 7;
	public bool thumbPointsUp;
	public float visibilityTimer;
	public bool visible;
	private RectTransform rect;
	private Vector2 originalSize;
	private float sizeMultiplier;
	private UnityEngine.UI.Image iRenderer;
	
    void Start()
    {
        x = 0;
		y = 0;
		rect = GetComponent<RectTransform>();
		originalSize = rect.sizeDelta;
		originalPosY = rect.anchoredPosition.y;
		iRenderer = GetComponent<UnityEngine.UI.Image>();
		visible = false;
		visibilityTimer = 1f;
    }
	
	void IncrementUntilLimit(ref float f, float inc, float limit) {
		if (f < limit) {
			f += (inc * Time.deltaTime);
			if (f > limit) {
				f = limit;
			}
		}
	}
	
	void DecrementUntilLimit(ref float f, float dec, float limit) {
		if (f > limit) {
			f -= (dec * Time.deltaTime);
			if (f < limit) {
				f = limit;
			}
		}
	}
	
    void Update()
    {
		iRenderer.enabled = visible;
		
        // Follow graph y = sin(x) WITH changing sign
		x += (Time.deltaTime * speed);
		if (x >= 2 * Mathf.PI) {
			x = 0;
		}
		y = Mathf.Sin(x) * height;
		
		if (visible) {
			// Set position while visible
			rect.anchoredPosition = new Vector2(
				rect.anchoredPosition.x,
				originalPosY + y);
			
			// Grow and shrink while visible
			DecrementUntilLimit(ref visibilityTimer, 1f, 0);
			if (visibilityTimer > 0) {
				IncrementUntilLimit(ref sizeMultiplier, 5f, 1);
			}
			else {
				DecrementUntilLimit(ref sizeMultiplier, 5f, 0);
			}
		}
		else {
			sizeMultiplier = 0;
		}
		
		rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize.x * sizeMultiplier / 50);
		rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSize.y * sizeMultiplier / 50);
		
		if (thumbPointsUp) {
			rect.localScale = new Vector2(
				originalSize.x,
				originalSize.y);
		}
		else {
			rect.localScale = new Vector2(
				originalSize.x,
				-originalSize.y);
		}
    }
}
