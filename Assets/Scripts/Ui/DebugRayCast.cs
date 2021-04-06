using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRayCast : MonoBehaviour
{
    public PopupBase Base;
    // Start is called before the first frame update
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))  {
                var ray  = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity); 

                if(hit.collider != null) {
                    // Debug.Log(hit.collider.gameObject.name);
                    if(hit.collider.gameObject.name == "WorkSteps") {
                   
                    }
                } else {

                Debug.Log("no hit");
                }
            
            }

        
    }
}
