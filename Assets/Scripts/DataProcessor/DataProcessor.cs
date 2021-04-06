using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataProcessor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FreischaltscheinClass Schein = new FreischaltscheinClass();
        Schein.Identifier = "MyIdentifier";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
