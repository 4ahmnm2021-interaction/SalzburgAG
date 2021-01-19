using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Toggel() {
        SystemEvents.current.PopupClose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
