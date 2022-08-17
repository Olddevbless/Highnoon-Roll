using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector3 playerPos;
    [SerializeField] int playerHealth;

    [Header("Dice")]

    [SerializeField] GameObject dice;
    [SerializeField] bool diceIsGrounded;
    Vector3 still = new Vector3(0, 0, 0);
    DiceMovement diceScript;

    [Header("Player Movement")]
    
    [Header("Jumping")]
    [SerializeField] float jumpingPower;
    [SerializeField] float jumpTimeCounter;
    [SerializeField] float jumpTime;
    [SerializeField] bool isJumping;
    [SerializeField] bool playerIsGrounded;

    [Header("Dashing")]
    [SerializeField] int dirFacing;
    [SerializeField] int dashDistance;
    [SerializeField] bool canDash;
    [SerializeField] float dashCooldownTimer;
    [SerializeField] float dashCooldown;

    [Header("Walking")]
    [SerializeField] float horizontalInput;
    [SerializeField] Rigidbody playerRB;
    [SerializeField] int speed = 5;
    [SerializeField] bool isRunningAnim;
    int isRunningAnimHash;
    int isJumpingAnimHash;
    Animator animator;
    float velocity = 0.1f;
    [SerializeField] GameObject model;

    [Header("Crouching")]
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] float currentHeight;
    [SerializeField] float normalHeight;
    [SerializeField] float crouchHeight;
    [SerializeField] float centerChange;
    [SerializeField] float animVelocity;
    [SerializeField] float crouchSpeed;
    
   
    
    [Header("Bullet")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int bulletForce;
    [SerializeField] GameObject gunArm;
    [SerializeField] GameObject gunCylinder;
    [SerializeField] int maxAmmo;
    public int MaxAmmo { get { return maxAmmo; } }
    [SerializeField] [Range(0,6)] int currentAmmo;
    Vector3 aimGun;

    [Header("Melee")]
    [SerializeField] float attackHeight;
    [SerializeField] int attackRange = 5;
    
    void Start()
    {
        canDash = true;
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        normalHeight = capsuleCollider.height;
        crouchHeight = normalHeight  / 2;
        currentHeight = normalHeight;
        animator = model.GetComponent<Animator>();
        diceScript = dice.GetComponent<DiceMovement>();
        playerRB = gameObject.GetComponent<Rigidbody>();
        isRunningAnimHash = Animator.StringToHash("IsRunning");


    }

    // Update is called once per frame
    void Update()
    {

        playerPos = gameObject.transform.position;
        diceIsGrounded = diceScript.diceIsGrounded;
        horizontalInput = Input.GetAxis("Horizontal");
        MouseAndGunAim();
        Shooting();
        Walking();
        Jumping();
        AmmoCount();
        Crouching();
        Attacking();
        Dashing();
        Rotating();
        



    }
    private void OnCollisionStay(Collision collision)
    {
        playerIsGrounded = true;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        animator.SetBool("IsInTheAir", false);
        animator.SetBool("IsLanding", true);
    }
    private void OnCollisionExit(Collision collision)
    {
        playerIsGrounded = false;
    }

    void MouseAndGunAim()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos += Camera.main.transform.forward * 14f; // Make sure to add some "depth" to the screen point
        aimGun = Camera.main.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 14f));
        gunArm.transform.LookAt(aimGun);
        
        
    }
    void AmmoCount()
    {
        if (diceIsGrounded && dice.GetComponent<Rigidbody>().velocity == still && diceScript.CountAmmoPeriod== true )
        {

            maxAmmo = diceScript.FaceValue;
              currentAmmo = maxAmmo;
            
              
           
        }
        
    }
    void Rotating()
    {
        
        if (Input.GetKeyDown(KeyCode.A)&& diceIsGrounded)
        {
            dirFacing = -1;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && diceIsGrounded)
        {
            dirFacing = 1;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }
    }

    void Walking()
    {
        if (!Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("IsRunning", false);
        }
        if (horizontalInput > 0.01 && diceIsGrounded == true && !isRunningAnim)
        {
            transform.Translate(new Vector3(1*horizontalInput,0,0) * speed * Time.deltaTime);
            animator.SetBool(isRunningAnimHash, true);
            if (animator.GetBool("IsCrouching") == true)
            {
                Debug.Log("Crouch running right");
                speed = 2;
            }


        }
            
        if (horizontalInput < -0.01 && diceIsGrounded == true&& !isRunningAnim)
        {
            transform.Translate(new Vector3(-1*horizontalInput,0,0) * speed * Time.deltaTime);
                animator.SetBool(isRunningAnimHash,true);

            if (animator.GetBool("IsCrouching") == true)
            {
                Debug.Log("Crouch running left");
                speed = 2;
            }
        }
        
        


    }
    void Crouching()
    {
        Vector3 capsuleColliderCenter = gameObject.GetComponent<CapsuleCollider>().center;
         
        if (Input.GetKey(KeyCode.C) )
        {
            gameObject.GetComponent<CapsuleCollider>().height = crouchHeight; // set collider height to crouch height

            animator.SetBool("IsCrouching", true); // start animation

            if (gameObject.GetComponent<CapsuleCollider>().center.y > centerChange) // change the center of the collider to match crouch hitbox
            {
                gameObject.GetComponent<CapsuleCollider>().center = new Vector3(capsuleColliderCenter.x, capsuleColliderCenter.y + centerChange, capsuleColliderCenter.z);
            }
            if (Input.GetKey(KeyCode.C) && animator.GetBool("IsRunning")==true && animator.GetBool("IsCrouching")== true) // crouch running animation
            {
                animVelocity = 0.3f;
                animator.SetFloat("Velocity", animVelocity);
            }
            else
            {
                animVelocity = 0f;
                animator.SetFloat("Velocity", animVelocity);
            }


            
        }
       
        else
        {
            //stop all crouching, change the collider height and collider center back to original position
            animVelocity = 0f; 
            animator.SetFloat("Velocity", animVelocity);
            animator.SetBool("IsCrouching", false);
            speed = 5;
            gameObject.GetComponent<CapsuleCollider>().height = crouchHeight * 2;
            gameObject.GetComponent<CapsuleCollider>().center = new Vector3(capsuleColliderCenter.x, 0f, capsuleColliderCenter.z);


        }
        

    }
    void Jumping ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && diceIsGrounded == true && playerIsGrounded == true)
        {
            //transform.Translate(Vector3.up);
            animator.SetFloat("Velocity", Time.deltaTime * velocity);
            playerRB.AddForce(Vector3.up * jumpingPower, ForceMode.Impulse);

            animator.SetTrigger("Jump");
            
            jumpTimeCounter = jumpTime;
            animator.SetBool("IsInTheAir", true);
            animator.SetBool("IsLanding", false);
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.Space)&& isJumping == true)
        {
            if (jumpTimeCounter>0)
            {
                playerRB.AddForce(Vector3.up* jumpingPower);
                jumpTimeCounter -= Time.deltaTime;
                animator.SetBool("IsInTheAir", true);
            }
            else
            {
                animator.SetFloat("Velocity", Time.deltaTime * -velocity);
                isJumping = false;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if (gameObject.transform.position.y> 10)
        {
            playerRB.AddForce(Vector3.down,ForceMode.Acceleration);
            
        }
        
    }
    void Shooting()
    {
       
        if (Input.GetMouseButtonDown(0) && diceIsGrounded == true&& currentAmmo>0) 
        {
            
            Debug.Log("im shooting");
            GameObject bullet =  Instantiate(bulletPrefab, gunCylinder.transform.position, Quaternion.identity);
            bullet.transform.LookAt(aimGun);
            Vector3 direction = aimGun - gameObject.transform.position;
            Vector3 movingStep = direction.normalized * bulletForce;
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(movingStep, ForceMode.Impulse);
            currentAmmo--;
        }
    }
    void Attacking()
    {
        if (Input.GetKey(KeyCode.Mouse2)&& diceIsGrounded)
        {
            Ray hitRay = new Ray(new Vector3(playerPos.x,playerPos.y+attackHeight,playerPos.z), Vector3.right * attackRange) ;
            Debug.DrawRay(new Vector3(playerPos.x, playerPos.y + attackHeight, playerPos.z), Vector3.right * attackRange);
        }
    }
   
    void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && diceIsGrounded&& canDash== true)
        {
            playerRB.AddForce(new Vector3(1*dirFacing,0,0) * dashDistance, ForceMode.Impulse);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsDashing", true);
            animator.SetTrigger("Dash");
            canDash = false;
            dashCooldownTimer = dashCooldown;
            
         
            

            if (animator.GetBool("IsCrouching")== true)
            {
                animator.SetTrigger("Slide");
            }
        }
        else
        {
            animator.SetBool("IsDashing", false);
        }
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;

        }
        if (dashCooldownTimer <= 0)
        {
            canDash = true;
        }

    }


    
}
