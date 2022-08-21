using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int lightDmg;
    [SerializeField] int heavyDmg;
    [SerializeField] int shotDmg;
    [SerializeField] int enemyHealth = 10;
    [SerializeField] int currentHealth;

    [Header("Enemy Behavior")]
    [SerializeField] bool isAggressive;
    [SerializeField] bool isDodging;
    [SerializeField] bool isHesitant;
    [SerializeField] int aggroHP;
    [SerializeField] int hesitantHP;
    [SerializeField] int dodgingHP;
    [SerializeField] bool isAttacking;

    [Header("Player Pathfinding")]
    GameObject player;
    float distanceFromPlayer;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    void Start()
    {
        // decide starting behavior, isAggressive = true;/isDodge = true;/isHesitant=true;
        currentHealth = enemyHealth;
    }
    private void Update()
    {
        distanceFromPlayer = player.transform.position.x - this.transform.position.x;

        if (currentHealth >= aggroHP)
        {
            isAggressive = true;
        }
        if (currentHealth <= hesitantHP)
        {
            isHesitant = true;
        }
        if (currentHealth <= dodgingHP)
        {
            isDodging = true;
        }
    }
    
    // Behaviors
    void Dodging()
    {

    }
    void Hesitant()
    {

    }
    void Aggresive()
    {

    }

    // Actions
    void Dodge()
    {

    }
    void Jump()
    {

    }
    void Attacks()
    {
        if (distanceFromPlayer<lightAttackRange&& isAttacking==false)
        {
            isAttacking = true;
            Invoke("LightAttack", 0.5f);
        }
        if (distanceFromPlayer<heavyAttackRange&& isAttacking == false)
        {
            isAttacking = true;
            Invoke("HeavyAttack", 1f);
        }
    }
    void LightAttack()
    {

    }
    void HeavyAttack()
    {

    }
    public void TakeDamage(int i)
    {
        currentHealth -= i;
    }
}
