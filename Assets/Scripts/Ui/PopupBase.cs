using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBase : MonoBehaviour
{
    public void Toggel() {
        SystemEvents.current.PopupClose();
    }
}
