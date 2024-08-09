using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ParticleController : MonoBehaviour
{
    public GameObject particlePrefab;
    public int particlesPerSecond;
    public float particleSpeed;
    public float sizeIncreaseRate;
    public RectTransform particleContainer;

	// Travel time from center to edge of the screen (in seconds)
    public float travelTime;

    void Start()
    {
        StartCoroutine(GenerateParticles());
    }

    IEnumerator GenerateParticles()
    {
        while (true)
        {
            for (int i = 0; i < particlesPerSecond; i++)
            {
                CreateParticle();
            }
            yield return new WaitForSeconds(1f / particlesPerSecond);
        }
    }

    void CreateParticle()
    {
        GameObject particle = Instantiate(particlePrefab, particleContainer);
        particle.GetComponent<Image>().color = Color.white;
        RectTransform particleRectTransform = particle.GetComponent<RectTransform>();
        particleRectTransform.anchoredPosition = Vector2.zero; // Center of the RectTransform
        particle.AddComponent<ParticleBehavior>().Initialize(particleContainer, travelTime);
    }
}

public class ParticleBehavior : MonoBehaviour
{
    private float speed;
    private float sizeIncreaseRate;
    private Vector2 direction;
    private RectTransform particleContainer;
	private float travelTime;
	private float maxDistance;

    public void Initialize(RectTransform particleContainer, float travelTime)
    {
        this.particleContainer = particleContainer;
        this.travelTime = travelTime;

        // Calculate the maximum distance from the center to the edge of the screen
        float maxDistance = GetMaxDistanceToEdge();

        // Scale speed so that the particle reaches the edge in the given travel time
        this.speed = maxDistance / travelTime;

        // Scale size increase rate based on the speed
        this.sizeIncreaseRate = 5f;

        // Set the initial direction
        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
    }

    void Update()
    {
        if (!IsOnScreen())
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
		maxDistance = GetMaxDistanceToEdge();
		this.speed = maxDistance / travelTime;
		transform.localScale += Vector3.one * sizeIncreaseRate * Time.fixedDeltaTime;
        transform.Translate(direction * speed * Time.fixedDeltaTime);
    }

    bool IsOnScreen()
    {
        Vector3 localPos = particleContainer.InverseTransformPoint(transform.position);
        Vector2 halfSize = particleContainer.rect.size / 2;
        return localPos.x > -halfSize.x && localPos.x < halfSize.x &&
               localPos.y > -halfSize.y && localPos.y < halfSize.y;
    }

    private float GetMaxDistanceToEdge()
	{
		Camera mainCamera = Camera.main;
		float distanceToCamera = Vector3.Distance(mainCamera.transform.position, particleContainer.position);

		// Calculate half the vertical field of view in radians
		float halfVerticalFOV = mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad;

		// Calculate the vertical and horizontal sizes in world space
		float verticalSize = Mathf.Tan(halfVerticalFOV) * distanceToCamera;
		float horizontalSize = verticalSize * mainCamera.aspect;

		// Return the diagonal distance from the center to a corner
		return Mathf.Sqrt(horizontalSize * horizontalSize + verticalSize * verticalSize);
	}
}