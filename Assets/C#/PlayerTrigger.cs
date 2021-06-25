using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    private HealthController HC;

    public GameObject GrandfUI;

    private void Start()
    {
        HC = gameObject.GetComponent<HealthController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case"Enemy":
                HC.TakeDamage(other.GetComponent<EnemyController>().Enemies[0].damage);
                break;
            case"Collactable":

                if (GameManager.access.GL.INV.MaxCountInv > 0 && GameManager.access.GL.INV.MaxCountInv >= other.GetComponent<Holder>().HolderItems[0].Count)
                {
                    GameManager.access.GL.INV.MaxCountInv -= other.GetComponent<Holder>().HolderItems[0].Count;
                    GameManager.access.GL.INV.Collect(other.GetComponent<Holder>().HolderItems[0]);
                    other.gameObject.SetActive(false);
                }
                break;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Grandfather":
                if (GameManager.access.IK.wantInteract)
                {
                    GameManager.access.UI.ToggleUI(GameManager.access.UI.GrandfUI);
                    GameManager.access.IK.wantInteract = false;
                }
                break;
        }
    }
}
