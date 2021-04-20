using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public List<GameObject> Screens;
    public List<GameObject> ARModules;

    public List<GameObject> PanelPosSlots;

    public List<GameObject> PanelCarrier;

    
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
        foreach (var Module in ARModules)
        {
            if(Module.name == name) {
               if(Module.activeSelf) {
                   Module.SetActive(false);
                   SetPanelPos();
               } else {
                   Module.SetActive(true);
                   SetPanelPos();
               }
            }
            
        }

    }

    void SetPanelPos() {
        var counter = 0;
        foreach (var Module in PanelCarrier)
        {
            if(Module.activeSelf) {
                var pos = PanelPosSlots[counter].transform.position.x;
                Module.transform.position = new Vector3(pos, Module.transform.position.y, Module.transform.position.z);
                Debug.Log(pos);
            }
            counter ++;
        }
    }
}
