using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ParticleController : MonoBehaviour
{
    public GameObject particlePrefab;
    public int particlesPerSecond = 10;
    public float particleSpeed = 2f;
    public float sizeIncreaseRate = 0.01f;
    public RectTransform particleContainer;

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
        particle.AddComponent<ParticleBehavior>().Initialize(particleSpeed, sizeIncreaseRate, particleContainer);
    }
}

public class ParticleBehavior : MonoBehaviour
{
    private float speed;
    private float sizeIncreaseRate;
    private Vector2 direction;
    private RectTransform particleContainer;

    public void Initialize(float speed, float sizeIncreaseRate, RectTransform particleContainer)
    {
        this.speed = speed;
        this.sizeIncreaseRate = sizeIncreaseRate;
        this.particleContainer = particleContainer;

        float angle = Random.Range(0f, 360f);
        direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        transform.localScale += Vector3.one * sizeIncreaseRate * Time.deltaTime;

        if (!IsOnScreen())
        {
            Destroy(gameObject);
        }
    }

    bool IsOnScreen()
    {
        Vector3 localPos = particleContainer.InverseTransformPoint(transform.position);
        Vector2 halfSize = particleContainer.rect.size / 2;
        return localPos.x > -halfSize.x && localPos.x < halfSize.x &&
               localPos.y > -halfSize.y && localPos.y < halfSize.y;
    }
}
