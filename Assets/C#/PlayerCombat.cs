using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public HealthController HC;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Start()
    {
        HC = gameObject.GetComponent<HealthController>();
    }

    private void Update()
    {
        /*if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + attackRate;
            }
        }*/
    }

    public void Attack()
    {
        if(Time.time >= nextAttackTime)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit" + enemy.name);
                enemy.GetComponent<EnemyController>().HC.TakeDamage(attackDamage);
            }
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
