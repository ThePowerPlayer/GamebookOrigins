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
	
	public ScrollRect scroll;
	public GameObject scrollbar;
	private UnityEngine.UI.Image iRenderer;
	
    void Start()
    {
        x = 0;
		y = 0;
		originalPosY = gameObject.transform.position.y;
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
		if (scrollbar.activeInHierarchy && !scrollEndPoint()) {
			iRenderer.enabled = true;
		}
		else {
			iRenderer.enabled = false;
		}
	}
	
    void FixedUpdate()
    {
		// Follow graph y = sin(x) without changing sign
		x += (Time.fixedDeltaTime * speed);
		if (x >= Mathf.PI) {
			x = 0;
		}
		y = Mathf.Sin(x) * height;
        if (!upArrow) {
			y = -y;
		}
		gameObject.transform.position = new Vector2(
			gameObject.transform.position.x,
			originalPosY + y);
    }
}
