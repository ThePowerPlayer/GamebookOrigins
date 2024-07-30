using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedrunTimer : MonoBehaviour
{
	private TMP_Text timer_text;
	private float time;
	private int minutes;
	private float seconds;
	private string niceTime;
	
    void Start()
    {
        timer_text = GetComponent<TMP_Text>();
		timer_text.enabled = (OptionsGlobal.options["speedrunTimer"]);
		time = 0;
		minutes = 0;
		seconds = 0;
		niceTime = "";
    }
	
    void Update()
    {
		if (SonicVsZonikGame.index != 300) {
			time += Time.deltaTime;
			minutes = Mathf.FloorToInt(time / 60F);
			seconds = (time - minutes * 60);
			niceTime = string.Format("{0:00}:{1:00.00}", minutes, seconds);
			timer_text.text = niceTime;
		}
    }
}
