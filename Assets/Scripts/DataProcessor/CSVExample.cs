using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using System.IO;

public class CSVExample : MonoBehaviour
{
    public Freischaltschein MySchein = new Freischaltschein();
    public Anlage Anlage = new Anlage();

    private string ApplicationPath;

    void Start()
    {
        ApplicationPath = Application.dataPath;

        var reader = new StreamReader(ApplicationPath + "/CSV/sample.csv");
        var csv = new CsvReader(reader);

        csv.Configuration.Delimiter = ";";

        var records = csv.GetRecords<Anlage>();

    

        foreach (var item in records)
        {
            Debug.Log("ID: " + item.KKS + " / Name: " + item.Bezeichnung);
       
        }

   
       
        
    }

}

// public class Anlage
// {
//     public string KKS{ get; set; }
//     public string Bezeichnung { get; set; }

//     public string Ort { get; set; }

//     public string IST { get; set; }

//     public string SOLL { get; set; }
// }


// public class Freischaltschein
// {
//     public int Nummer{ get; set; }
//     public string Datum{ get; set; }

//     public Anlage[] Anlagen;


// }

// public class FreischaltscheinFetch
// {
//     public string Nummer{ get; set; }
//     public string Datum{ get; set; }
// }


