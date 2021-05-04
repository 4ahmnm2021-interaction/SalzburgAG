using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstepsLoader : MonoBehaviour
{
    public GameObject StepPrefap;
    public Freischaltschein Schein;

    public DataProcessor DataProcessor;
    void Start()
    {
        Schein = DataProcessor.currentSchein;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
