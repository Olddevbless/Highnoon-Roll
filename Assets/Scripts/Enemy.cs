using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{
    public GameObject bossGameObject;
    public enum EnemyFSM
    {
        Aggressive,
        Evasive,
        Hesitant,
        Stunned,
        Idle
    }

    public virtual void UpdateEnemy(GameObject playerGameObject)
    {
       
    }
    
    void Behaviour(GameObject playerGameObject, EnemyFSM modes)
    {
        int speed = 5;
       
        switch (modes)
        {
            case EnemyFSM.Aggressive:
                bossGameObject.transform.position = Vector3.MoveTowards(bossGameObject.transform.position, playerGameObject.transform.position, speed * Time.deltaTime);
                //dodge less and move towards player
                break;
            case EnemyFSM.Evasive:
                //dodge more and move away from player
                break;
            case EnemyFSM.Hesitant:
                //dodge and attack equally
                break;
            case EnemyFSM.Stunned:
                //stop movement for a few seconds and play animation
                break;
            case EnemyFSM.Idle:
                //play idle animation if not performing any action
                break;

        }
    }
}