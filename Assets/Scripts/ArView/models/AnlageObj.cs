using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnlageObj : MonoBehaviour
{
    public string KKS;
    public string Bezeichnung;
    public string Type;
    public string Ort;
    public string IST;
    public string SOLL;
    public Vector3 position;

    public DataProcessor processor;

    public GameObject Needel; 

    public Transform pos1;

    void Start() {
        processor = GameObject.Find("DataProcessor").GetComponent<DataProcessor>();

        
    }

    void Update() {
        if(Type == "VentilA" || Type == "VentilB") {
            
            // Needel.transform.Rotate(0,90 * Time.deltaTime * 1 ,0, Space.Self);
            Needel.transform.rotation = Quaternion.Lerp(Needel.transform.rotation, pos1.rotation, Time.time * 1);
            // Debug.Log(Needel.transform.rotation);

        }
    }

    public void SetData(Anlage Anlage, string type) {
        if(type == "Sicherung") {
            // Set Name
            this.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = Anlage.KKS;
            // Set Status
            if(Anlage.IST == "ZU") {
                this.transform.GetChild(0).localRotation = Quaternion.Euler(-266, -90f, 90f);
            }
        }
        if(type == "VentilA" || type == "VentilB") {
            this.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = Anlage.KKS;
            Needel =  this.gameObject.transform.Find("Nadel").gameObject;
            if(Type == "VentilA") {
                pos1 = this.gameObject.transform.GetChild(6).GetChild(0);
            } else {pos1 = this.gameObject.transform.GetChild(5).GetChild(0);}
        }
        if(type == "VentilC") {
            this.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = Anlage.KKS;
            // obj.transform.GetChild(5).GetChild(2).GetChild(1).GetComponent<Text>().text = Anlage.KKS;
        }

        RegisterData(Anlage);
    }

    public void RegisterData(Anlage Anlage) {
        KKS = Anlage.KKS;
        Bezeichnung = Anlage.Bezeichnung;
        Type = Anlage.Type;
        Ort = Anlage.Ort;
        IST = Anlage.IST;
        SOLL = Anlage.SOLL;
        position = Anlage.position;
    }

    public void ChangeState() {
        IST = processor.StatusSwitch(KKS);
        
    }

    private void SetVisual() {
        if(IST == "OFFEN") {
            Open();    
        } else {
            Close();
        }
    }

    private void Close() {

    }

    private void Open() {
        if(Type == "Sicherung") {

        }
        else if(Type == "VentilA" || Type == "VentilB") {

        }
    }
}
