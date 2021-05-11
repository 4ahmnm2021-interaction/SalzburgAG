using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSpawner : MonoBehaviour
{
    public Freischaltschein Schein;

    public List<GameObject> Prefaps;
    void Start()
    {
        Schein = gameObject.transform.Find("DataProcessor").GetComponent<DataProcessor>().Schein;
        foreach(var Anlage in Schein.Anlagen) {
            if(Anlage.Type == "Sicherung") {
                InstantiatePrefap(Prefaps[2], Anlage);
            }
        }
        
    }

    void InstantiatePrefap(GameObject prefab, Anlage Anlage) {
        Instantiate(prefab, Anlage.position, Quaternion.identity);
    }

}
