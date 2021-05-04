﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;

public  enum TypeEnum{VentilA, VentilB,Sicherung};

public class DataProcessor : MonoBehaviour
{
    private string ApplicationPath;
    public Freischaltschein Schein = new Freischaltschein();

    public List<Freischaltschein> Freischaltscheine = new List<Freischaltschein>();

    public Freischaltschein currentSchein;
    
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
            if(counter != 0) 
            {
                // Serialize Anlagen Data
                var c = 0;
                var TmpAnlage = new Anlage();
                foreach(var item in data_values) {
                    if(c == 0) {TmpAnlage.KKS = item.ToString();}
                    if(c == 1) {TmpAnlage.Bezeichnung = item.ToString();}
                    if(c == 2) 
                    {
                        TypeEnum parsed_enum = (TypeEnum)System.Enum.Parse( typeof(TypeEnum), item.ToString() );
                        TmpAnlage.Type = parsed_enum;
                    }
                    if(c == 2) {TmpAnlage.Ort = item.ToString();}
                    if(c == 3) {TmpAnlage.IST = item.ToString();}
                    if(c == 4) {TmpAnlage.SOLL = item.ToString();}
                    c++;
                }
                Schein.Anlagen.Add(TmpAnlage);

                // Serialize General Freischaltschein Data
                if(counter == 1) 
                {
                    c = 0;
                    TmpAnlage = new Anlage();
                    foreach(var item in data_values) {
                        if(c == 5) 
                        {
                            int.TryParse(item, out var num);
                            Schein.Nummer = num;
                        }
                        if(c == 6) {Schein.Datum = item.ToString();}
                        c++;
                    }
                }
            }
            counter ++;
           
        }
        currentSchein = Schein;
        Freischaltscheine.Add(Schein);
        DebugObject();
    }
    void DebugObject() {
        Debug.Log("Schein Nummer: " + Schein.Nummer + " | Schein Datum: " + Schein.Datum + " |  Anlagen Anzahl: " + Schein.Anlagen.Count);
        foreach(var item in Schein.Anlagen)
        {
             Debug.Log(item.KKS + " | " + item.Bezeichnung + " | " + item.Type + " | "  + item.Ort +  " | " +  item.IST + " | " + item.SOLL );  
        }
    }
}

public class Anlage
{
    public string KKS;
    public string Bezeichnung ;

    public TypeEnum Type;
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