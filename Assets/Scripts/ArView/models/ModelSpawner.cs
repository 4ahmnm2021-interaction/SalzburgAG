using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModelSpawner : MonoBehaviour
{
    public Freischaltschein Schein;
    public DataProcessor DataProcessor;
    public List<GameObject> Prefaps;

    public GameObject SpawnPositions;
    void Start()
    {
        Schein = DataProcessor.Schein;
        foreach(var Anlage in Schein.Anlagen) {
            if(Anlage.Type == "Sicherung") {
                var pref = InstantiatePrefap(Prefaps[0], Anlage);
                pref.transform.GetComponent<AnlageObj>().SetData(Anlage, Anlage.Type);
            }
            if(Anlage.Type == "VentilA") {
                var pref = InstantiatePrefap(Prefaps[1], Anlage);
                pref.transform.GetComponent<AnlageObj>().SetData(Anlage, Anlage.Type);
            }
           if(Anlage.Type == "VentilB") {
                var pref = InstantiatePrefap(Prefaps[2], Anlage);
                pref.transform.GetComponent<AnlageObj>().SetData(Anlage, Anlage.Type);
            }
           if(Anlage.Type == "VentilC") {
                var pref = InstantiatePrefap(Prefaps[3], Anlage);
                pref.transform.GetComponent<AnlageObj>().SetData(Anlage, Anlage.Type);
            }
        }
        
    }

    private GameObject InstantiatePrefap(GameObject prefab, Anlage Anlage) {
        var pref = Instantiate(prefab, Anlage.position,  Quaternion.Euler(0f, 90f, 0f));
        pref.transform.SetParent(RandomSpawnPoint());
        pref.transform.localPosition = new Vector3(0,0,0);
        pref.transform.localScale = new Vector3(1f,1f,1f);
        pref.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        return pref;
    }

    // private void SetData(Anlage Anlage, string type, GameObject obj) {
    //     if(type == "Sicherung") {
    //       // Set Name
    //       obj.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = Anlage.KKS;
    //       // Set Status
    //       if(Anlage.IST == "ZU") {
    //        obj.transform.GetChild(0).localRotation = Quaternion.Euler(-266, -90f, 90f);
    //        }
    //     }
    //     if(type == "VentilA" || type == "VentilB") {
    //         obj.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = Anlage.KKS;
    //     }
    //     if(type == "VentilC") {
    //         obj.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = Anlage.KKS;
    //         // obj.transform.GetChild(5).GetChild(2).GetChild(1).GetComponent<Text>().text = Anlage.KKS;
    //     }
    // }

    Transform RandomSpawnPoint() {
        while(true) {
            var point = SpawnPositions.transform.GetChild(Random.Range(0, SpawnPositions.transform.childCount));
            if(point.childCount == 0) {
                return point;
            }
        }
    }

}
