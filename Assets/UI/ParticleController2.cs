using UnityEngine;
using UnityEngine.UI;

public class ParticleController2 : MonoBehaviour
{
    public Sprite[] particleSprites; // Array to hold the eight possible sprites
    public GameObject particlePrefab; // Prefab for the particle
    public float spawnInterval; // Time interval between spawns
    public float speed; // Speed of particle movement
	public float size; // Size modifier of particle
    public float amplitude; // Amplitude of the sine wave
    public float frequency; // Frequency of the sine wave

    private RectTransform canvasRectTransform;
    private float canvasHalfHeight;
    private float canvasHalfWidth;

    void Start()
    {
        // Get Canvas RectTransform
        canvasRectTransform = GetComponent<RectTransform>();

        // Calculate canvas bounds
        canvasHalfHeight = canvasRectTransform.rect.height / 2;
        canvasHalfWidth = canvasRectTransform.rect.width / 2;

        // Start spawning particles
        InvokeRepeating("SpawnParticle", 0f, spawnInterval);
    }

    void SpawnParticle()
    {
        // Choose a random sprite
        Sprite chosenSprite = particleSprites[Random.Range(0, particleSprites.Length)];

        // Create a new particle object
        GameObject particle = Instantiate(particlePrefab, canvasRectTransform);

        // Set the image of the particle
        particle.GetComponent<Image>().sprite = chosenSprite;

        // Position the particle just outside the left of the screen at a random vertical position
        float randomY = Random.Range(-canvasHalfHeight, canvasHalfHeight);
        Vector2 spawnPosition = new Vector3(-canvasHalfWidth - 1, randomY);
        particle.GetComponent<RectTransform>().anchoredPosition = spawnPosition;

        // Increase the size of the particle
        particle.transform.localScale *= size;

        // Add a movement component to the particle
        particle.AddComponent<ParticleMovement>().Initialize(speed, amplitude, frequency, canvasHalfWidth);
    }
}

public class ParticleMovement : MonoBehaviour
{
    private float speed;
    private float amplitude;
    private float frequency;
    private float canvasHalfWidth;

    private Vector3 startPosition;
    private RectTransform rectTransform;

    public void Initialize(float speed, float amplitude, float frequency, float canvasHalfWidth)
    {
        this.speed = speed;
        this.amplitude = amplitude;
        this.frequency = frequency;
        this.canvasHalfWidth = canvasHalfWidth;
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // Move the particle to the right along a sine wave
        float newX = rectTransform.anchoredPosition.x + speed * Time.deltaTime;
        float newY = startPosition.y + Mathf.Sin((newX - startPosition.x) * frequency) * amplitude;
        rectTransform.anchoredPosition = new Vector3(newX, newY, 0);

        // Destroy the particle when it leaves the screen bounds on the right side
        if (rectTransform.anchoredPosition.x > canvasHalfWidth)
        {
            Destroy(gameObject);
        }
    }
}
