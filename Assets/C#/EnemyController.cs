using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public HealthController HC;
    public List<Enemies> Enemies = new List<Enemies>();

    void Awake()
    {
       HC.currentHealth = Enemies[0].maxHealth;
    }

    private void Start()
    {
        HC = gameObject.GetComponent<HealthController>();
    }
}
