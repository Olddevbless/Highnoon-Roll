using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "Unity- FSM/States/Idle", order = 1)]
public class IdleState : AbstractFSMClass
{
    public override void OnEnable()
    {
        StateType = FSMStateType.IDLE;

        base.OnEnable();
    }
    public override bool EnterState()
    {
        base.EnterState();
        if (EnteredState)
        {
            Debug.Log("Entered Idle State");
           
        }
       
        EnteredState = true;
        return EnteredState;
    }
    public override void UpdateState()
    {
        bool isDiceGrounded = FindObjectOfType<DiceMovement>().diceIsGrounded;
        Debug.Log("Updating Idle State: dise is grounded:"+ isDiceGrounded);
        if (isDiceGrounded == true)
        {
            _fsm.EnterState(FSMStateType.FIGHTING);
        }
    }
    public override bool ExitState()
    {
        base.ExitState();
        Debug.Log("Exit Idle State");
        return true;
        
    }
}
