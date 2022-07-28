using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public int speed = 5;
    public GameObject dice;
    public GameObject feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool diceIsGrounded;
    private Rigidbody playerRB;
    public float jumpingPower;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;
    public bool playerIsGrounded;
    public GameObject bullet;
    Vector3 aimGun;
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        diceIsGrounded = dice.GetComponent<DiceMovement>().diceIsGrounded;
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 mousePos = Input.mousePosition;
        mousePos += Camera.main.transform.forward * 30f; // Make sure to add some "depth" to the screen point
        aimGun = Camera.main.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 14f));
        Shooting();
        Walking();
        Jumping();
        
    }
    private void OnCollisionStay(Collision collision)
    {
        playerIsGrounded = true;
        
    }
    private void OnCollisionExit(Collision collision)
    {
        playerIsGrounded = false;
    }



    void Walking()
    {
        if (horizontalInput > 0.01 && diceIsGrounded == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (horizontalInput < -0.01 && diceIsGrounded == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    void Jumping ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && diceIsGrounded == true && playerIsGrounded == true)
        {
            playerRB.AddForce(Vector3.up * jumpingPower, ForceMode.Impulse);
            jumpTimeCounter = jumpTime;
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.Space)&& isJumping == true)
        {
            if (jumpTimeCounter>0)
            {
                playerRB.AddForce(Vector3.up * jumpingPower);
                jumpTimeCounter -= Time.deltaTime;
              
            }
            else
            {
                isJumping = false;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    void Shooting()
    {
       
        if (Input.GetMouseButtonDown(0) && diceIsGrounded == true) 
        {
            Debug.Log("im shooting");
            Instantiate(bullet, aimGun, bullet.transform.rotation);
        }
    }


    
}
