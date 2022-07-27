using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    
    public GameObject platform;
    public GameObject dice;
    public bool diceIsGrounded;

    private void Update()
    {
        diceIsGrounded = dice.GetComponent<DiceMovement>().diceIsGrounded;
    if (Input.GetMouseButtonDown(1)&& diceIsGrounded==false)
        {
            Debug.Log("spawning platform");
            Instantiate(platform, Input.mousePosition, Quaternion.identity);
        }
        
    }
}
