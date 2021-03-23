
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class PopupBase : MonoBehaviour
{
    public GameObject DiffLayer;
    private bool diffLayer = false;
    public Sprite baseclose;
    public Sprite baseopen;

    public void Toggel() {
        SystemEvents.current.PopupClose();
        if(diffLayer == false) {
            DiffLayer.SetActive(true);
            diffLayer = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = baseopen;
        } else
        {
            DiffLayer.SetActive(false);
            diffLayer = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = baseclose;
        }
    }

    void OnMouseDown(){
        Toggel();
    }   



    
}
