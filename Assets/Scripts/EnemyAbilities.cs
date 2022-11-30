using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilities : MonoBehaviour
{
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
    public int heavyAttackRange;
    public int heavyAttackDMG;
    public int lightAttackDMG;

    [Header("Crouch Properties")]
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] float currentHeight;
    [SerializeField] float normalHeight;
    [SerializeField] float crouchHeight;
    [SerializeField] float centerChange;

    [Header("Jump Properties")]
    

    [Header("Status")]
    private bool canDash;
    

    private void Awake()
    {
        canDash = true;
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        normalHeight = capsuleCollider.height;
        crouchHeight = normalHeight / 2;
        currentHeight = normalHeight;
    }
    public void Dash(Vector3 dir)
    {

    }
    public void Jump(float jumpPower)
    {

    }
    public void Crouch()
    {
        Vector3 capsuleColliderCenter = gameObject.GetComponent<CapsuleCollider>().center;
        gameObject.GetComponent<CapsuleCollider>().height = crouchHeight; // set collider height to crouch height

        // start animation

        if (gameObject.GetComponent<CapsuleCollider>().center.y > centerChange) // change the center of the collider to match crouch hitbox
        {
            gameObject.GetComponent<CapsuleCollider>().center = new Vector3(capsuleColliderCenter.x, capsuleColliderCenter.y + centerChange, capsuleColliderCenter.z);
        }
    }
    public void LightAttack()
    {

    }
    public void HeavyAttack()
    {

    }
    public void Shot(Vector3 dir)
    {

    }

}
