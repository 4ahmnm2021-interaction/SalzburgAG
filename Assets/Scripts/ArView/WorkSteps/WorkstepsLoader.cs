using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkstepsLoader : MonoBehaviour
{
    public GameObject StepPrefap;

    public DataProcessor DataProcessor;
    void Start()
    {
        var Schein = DataProcessor.currentSchein;

        foreach(var Anlage in Schein.Anlagen) {
            Debug.Log(Anlage.Bezeichnung);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
