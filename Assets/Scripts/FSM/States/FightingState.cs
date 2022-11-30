using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FightingState", menuName = "Unity- FSM/States/Fighting", order = 2)]

public class FightingState : AbstractFSMClass
{
    int roll;
    GameObject _targetInFState;
    NPCEnemies _npcInFState;
    int[] _npcAttacksInFState;
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
            _npcAttacksInFState = npcAttacks;
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
            if (_npcAttacksInFState == null)
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
        if (roll<15)
        {
            //jump
        }
        if (15 < roll && roll< 40)
        {
            //dash
        }
        if (roll>40 && roll <60)
        {
            //duck
        }
        if (roll>60 && roll<80)
        {
            //duck
        }
        if (roll>80&& roll>100)
        {
            //duck&attack
        }
    }
    public void UpHeavyD()
    {
        if (roll < 7)
        {
            //jump
        }
        if (7 < roll && roll < 40)
        {
            //dash
        }
        if (roll > 40 && roll < 60)
        {
            //duck
        }
        if (roll > 60 && roll < 80)
        {
            //duck
        }
        if (roll > 80 && roll > 100)
        {
            //duck&attack
        }
    }
    public void DownLightD()
    {
        if (roll < 15)
        {
            //duck
        }
        if (15 < roll && roll < 40)
        {
            //dash
        }
        if (roll > 40 && roll < 60)
        {
            //jump
        }
        if (roll > 60 && roll < 80)
        {
            //jump
        }
        if (roll > 80 && roll > 100)
        {
            //jump&attack
        }
    }
    public void DownHeavyD()
    {
        if (roll < 7)
        {
            //duck
        }
        if (7 < roll && roll < 40)
        {
            //dash
        }
        if (roll > 40 && roll < 60)
        {
            //jump
        }
        if (roll > 60 && roll < 80)
        {
            //jump
        }
        if (roll > 80 && roll > 100)
        {
            //jump&attack
        }
    }
    public void ShootD()
    {

    }
}
