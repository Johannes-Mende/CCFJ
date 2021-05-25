using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Enemies> Enemies = new List<Enemies>();
    private int currentHealth;

    void Start()
    {
        currentHealth = Enemies[0].maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("die");
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
