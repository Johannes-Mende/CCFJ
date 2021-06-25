using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject InvUI;
    public GameObject GrandfUI;

    private bool UIactive;

    public void ToggleUI(GameObject UI)
    {
        if (!UI.activeInHierarchy && !UIactive)
        {
            UI.SetActive(true);
            UIactive = true;
        }
        else
        {
            UI.SetActive(false);
            UIactive = false;
        }
    }
}
