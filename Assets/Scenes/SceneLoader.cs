using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] private UnityEngine.UI.Image BlackOutSquareImage;
    private Color spriteColor;
	private float alpha;
	private float fadeSpeed = 1f;
	
	private Scene currentScene;
	public bool fadingOut;
	public float fadeoutTimer;
	private bool loading;
	private const float fadeCooldownMax = 0.3f;
	private float fadeCooldown = 0f;
	private bool fadeCooled;
	private string sceneToLoad;
	
	public AudioSource load_new_scene;
	private AudioSource[] allAudioSources;
	
	void Awake() {
		// Load options
		string filePath = Application.persistentDataPath + "/Options.json";
		OptionsGlobal.LoadOptions(filePath);
		// Load Sonic vs. Zonik save data
		filePath = Application.persistentDataPath + "/SonicVsZonik.json";
		SonicVsZonikSectionLogic.LoadSVZData(filePath);
		
		SceneManager.sceneLoaded += OnSceneLoaded;
		
		BlackOutSquareImage.enabled = true;
		spriteColor = BlackOutSquareImage.color;
		spriteColor.a = 1f;
		alpha = spriteColor.a;
		BlackOutSquareImage.color = spriteColor;
		
		load_new_scene = GetComponent<AudioSource>();
	}
	
	void OnDestroy() {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		currentScene = SceneManager.GetActiveScene();
		loading = false;
		fadingOut = false;
		fadeCooled = false;
		fadeCooldown = fadeCooldownMax;
		allAudioSources =
			FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
		CheckIntroScenes();
    }
	
	void CheckIntroScenes() {
		if (currentScene.name == "SegaLogo" || currentScene.name == "DevPresents") {
			fadeSpeed = 1f;
			fadeoutTimer = 3f;		
			if (currentScene.name == "SegaLogo") {
				sceneToLoad = "DevPresents";
			}
			else if (currentScene.name == "DevPresents") {
				sceneToLoad = "Title";
			}
		}
		else {
			fadeSpeed = 3f;
			fadeoutTimer = 0;
		}
	}
	
	void StopAllAudio() {
		foreach(AudioSource audioS in allAudioSources) {
			audioS.Stop();
		}
	}
	
	public void LoadScene(string sceneName)
    {
		if (fadeCooled) {
			StopAllAudio();
			sceneToLoad = sceneName;
			if (currentScene.name != "SegaLogo" && currentScene.name != "DevPresents") {
				load_new_scene.Play();
			}
			fadingOut = true;
		}
    }
	
	void ChangeAlpha(ref float alpha, bool increasing) {
		float multiplier = 1;
		// Sign of alpha change (it either increases or decreases)
		if (!increasing) {
			multiplier *= -1;
		}
		// Greatly slow down fadeout when screen is almost black
		if (alpha >= 0.99) {
			multiplier *= 0.1f;
		}
		
		alpha += (Time.deltaTime * fadeSpeed * multiplier);
		
		if (increasing && alpha >= 1)
		{
			alpha = 1;
		}
		if (!increasing && alpha <= 0)
		{
			alpha = 0;
		}
	}
	
	void Update() {
		// Scene transition must cooldown for 0.5 seconds
		// before another transition can happen
		if (!fadeCooled) {
			if (fadeCooldown > 0) {
				fadeCooldown -= Time.deltaTime;
			}
			else {
				fadeCooldown = 0;
				fadeCooled = true;
			}
		}
		
		// Use fadeout timer for intro scenes
		if ((currentScene.name == "SegaLogo" || currentScene.name == "DevPresents")
			&& !fadingOut) {
			fadeoutTimer -= Time.deltaTime;
			if (fadeoutTimer < 0) {
				fadeoutTimer = 0;
				LoadScene(sceneToLoad);
			}
		}
		
		// Fade INTO scene by DECREASING alpha of blackout square
		if (fadingOut == false && alpha > 0)
		{
			ChangeAlpha(ref alpha, false);
			spriteColor.a = alpha;
			BlackOutSquareImage.color = spriteColor;
		}
		
		// Fade OUT OF scene by INCREASING alpha of blackout square
		if (fadingOut == true)
		{
			ChangeAlpha(ref alpha, true);
			spriteColor.a = alpha;
			BlackOutSquareImage.color = spriteColor;
			
			if (alpha >= 1 && loading == false)
			{
				StartCoroutine(LoadSceneAsync());
			}
		}
	}
	
	IEnumerator LoadSceneAsync()
	{
		// Start loading asynchronous scene
		loading = true;
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
		
		// Wait until the asynchronous scene fully loads
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
    }
}