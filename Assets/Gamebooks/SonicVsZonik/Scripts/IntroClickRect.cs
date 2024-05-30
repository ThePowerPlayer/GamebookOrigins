using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class IntroClickRect : MonoBehaviour
{
	public AudioSource SegaSound;
	private SceneLoader sceneLoader;
	
	void Start() {
		sceneLoader = FindObjectOfType<SceneLoader>();
	}
	
    public void OnClick()
    {
		sceneLoader.fadeoutTimer = 0;
    }
}
