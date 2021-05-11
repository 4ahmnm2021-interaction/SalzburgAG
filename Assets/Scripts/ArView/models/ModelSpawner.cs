using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ModelSpawner : MonoBehaviour
{
    public Freischaltschein Schein;
    public DataProcessor DataProcessor;
    public List<GameObject> Prefaps;
    void Start()
    {
        Schein = DataProcessor.Schein;
        foreach(var Anlage in Schein.Anlagen) {
            if(Anlage.Type == "Sicherung") {
                var pref = InstantiatePrefap(Prefaps[2], Anlage);
                SetData(Anlage, Anlage.Type, pref);
            }
        }
        
    }

    private GameObject InstantiatePrefap(GameObject prefab, Anlage Anlage) {
        var pref = Instantiate(prefab, Anlage.position,  Quaternion.Euler(0f, 90f, 0f));
        pref.transform.parent = this.gameObject.transform;
        pref.transform.position = Anlage.position;
        pref.transform.localScale = new Vector3(13f,13f,13f);
        return pref;
    }

    private void SetData(Anlage Anlage, string type, GameObject obj) {
        if(type == "Sicherung") {
            obj.transform.FindChild("Text").GetComponent<Text>().text = Anlage.KKS;
        }
    }

}
