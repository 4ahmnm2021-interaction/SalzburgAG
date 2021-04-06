using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class popupExpand : MonoBehaviour
{
    private Vector3 destination;
    private float speed;
    public GameObject Base;
    private Vector3 BasePos;
    private bool close = false;

    private bool ModuleActive = false;

    private Sprite closedSprite; 
    public Sprite openSprite;
    void Start()
    {

        closedSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        SystemEvents.current.onPopupClose += TogglePopup;
        destination = gameObject.transform.position;
        BasePos = Base.transform.position;
        speed = 0.2F;

        TogglePopup();
    }

    void Update()
    {
        if(close) {
            transform.position = Vector3.Lerp(transform.position, BasePos, speed);
        } 
        if(close == false) {

            transform.position = Vector3.Lerp(transform.position, destination, speed);

        }
    }

    private void TogglePopup() {
        if(close == true) 
        {
            this.gameObject.layer= 0;
            close = false;  
        } else 
        { 
            this.gameObject.layer= 2;
            close = true; 
        }
    }


     void OnMouseDown(){
        SystemEvents.current.ModuleToggle(this.gameObject.name);
        if(ModuleActive) {
             this.gameObject.GetComponent<SpriteRenderer>().sprite = closedSprite;
             ModuleActive = false;
        } else {
              this.gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
              ModuleActive = true;
        }
    } 



}


