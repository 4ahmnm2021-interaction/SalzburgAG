using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointer : MonoBehaviour
{

    public Vector3 lookAtAngle;
    public float strength;

    
    public GameObject target;
    public Camera camera;
    public Vector3 screenPos;

    public bool useWaypoints; 

    private void Update()
    {
        if (!useWaypoints)
        {
            target = GetActiveDestination();
        }
        if (useWaypoints)
        {
            target = drawNavPath.instance.checkpoints[0];
        }
        
        if (!IsVisible(target))
        {
            DisplayArrow();
        }
        else
            gameObject.transform.GetChild(0).gameObject.SetActive(true); 
    }

    void DisplayArrow()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        transform.LookAt(drawNavPath.instance.destination[drawNavPath.instance.destionIndex]);
        lookAtAngle = transform.localEulerAngles;

        if (lookAtAngle.z < 300)
            transform.localEulerAngles = new Vector3(lookAtAngle.x * strength, 90, 0);
        else
            transform.localEulerAngles = new Vector3(lookAtAngle.x * strength, -90, 0);
    }

    private bool IsVisible(GameObject visibleObject)
    {
        Debug.DrawRay(visibleObject.transform.position, camera.transform.position - visibleObject.transform.position,  Color.yellow);
        
        screenPos = camera.WorldToScreenPoint(target.transform.position);
     
        if (visibleObject.GetComponent<Renderer>().isVisible & !Physics.Raycast(visibleObject.transform.position, camera.transform.position - visibleObject.transform.position, Vector3.Distance(visibleObject.transform.position, camera.transform.position))) //drawNavPath.instance.destination[drawNavPath.instance.destionIndex].transform.GetComponent<Renderer>().isVisible
        {
            
            print("Is Visble");
            return true;
        }
        else
        {
            print("Is not Visble");
            return false;
        }

    }
    private GameObject GetActiveDestination()
    {
        Transform currentDestination = drawNavPath.instance.destination[drawNavPath.instance.destionIndex];
        return currentDestination.gameObject;
    }

    

}
