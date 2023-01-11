using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilities : MonoBehaviour
{
    [Header("Defense Stats")]

    public int[] lightDrolls;
    public int[] heavyDrolls;
    public int[] shootDrolls;

    [Header("Movement")]

    public int moveSpeed;
    private Vector3 enemyDirection;

    [Header("Available Abilities")]
    public bool dashActive;
    public bool jumpActive;
    public bool crouchActive;
    public bool shootActive;
    public bool heavyAttackActive;
    public bool lightAttackActive;

    [Header("Attacks Properties")]
    public int bulletsAvailable;
    public int lightAttackRange;
    public float lightAttackSpeed;
    public int heavyAttackRange;
    public float heavyAttackSpeed;
    public int heavyAttackDMG;
    public int lightAttackDMG;

    [Header("Crouch Properties")]
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] float currentHeight;
    [SerializeField] float normalHeight;
    [SerializeField] float crouchHeight;
    [SerializeField] float centerChange;
    [SerializeField] float crouchTime;
    [SerializeField] float crouchTimer;

    [Header("Jump Properties")]


    [Header("Status")]
    GameObject target;
    PlayerMovement targetScript;
    private bool canDash;
    private bool isRetreating;
    

    private void Awake()
    {

        NPCEnemies _npcEnemies =GetComponent<NPCEnemies>();
        target = _npcEnemies.target;
        targetScript = target.GetComponent<PlayerMovement>();
        canDash = true;
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        normalHeight = capsuleCollider.height;
        crouchHeight = normalHeight / 2;
        currentHeight = normalHeight;
    }
    private void Update()
    {
        DetermineDirection();
        
    }
    public void Dash(Vector3 dir)
    {

    }
    public void Jump(float jumpPower)
    {

    }
    public void Crouch()
    {
        StartCoroutine("CrouchTimer");
        Debug.Log("starting crouch timer");
        
        
        
    }
    IEnumerator CrouchTimer()
    {
        Vector3 capsuleColliderCenter = gameObject.GetComponent<CapsuleCollider>().center;
        capsuleCollider.height = crouchHeight; // set collider height to crouch height

        // start animation

        if (capsuleCollider.center.y > centerChange) // change the center of the collider to match crouch hitbox
        {
            capsuleCollider.center = new Vector3(capsuleColliderCenter.x, capsuleColliderCenter.y + centerChange, capsuleColliderCenter.z);
        }
        yield return new WaitForSeconds(crouchTime);
        capsuleCollider.height = normalHeight;
        Debug.Log("ending crouch");
        
    }
    public void LightAttackCall ()
    {
        StartCoroutine("LightAttack");
    }
    public void HeavyAttackCall()
    {
        StartCoroutine("HeavyAttack");
    }
    public void Shoot(Vector3 dir)
    {

    }
    IEnumerator LightAttack()
    {
        //play animation
        yield return new WaitForSeconds(lightAttackSpeed);
        RaycastHit lightAttackHit;
        Ray lightAttackRay = new Ray(gameObject.transform.position, enemyDirection * lightAttackRange);
        if (Physics.Raycast(lightAttackRay, out lightAttackHit, lightAttackRange))
        {
            targetScript.TakeDamage(lightAttackDMG);
        }

    }
    IEnumerator HeavyAttack()
    {
        //play animation
        yield return new WaitForSeconds(heavyAttackSpeed);
        RaycastHit heavyAttackHit;
        Ray heavyAttackRay = new Ray(gameObject.transform.position, enemyDirection * heavyAttackRange);
        if (Physics.Raycast(heavyAttackRay, out heavyAttackHit, heavyAttackRange))
        {
           targetScript.TakeDamage(heavyAttackDMG);
        }
    }

    public void DetermineDirection()
    {
        if (isRetreating == true)
        {
            if (target.transform.position.x > transform.position.x)
            {
                enemyDirection = Vector3.left;
            }
            if (target.transform.position.x < transform.position.x)
            {
                enemyDirection = Vector3.right;
            }
        }
        else
        {
            if (target.transform.position.x < transform.position.x)
            {
                enemyDirection = Vector3.left;
            }
            if (target.transform.position.x > transform.position.x)
            {
                enemyDirection = Vector3.right;
            }
        }
        
    }
    public void Movement()
    {
        
        gameObject.transform.Translate(enemyDirection * moveSpeed * Time.deltaTime);
    }

}
