using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GifAnimator : MonoBehaviour
{
    public Sprite[] frames; // Array to hold the frames of the GIF
    public float frameRate = 0.1f; // Time between frames in seconds

    private Image image; // Reference to the UI Image component
    private int currentFrame;

    void Start()
    {
        image = GetComponent<Image>();
		StartCoroutine(PlayGif());
    }
	
	void OnEnable()
	{
		if (image != null) {
			StartCoroutine(PlayGif());
		}
	}

    IEnumerator PlayGif()
    {
        while (true)
        {
            image.sprite = frames[currentFrame];
            currentFrame = (currentFrame + 1) % frames.Length;
            yield return new WaitForSeconds(frameRate);
        }
    }
}
