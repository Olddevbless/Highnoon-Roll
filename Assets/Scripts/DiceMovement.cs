using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMovement : MonoBehaviour
{
    public bool diceIsGrounded;
    Rigidbody diceRB;


    private void Start()
    {
        diceRB = gameObject.GetComponent<Rigidbody>();
        diceRB.AddTorque(new Vector3(1,1,1), ForceMode.Impulse);
        diceRB.AddForce(Vector3.right, ForceMode.Impulse);
        diceIsGrounded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {

        diceIsGrounded = true;
    }
}
