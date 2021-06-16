using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Inventory INV;
    public Player P;

    //Schmied
    public int finalItemRarity;
    public int slot = 0;
    private List<int> RarityPot = new List<int>();
    public List<Item> SlotList = new List<Item>();

    public void SmithCraft()
    {
        Debug.Log("Craft");
        for (int ii = 0; ii < 3; ii++)
        {
            for (int i = 0; i < SlotList[slot].RarityCount; i++)
            {
                RarityPot.Add(SlotList[slot].Rarity);
            }
            slot++;
        }

        finalItemRarity = Random.Range(0, RarityPot.Count + 1);
        slot = 0;
        switch (RarityPot[finalItemRarity])
        {
            case 1:
                Debug.Log("1");
                //Random.Range(0, Rarity1Items.Count + 1);
                break;
            case 2:
                Debug.Log("2");
                //Random.Range(0, Rarity2Items.Count + 1);
                break;
            case 3:
                Debug.Log("3");
                // Random.Range(0, Rarity3Items.Count + 1);
                break;
            case 4:
                // Random.Range(0, Rarity4Items.Count + 1);
                break;
            case 5:
                // Random.Range(0, Rarity5Items.Count + 1);
                break;
        }
    }
}
