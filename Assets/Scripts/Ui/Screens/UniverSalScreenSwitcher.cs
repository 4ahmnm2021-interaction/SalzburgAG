using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverSalScreenSwitcher : MonoBehaviour
{
    public GameObject Screen;
     private void OnMouseDown() {
        SystemEvents.current.ScreenCloseAll();
        SystemEvents.current.ScreenOpen(Screen.name);
    }
}
