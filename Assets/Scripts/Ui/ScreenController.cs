using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public List<GameObject> Screens;
    public List<GameObject> ARModules;
    // Start is called before the first frame update
    void Start()
    {        
        SystemEvents.current.onScreenCloseAll += ScreenCloseAll;
          SystemEvents.current.onModuleToggle += ModuleToggle;
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

    public void ModuleToggle(string name) {
        Debug.Log(name);
        foreach (var Module in ARModules)
        {
            if(Module.name == name) {
               if(Module.activeSelf) {
                   Module.SetActive(false);
               } else {
                   Module.SetActive(true);
               }
            }
            
        }

    }
}
