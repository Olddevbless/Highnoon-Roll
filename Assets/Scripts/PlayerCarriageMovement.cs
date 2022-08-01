using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarriageMovement : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject[] locations;
    public Camera mainCamera;
    public GameObject cursorSphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out RaycastHit raycastHit))
        {
            cursorSphere.transform.position = raycastHit.point;
        }
        
        if (Input.GetMouseButton(0))
        {
            gameObject.transform.Translate(Vector3.MoveTowards(gameObject.transform.position, new Vector3(cursorSphere.transform.position.x,2,cursorSphere.transform.position.z), 10f*Time.deltaTime));
            //for (int i = 0; i < locations.Length; i++)
            //{
                //gameObject.transform.Translate(Vector3.MoveTowards(gameObject.transform.position, locations[i].transform.position));
            //}
        }
        
    }
    
}
