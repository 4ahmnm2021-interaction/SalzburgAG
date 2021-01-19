using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupExpand : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 destination;
    private float speed;
    public GameObject Base;
    private Vector3 BasePos;
    private bool close = false;

    void Start()
    {
        SystemEvents.current.onPopupClose += ClosePopup;
        destination = gameObject.transform.position;
        BasePos = Base.transform.position;
        speed = 0.2F;
    }

    // Update is called once per frame
    void Update()
    {
        if(close) {
            transform.position = Vector3.Lerp(transform.position, BasePos, speed);
        } else {
               transform.position = Vector3.Lerp(transform.position, destination, speed);
        }
    }

    private void ClosePopup() {
        Debug.Log("tets");
        if(close == true) {
            close = false;
        } else {
            close = true;
        }

    }

}


