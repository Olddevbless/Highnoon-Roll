using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public int speed = 5;
    public GameObject dice;
    public bool diceIsGrounded;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        diceIsGrounded = dice.GetComponent<DiceMovement>().diceIsGrounded;
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput>0.01 && diceIsGrounded==true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (horizontalInput < -0.01 && diceIsGrounded == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
