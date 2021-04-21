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

    // Subs: ScreenController
    // Trigers: FreischaltscheinPanel
    public event Action onScreenCloseAll;
    public void ScreenCloseAll() {
        if(onScreenCloseAll != null) {
            onScreenCloseAll();
        }
    }

    // Subs: ScreenController
    // Triggers: PopupExpand
    public event Action<string> onModuleToggle;
    public void ModuleToggle(string name) {
        if(onModuleToggle != null) {
            onModuleToggle(name);
        }
    }

    // Subs: ScreenController
    // Triggers: FreischaltscheinPanel
    public event Action<string> onScreenOpen;
    public void ScreenOpen(string name) {
        if(onScreenOpen != null) {
            onScreenOpen(name);
        }
    }

}
