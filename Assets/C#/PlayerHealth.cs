using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth;

    public float damageTaken;

    private Trigger trigger;

    private void Start()
    {
        trigger = gameObject.GetComponent<Trigger>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            //die
        }
    }

    public void TakeDamage()
    {
        currentHealth -= damageTaken;
        Debug.Log(currentHealth);
    }
}
