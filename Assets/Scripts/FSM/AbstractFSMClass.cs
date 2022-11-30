using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExecutionState
{
    //sets the current state that the STATE is in
    NONE, 
    ACTIVE,
    COMPLETED,
    TERMINATED, // error state
};
public enum FSMStateType
{
    IDLE,
    FIGHTING,
};
public abstract class AbstractFSMClass : ScriptableObject
{
    protected FiniteStateMachine _fsm;
    protected GameObject _target;
    protected NPCEnemies _npc;
    protected int[] npcAttacks;
   public ExecutionState ExecutionState { get; protected set; } // sets execution state for the FSM
    public FSMStateType StateType { get; protected set; } // sets state type for the FSM
   public bool EnteredState { get; protected set; }

   
   public virtual void OnEnable()
    {
        ExecutionState = ExecutionState.NONE; // first created so it shouldnt have any state yet
    }

   public virtual bool EnterState()
    {
        bool successTarget = true;
        bool successNPC = true;
        ExecutionState = ExecutionState.ACTIVE; // enterstate means the state needs to be active
        successTarget = (_target != null);
        successNPC = (_npc != null);
        return successNPC&successTarget;
    }

    public abstract void UpdateState(); // updates behavior every "tick"


    public virtual bool ExitState() 
    {
        ExecutionState = ExecutionState.COMPLETED; // exitstate means the state needs to be completed
        return true;
    }

    public virtual void SetTarget(GameObject target)
    {
        if (target != null)
        {
            _target = target;
        }
    }

    public virtual void SetExecutingNPC (NPCEnemies npc)
    {
        if (npc != null)
        {
            _npc = npc;
        }    
    }
    public virtual void SetExecutingFSM (FiniteStateMachine fsm)
    {
        if (fsm != null)
        {
            _fsm = fsm;
        }
    }
    public virtual void SetAttacks(int[] attacks)
    {
        if(attacks != null)
        {
            attacks = npcAttacks;
        }
    }
}
