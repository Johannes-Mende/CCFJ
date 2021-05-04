using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool isTriggered;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("sss");
        if (other.tag == "Collactable")
        {
            
            if (GetComponent<Inventory>().MaxCountInv > 0 && GetComponent<Inventory>().MaxCountInv >= other.GetComponent<Holder>().Items[0].Count)
            {
                GetComponent<Inventory>().MaxCountInv -= other.GetComponent<Holder>().Items[0].Count;
                GetComponent<Inventory>().Items.Add(other.GetComponent<Holder>().Items[0]);
                other.gameObject.SetActive(false);
            }
            isTriggered = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
            isTriggered = false;
    }
}
