using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public List<GameObject> Screens;
    // Start is called before the first frame update
    void Start()
    {        
        SystemEvents.current.onScreenCloseAll += ScreenCloseAll;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenCloseAll() {
        foreach(GameObject Screen in Screens) {
            Screen.SetActive(false);
        }
    }
}
