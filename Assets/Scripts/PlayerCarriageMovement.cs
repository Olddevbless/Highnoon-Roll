using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerCarriageMovement : MonoBehaviour
{
    NavMeshAgent agent;
    [Header("Buttons")]
    public GameObject[] locations;
    public Camera mainCamera;
    public GameObject cursorSphere;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit,Mathf.Infinity))
            {
                agent.SetDestination(raycastHit.point);
                //gameObject.transform.Translate(Vector3.MoveTowards(gameObject.transform.position, raycastHit.point, 10f * Time.deltaTime));
            }
                
            //for (int i = 0; i < locations.Length; i++)
            //{
                //gameObject.transform.Translate(Vector3.MoveTowards(gameObject.transform.position, locations[i].transform.position));
            //}
        }
        
    }
    
}
