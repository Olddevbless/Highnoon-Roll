using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(FiniteStateMachine))]
public class NPCEnemies : MonoBehaviour
{
    FiniteStateMachine finiteStateMachine;
    [SerializeField] NPCEnemies _npc;
    [SerializeField] GameObject _target;
    //[SerializeField] int[] _npcAttacks;
    public void Awake()
    {
        finiteStateMachine = GetComponent<FiniteStateMachine>();
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        
    }
    public NPCEnemies npc
    {
        get
        {
            return _npc;
        }
    }
    public GameObject target
    {
        get
        {
            return _target;
        }
    }
    //public int[] npcAttacks
    //{
    //    get
    //    {
    //        return _npcAttacks;
    //    }
    //}    
}
