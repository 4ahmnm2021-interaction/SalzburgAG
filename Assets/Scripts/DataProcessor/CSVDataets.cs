using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;



public class CSVDataets : MonoBehaviour
{
    private string ApplicationPath;

    public Freischaltschein Schein = new Freischaltschein();
    
    void Start()
    {
    
        ReadCSVFile();
    }

    void ReadCSVFile() {

        var counter = 0;
        ApplicationPath = Application.dataPath;
        StreamReader strReader = new StreamReader(ApplicationPath + "/CSV/sample.csv");
        bool endOfFile = false;
        while(!endOfFile)
        {
            string data_String = strReader.ReadLine();
            if(data_String == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(';');
            if(counter != 0) {
                var c = 0;
                var TmpAnlage = new Anlage();
                foreach(var item in data_values) {
                    if(c == 0) {TmpAnlage.KKS = item.ToString();}
                    if(c == 1) {TmpAnlage.Bezeichnung = item.ToString();}
                    if(c == 2) {TmpAnlage.Ort = item.ToString();}
                    if(c == 3) {TmpAnlage.IST = item.ToString();}
                    if(c == 4) {TmpAnlage.SOLL = item.ToString();}
                    c++;
                }
                Schein.Anlagen.Add(TmpAnlage);
            }
            counter ++;
           
        }
        DebugObject();
    }

    void DebugObject() {
        Debug.Log(Schein.Anlagen.Count);
        foreach(var item in Schein.Anlagen)
        {
             Debug.Log(item.KKS + " | " + item.Bezeichnung + " | " + item.Ort +  " | " +  item.IST + " | " + item.SOLL );  
        }
    }


}


public class Anlage
{
    public string KKS;
    public string Bezeichnung ;
    public string Ort ;
    public string IST ;
    public string SOLL ;
}




public class Freischaltschein
{
    public int Nummer;
    public string Datum;

    public List<Anlage> Anlagen = new List<Anlage>();


}