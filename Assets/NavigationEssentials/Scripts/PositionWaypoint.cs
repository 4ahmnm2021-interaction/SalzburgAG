using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionWaypoint : MonoBehaviour
{
    public int id;
    private void Update()
    {
        if (id < drawNavPath.instance.path.corners.Length)
        gameObject.transform.position = drawNavPath.instance.path.corners[id];
    }
    

}
