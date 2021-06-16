using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct Item
{
    public string Name;
    public Sprite Picture;
    public int Count;
    public string Description;
    public int Rarity;
    public int RarityCount;
}
