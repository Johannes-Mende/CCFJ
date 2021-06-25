using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager access;
    public InputKeys IK;
    public GameLogic GL;
    public Settings S;
    public Save SA;
    public UIManager UI;
    public ItemManager IM;

    private void Awake()
    {
        access = this;
        DontDestroyOnLoad(gameObject);
    }
}
