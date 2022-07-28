using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    
    public GameObject platform;
    public GameObject dice;
    public bool diceIsGrounded;
    public Camera mainCamera;
    Vector3 aim;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos += Camera.main.transform.forward * 30f; // Make sure to add some "depth" to the screen point
        aim = Camera.main.ScreenToWorldPoint(new Vector3(mousePos[0], mousePos[1], 15f));
        diceIsGrounded = dice.GetComponent<DiceMovement>().diceIsGrounded;
    if (Input.GetMouseButtonDown(1)&& diceIsGrounded==false)
        {
            Debug.Log("spawning platform");
            Instantiate(platform, aim, platform.transform.rotation);
        }
        
    }
}
