using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField] 
    AbstractFSMClass startingState;
    AbstractFSMClass currentState;
    [SerializeField]
    List<AbstractFSMClass> _validStates;
    Dictionary<FSMStateType, AbstractFSMClass> _fsmStates;
    public void Awake()
    {
        currentState = null;
        _fsmStates = new Dictionary<FSMStateType, AbstractFSMClass>();
        NPCEnemies npc = this.GetComponent<NPCEnemies>().npc;
        GameObject target = this.GetComponent<NPCEnemies>().target;
        //int[] attacks = this.GetComponent<NPCEnemies>().npcAttacks;
        foreach (AbstractFSMClass state in _validStates)
        {
            state.SetExecutingFSM(this);
            state.SetExecutingNPC(npc);
            state.SetTarget(target);
            //state.SetAttacks(attacks);
            _fsmStates.Add(state.StateType, state);
        }
    }
    public void Start()
    {
        if (startingState != null)
        {
            EnterState(startingState);
        }
    }
    public void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    #region STATE MANAGEMENT

    public void EnterState(AbstractFSMClass nextState)
    {
        if(startingState = null)
        {
            return;
        }
        if (currentState != null)
        {
            currentState.ExitState();
        }
        currentState = nextState;
        currentState.EnterState();
    }
    public void EnterState(FSMStateType stateType)
    {
        if (_fsmStates.ContainsKey(stateType))
        {
            AbstractFSMClass nextState = _fsmStates[stateType];
           
            EnterState(nextState);
        }
    }
    #endregion

}
