using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMovement : MonoBehaviour
{
    public bool diceIsGrounded;
    Rigidbody diceRB;
    [SerializeField] GameObject[] dieFaces;
    [SerializeField] GameObject player;
    [SerializeField] int faceValue;
    public int FaceValue { get { return faceValue; } }
    [SerializeField]  bool countAmmoPeriod;
    public bool CountAmmoPeriod { get { return countAmmoPeriod; } }


    private void Start()
    {
        
        countAmmoPeriod = true;
        diceRB = gameObject.GetComponent<Rigidbody>();
        diceRB.AddTorque(new Vector3(1,1,1), ForceMode.Impulse);
        diceRB.AddForce(Vector3.right, ForceMode.Impulse);
        diceIsGrounded = false;
       
    }
    private void Update()
    {
        if (diceIsGrounded && countAmmoPeriod == true && diceRB.velocity == new Vector3(0, 0, 0))
        {

            faceValue = GetFaceValue(dieFaces);
            if (player.GetComponent<PlayerMovement>().MaxAmmo>0)
            {
                countAmmoPeriod = false;
            }
            

        }
    }


    public int GetFaceValue(GameObject[] dieFaces)
    {
        int[] facesVal = new int[] { 1, 2, 3, 4, 5, 6 };
        Debug.Log("getting faceValue");
        GameObject highestFace = dieFaces[0];
        int iValue=0;
        for (int i=0; i<6; i++)
        {
            if (dieFaces[i].transform.position.y > highestFace.transform.position.y)
            {
                iValue = i;
                highestFace = dieFaces[i];
                Debug.Log("iValue =" + iValue);
                Debug.Log(highestFace.name);
                

            }

            
        }
        return facesVal[iValue];
        
        

    }
    
    private void OnCollisionEnter(Collision collision)
    {

        diceIsGrounded = true;
        
    }
}
