using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SystemEvents : MonoBehaviour
{
    // Start is called before the first frame update

    public static SystemEvents current;
    private void Awake()
    {
        current = this;
    }

    public event Action onPopupClose;
    public void PopupClose() {
        if(onPopupClose != null) {
            onPopupClose();
        }
    }

}
