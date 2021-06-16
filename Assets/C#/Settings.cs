using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public int fps = 30;
    public bool workInBackground = true, dontDestroy = false;
    void Awake()
    {
        Application.targetFrameRate = fps;
        Application.runInBackground = workInBackground;
        if(dontDestroy)
        DontDestroyOnLoad(this);
    }
}
