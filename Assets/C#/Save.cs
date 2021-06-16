using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public void Saving(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public string ReadSave(string key)
    {
        return PlayerPrefs.GetString(key);
    }
}
