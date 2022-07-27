using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    
    public GameObject platform;
    public bool diceIsGrounded= false;  

    private void Update()
    {

    if (Input.GetMouseButtonDown(1)&& diceIsGrounded==false)
        {
            Debug.Log("spawning platform");
            Instantiate(platform, Input.mousePosition, Quaternion.identity);
        }
        
    }
}
