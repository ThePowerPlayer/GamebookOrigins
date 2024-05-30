using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitchScene : MonoBehaviour
{
	private SceneLoader sceneLoader;
	private Button button;
	
	public void LoadScene(string sceneToLoad)
    {
		sceneLoader.LoadScene(sceneToLoad);
    }
	
	void Start() {
		sceneLoader = FindObjectOfType<SceneLoader>();
		button = gameObject.GetComponent<Button>();
	}
	
	void Update() {
		button.interactable = !sceneLoader.fadingOut;
	}
}
