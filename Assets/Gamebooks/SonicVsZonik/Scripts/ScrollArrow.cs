using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollArrow : MonoBehaviour
{
	public static float x;
	public static float y;
	private float originalPosY;
	private const int speed = 5;
	private const int height = 5;
	[SerializeField] private bool upArrow;
	RectTransform ArrowRect;
	
	public ScrollRect scroll;
	public GameObject scrollbar;
	private UnityEngine.UI.Image iRenderer;
	
    void Start()
    {
        x = 0;
		y = 0;
		ArrowRect = GetComponent<RectTransform>();
		originalPosY = ArrowRect.anchoredPosition.y;
		iRenderer = GetComponent<UnityEngine.UI.Image>();
    }
	
	bool roughlyEqual(float a, float b) {
		return (Mathf.Abs(a - b) < 0.001);
	}
	
	bool scrollEndPoint() {
		return ((upArrow && roughlyEqual(scroll.verticalNormalizedPosition, 1))
			|| (!upArrow && roughlyEqual(scroll.verticalNormalizedPosition, 0)));
	}
	
	void Update()
	{
		// Follow graph y = sin(x) without changing sign
		x += (Time.deltaTime * speed);
		if (x >= Mathf.PI) {
			x = 0;
		}
		y = Mathf.Sin(x) * height;
		
		if (scrollbar.activeInHierarchy && !scrollEndPoint()) {
			iRenderer.enabled = true;
		}
		else {
			iRenderer.enabled = false;
		}
		
		if (iRenderer.enabled) {
			if (upArrow) {
				ArrowRect.anchoredPosition = new Vector2(
				ArrowRect.anchoredPosition.x,
				originalPosY + y);
			}
			else {
				ArrowRect.anchoredPosition = new Vector2(
				ArrowRect.anchoredPosition.x,
				originalPosY - y);
			}
		}
	}
}
