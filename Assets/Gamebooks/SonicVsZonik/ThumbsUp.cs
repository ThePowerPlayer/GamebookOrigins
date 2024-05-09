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
	public float xExp;
	private const float xExpMultiplier = 1.2f;
	private RectTransform rect;
	private Vector2 originalSize;
	public float sizeMultiplier;
	public bool startedShrinking;
	private UnityEngine.UI.Image iRenderer;
	
    void Start()
    {
        x = 0;
		y = 0;
		rect = GetComponent<RectTransform>();
		originalSize = rect.sizeDelta;
		originalPosY = rect.position.y;
		iRenderer = GetComponent<UnityEngine.UI.Image>();
		visible = false;
		visibilityTimer = 1f;
		xExp = 0;
		sizeMultiplier = 0;
    }
	
	float Exp(float x) {
		return (1f - x) * Mathf.Exp(-5f * x);
	}
	
	void IncrementExp(ref float f, ref float xExp, float xExpMultiplier, ref bool startedShrinking) {
		xExp += xExpMultiplier * Time.deltaTime;
		if (startedShrinking) {
			f = Exp(xExp);
		}
		else {
			f = 1f - Exp(xExp);
		}
		Mathf.Clamp(xExp, 0f, 1f);
		Mathf.Clamp(f, 0f, 1f);
	}
	
    void Update()
    {
		iRenderer.enabled = visible;
		
		x += (Time.deltaTime * speed);
		if (x >= 2 * Mathf.PI) {
			x = 0;
		}
		// Adjust oscillation height by current size
		y = Mathf.Sin(x) * height * sizeMultiplier;
		
		if (visible) {
			// Set position while visible
			rect.position = new Vector2(
				rect.position.x,
				originalPosY + y);
			
			// Grow and shrink while visible
			visibilityTimer -= Time.deltaTime;
			
			// Reset exponential curve when shrinking
			if (visibilityTimer < 0 && !startedShrinking) {
				visibilityTimer = 0;
				startedShrinking = true;
				xExp = 0;
			}
			
			// Exponentially decrease grow/shrink speed
			IncrementExp(ref sizeMultiplier, ref xExp, xExpMultiplier, ref startedShrinking);
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
