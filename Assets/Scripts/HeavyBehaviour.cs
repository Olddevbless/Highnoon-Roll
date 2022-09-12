using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBehaviour : Enemy
{
    [Header("Enemy Stats")]
    [SerializeField] int lightDmg;
    [SerializeField] int heavyDmg;
    [SerializeField] int shotDmg;
    [SerializeField] int enemyHealth = 10;
    [SerializeField] int currentHealth;
    [SerializeField] int feralHp;

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
    

    EnemyFSM bossMode = EnemyFSM.Idle;

    public void Boss(GameObject heavyGameObject)
    {
        base.bossGameObject = heavyGameObject;
    }

    public override void UpdateEnemy(GameObject playerGameObject)
    {

        switch(bossMode)
        {
            case EnemyFSM.Hesitant:
                if (playerGameObject.GetComponent<PlayerMovement>().currentAmmo <= 0)
                    bossMode = EnemyFSM.Aggressive;
                if (currentHealth <= dodgingHP/2&& currentHealth> feralHp)
                    bossMode = EnemyFSM.Evasive;
                if (currentHealth <= feralHp)
                    bossMode = EnemyFSM.Aggressive;
                    break;
            case EnemyFSM.Aggressive:
                if (currentHealth <= dodgingHP)
                    bossMode = EnemyFSM.Hesitant;
                    break;
            case EnemyFSM.Evasive:
                if (currentHealth <= feralHp)
                    bossMode = EnemyFSM.Aggressive;
                break;


            
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth =- damage;
    }
}
