using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    public List<GameObject> Screens;
    public List<GameObject> ARModules;

    public List<GameObject> PanelPosSlots;
    public List<float> PanelXPos;

    public List<GameObject> PanelCarrier;


    // Start is called before the first frame update
    void Start()
    {        
        SystemEvents.current.onScreenCloseAll += ScreenCloseAll;
          SystemEvents.current.onModuleToggle += ModuleToggle;
    SetPanelPos();
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
        var posCounter = 0;
        foreach (var Module in PanelCarrier)
        {
            // Debug.Log(ARModules[counter].activeSelf);
            if(ARModules[counter].activeSelf) {
 
                

                var position = PanelXPos[posCounter];
                Module.GetComponent<RectTransform>().localPosition =  new Vector2(position, 0);
     
                Debug.Log(position);
                posCounter ++;
            }
            counter ++;
        }
    }
}
