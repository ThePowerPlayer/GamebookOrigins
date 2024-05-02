using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateCap : MonoBehaviour
{
	[SerializeField] private int framerate;
	
    void Awake()
    {
        Application.targetFrameRate = framerate;
    }
}
