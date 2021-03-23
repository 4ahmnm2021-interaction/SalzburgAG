using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SystemEvents : MonoBehaviour
{
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

    public event Action onScreenCloseAll;
    public void ScreenCloseAll() {
        if(onScreenCloseAll != null) {
            onScreenCloseAll();
        }
    }

    public event Action onWorkStepsToggle;
    public void WorkStepsToggle() {
        if(onWorkStepsToggle != null) {
            onWorkStepsToggle();
        }
    }

}
