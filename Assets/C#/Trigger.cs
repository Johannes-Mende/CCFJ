using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isTriggered;

    private PlayerHealth PH;

    private void Start()
    {
        PH = gameObject.GetComponent<PlayerHealth>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            PH.damageTaken = other.GetComponent<Enemy>().Enemies[0].damage;
            PH.TakeDamage();
        }

        if (other.tag == "Collactable")
        {

            if (GetComponent<Inventory>().MaxCountInv > 0 && GetComponent<Inventory>().MaxCountInv >= other.GetComponent<Holder>().HolderItems[0].Count)
            {
                GetComponent<Inventory>().MaxCountInv -= other.GetComponent<Holder>().HolderItems[0].Count;
                GetComponent<Inventory>().InvItems.Add(other.GetComponent<Holder>().HolderItems[0]);
                other.gameObject.SetActive(false);
            }
            isTriggered = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
            isTriggered = false;
    }
}
