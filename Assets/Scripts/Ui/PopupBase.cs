using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBase : MonoBehaviour
{
    public GameObject DiffLayer;
    private bool diffLayer = false;
    public void Toggel() {
        SystemEvents.current.PopupClose();
        if(diffLayer == false) {
            DiffLayer.SetActive(true);
            diffLayer = true;
        } else
        {
            DiffLayer.SetActive(false);
            diffLayer = false;
        }
    }
    void OnMouseDown(){
        Toggel();
    }   



    
}
