using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    public float scrollSpeed;
    private RectTransform rectTransform;
    private RawImage rawImage;
    private Vector2 uvOffset = Vector2.zero;

    void Start()
    {
		scrollSpeed = 0.05f;
        rectTransform = GetComponent<RectTransform>();
        rawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        uvOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
        rawImage.uvRect = new Rect(uvOffset.x, uvOffset.y, rawImage.uvRect.width, rawImage.uvRect.height);
    }
}
