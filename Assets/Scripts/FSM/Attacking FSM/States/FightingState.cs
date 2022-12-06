using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FightingState", menuName = "Unity- FSM/States/Fighting", order = 2)]

public class FightingState : AbstractFSMClass
{
    int roll;
    GameObject _targetInFState;
    NPCEnemies _npcInFState;
    EnemyAbilities enemyAbilities;
    public override void OnEnable()
    {
        StateType = FSMStateType.FIGHTING;
        base.OnEnable();
    }
    public override bool EnterState()
    {
        if (base.EnterState())
        {
            EnteredState = false;
            //grab and store target & NPC & attacks
            enemyAbilities = _npc.gameObject.GetComponent<EnemyAbilities>();
            _npcInFState = _npc.npc;
            _targetInFState = _target.gameObject;

            if (_npcInFState == null)
            {
                Debug.LogError("FightingState: Failed to grab NPC from NPCEnemies");

            }

            if (_targetInFState == null)
            {
                Debug.LogError("FightingState: Failed to grab Target from NPCEnemies");
            }
            if (enemyAbilities == null)
            {
                Debug.Log("FightingState: Failed to grab Attacks from NPCEnemies");

            }
            else
            {
                EnteredState = true;
            }
            

        }
        return EnteredState;
    }
    public override void UpdateState()
    {
        // make sure the we've successfully entered state
        if (EnteredState)
        {
            if (Input.GetKey(KeyCode.O))
            {
                enemyAbilities.Crouch();
            }
        }
    }

    public void DefenseRoll()
    {
        roll = (int)Random.Range(1f, 100f);
    }
    public void DefenseAction(int attackNum)
    {
        
        if (attackNum == 1) // UP L
        {
            UpLightD();
        }
        if (attackNum == 2) // UP H
        {
            UpHeavyD();
        }
        if (attackNum == 3)// DOWN L
        {
            DownLightD();
        }
        if (attackNum == 4)// DOWN H
        {
            DownHeavyD();
        }
        if (attackNum == 5)// Shoot
        {
            ShootD();
        }
    }
    public void UpLightD()
    {
        if (roll <= enemyAbilities.lightDrolls[0]) 
        {
            //jump
        }
        if (enemyAbilities.lightDrolls[0] < roll && roll<= enemyAbilities.lightDrolls[1])
        {
            //dash
        }
        if (roll>enemyAbilities.lightDrolls[1] && roll <= enemyAbilities.lightDrolls[3])
        {
            enemyAbilities.Crouch();
        }
        if (roll>enemyAbilities.lightDrolls[3]&& roll >= enemyAbilities.lightDrolls[4])
        {
            //duck&attack
        }
    }
    public void UpHeavyD()
    {
        if (roll <= enemyAbilities.heavyDrolls[0])
        {
            //jump
        }
        if (enemyAbilities.heavyDrolls[0] < roll && roll <= enemyAbilities.heavyDrolls[1])
        {
            //dash
        }
        if (roll > enemyAbilities.heavyDrolls[1] && roll <= enemyAbilities.heavyDrolls[3])
        {
            enemyAbilities.Crouch();
        }
        
        if (roll > enemyAbilities.heavyDrolls[3] && roll <= enemyAbilities.heavyDrolls[4])
        {
            //duck&attack
        }
    }
    public void DownLightD()
    {
        if (roll <= enemyAbilities.lightDrolls[0])
        {
            enemyAbilities.Crouch();
        }
        if (enemyAbilities.lightDrolls[0] < roll && roll <= enemyAbilities.lightDrolls[1])
        {
            //dash
        }
        if (roll > enemyAbilities.lightDrolls[1] && roll <= enemyAbilities.lightDrolls[3])
        {
            //jump
        }
        if (roll > enemyAbilities.lightDrolls[3] && roll >= enemyAbilities.lightDrolls[4])
        {
            //jump&attack
        }
    }
    public void DownHeavyD()
    {
        if (roll <= enemyAbilities.heavyDrolls[0])
        {
            enemyAbilities.Crouch();
        }
        if (enemyAbilities.heavyDrolls[0] < roll && roll <= enemyAbilities.heavyDrolls[1])
        {
            //dash
        }
        if (roll > enemyAbilities.heavyDrolls[1] && roll <= enemyAbilities.heavyDrolls[3])
        {
            //jump
        }

        if (roll > enemyAbilities.heavyDrolls[3] && roll <= enemyAbilities.heavyDrolls[4])
        {
            //jump&attack
        }
    }
    public void ShootD()
    {

    }
}
