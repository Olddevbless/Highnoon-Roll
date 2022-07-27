using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMovement : MonoBehaviour
{
    public bool diceIsGrounded;

    private void Start()
    {
        diceIsGrounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {

        diceIsGrounded = true;
    }
}
