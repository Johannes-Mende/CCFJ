using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private bool isTriggered;

    private HealthController HC;

    private void Start()
    {
        HC = gameObject.GetComponent<HealthController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            HC.TakeDamage(other.GetComponent<EnemyController>().Enemies[0].damage);
        }

        if (other.tag == "Collactable")
        {

            if (GameManager.access.GL.INV.MaxCountInv > 0 && GameManager.access.GL.INV.MaxCountInv >= other.GetComponent<Holder>().HolderItems[0].Count)
            {
                GameManager.access.GL.INV.MaxCountInv -= other.GetComponent<Holder>().HolderItems[0].Count;
                GameManager.access.GL.INV.Collect(other.GetComponent<Holder>().HolderItems[0]);
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
