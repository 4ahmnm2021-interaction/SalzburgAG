using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkstepsLoader : MonoBehaviour
{
    public GameObject StepPrefap;

    public DataProcessor DataProcessor;
    void Start()
    {
        var Schein = DataProcessor.currentSchein;

        foreach(var Anlage in Schein.Anlagen) {
            var Task = "unbekannt";
            GameObject Step = Instantiate(StepPrefap, new Vector3 (0,0,0), Quaternion.identity) as GameObject; 
            Step.transform.parent = this.gameObject.transform;
            if(Anlage.SOLL == "ZU") {Task = " öffnen";
            } else {Task = " schließen";}
            var MainTxt = Anlage.KKS.ToString() + Task;
            Step.transform.Find("MainTxt").GetComponent<Text>().text = MainTxt;
            var SubTxt = "mech; " + "AC Druckluft; " + Anlage.Ort.ToString();
            Step.transform.Find("Controller_checkbox").GetComponent<WorkStepsManager>().KKS = Anlage.KKS.ToString();
            Debug.Log(Anlage.Bezeichnung);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
