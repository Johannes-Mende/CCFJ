using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public HealthController HC;
    public List<Enemies> Enemies = new List<Enemies>();
    public int maxItemRarity;

    private GameObject drobItem;
    private List<Item> drobList;

    private int itemRarity;
    private int random;


    void Awake()
    {
       HC.currentHealth = Enemies[0].maxHealth;
    }

    private void Start()
    {
        HC = gameObject.GetComponent<HealthController>();
    }

    void Die()
    {
        //drob Item


        this.gameObject.SetActive(false);
    }

    void Drob()
    {
        drobItem = GameManager.access.IM.item;

        ChooseRarity();

        switch (itemRarity)
        {
            case 1:
                drobList = GameManager.access.IM.Rarity1Items;
                break;
            case 2:
                drobList = GameManager.access.IM.Rarity2Items;
                break;
            case 3:
                drobList = GameManager.access.IM.Rarity3Items;
                break;
            case 4:
                drobList = GameManager.access.IM.Rarity4Items;
                break; 
            case 5:
                drobList = GameManager.access.IM.Rarity5Items;
                break;
        }



        random = Random.Range(0, drobList.Count);

        drobItem.GetComponent<Holder>().HolderItems.Add(drobList[random]);
        Instantiate(drobItem, this.transform.position, GameManager.access.IM.item.transform.rotation);
    }

    void ChooseRarity()
    {
        itemRarity = Random.Range(1, maxItemRarity);
    }
}
