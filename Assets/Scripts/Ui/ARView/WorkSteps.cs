using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkSteps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SystemEvents.current.onWorkStepsToggle += Toggle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Toggle() {
        Debug.Log("toggle test");
    }
}
