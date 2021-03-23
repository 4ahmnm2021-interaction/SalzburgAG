﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0))  {
                var ray  = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity); 

                if(hit.collider != null) {
                    Debug.Log(hit.collider.gameObject.name);
    
                } else {

                Debug.Log("no hit");
                }
            
            }

        
    }
}
