using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int MaxCountInv = 10;
    public List<Item> Items = new List<Item>();
    public GameObject ItemPrefab;

    public GameObject InvUI;
    public bool activeInv;

    private void Awake()
    {
        ItemPrefab.SetActive(false);

        if (PlayerPrefs.HasKey("Inventory"))
            JsonUtility.FromJsonOverwrite(GameManager.access.SA.ReadSave("Inventory"), this);
    }

    public void Collect(Item i)
    {
        Items.Add(i);
        GameObject g = Instantiate(ItemPrefab, ItemPrefab.transform.parent);
        g.GetComponent<ItemPrefab>().ItemImage.GetComponent<Image>().sprite = i.Picture;
        g.GetComponent<ItemPrefab>().ItemText.GetComponent<Text>().text = i.Name;
        g.SetActive(true);

        GameManager.access.SA.Saving("Inventory", JsonUtility.ToJson(this));
        Debug.Log(i.Name);
    }

    public void ToggleInv()
    {
        if (activeInv)
        {
            InvUI.SetActive(false);
            activeInv = false;
        }
        else
        {
            InvUI.SetActive(true);
            activeInv = true;
        }
    }
}
