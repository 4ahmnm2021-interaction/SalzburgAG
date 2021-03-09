using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBase : MonoBehaviour
{
    public void Toggel() {
        SystemEvents.current.PopupClose();
            Debug.Log("Sprite Clicked");
    }
    void OnMouseDown(){
        Debug.Log("Sprite Clicked");
        Toggel();
    }   



    
}
