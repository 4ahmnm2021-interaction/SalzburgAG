using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScreenController : MonoBehaviour
{
    public List<GameObject> Screens;
    public List<GameObject> ARModules;

    public List<GameObject> PanelPosSlots;


    public List<GameObject> Slots;

    public List<GameObject> PanelCarrier;

    public List<GameObject> AdditionaleHeaderItems;

    // Start is called before the first frame update
    void Start()
    {        
        SystemEvents.current.onScreenCloseAll += ScreenCloseAll;
         SystemEvents.current.onModuleToggle += ModuleToggle;
         SystemEvents.current.onScreenOpen += ScreenOpen;
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
        foreach(GameObject Item in AdditionaleHeaderItems) {
            Item.SetActive(false);
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

    void ScreenOpen(string name) {
        foreach (var Screen in Screens)
        {
            if(Screen.name == name) {
              Screen.SetActive(true);

              if(name == "SCMap") {
                GameObject ArBtn = AdditionaleHeaderItems.Where(obj => obj.name == "ArButton").SingleOrDefault();
                ArBtn.SetActive(true);
              }
            }
            
        }
    }

    void SetPanelPos() {
        var counter = 0;
        var posCounter = 0;
        foreach (var Module in PanelCarrier)
        {
            if(ARModules[counter].activeSelf) {
                var position = Slots[posCounter].GetComponent<RectTransform>().localPosition.x;
                Module.GetComponent<RectTransform>().localPosition =  new Vector2(position, Module.GetComponent<RectTransform>().localPosition.y);
                Debug.Log(position);
                posCounter ++;
            }
            counter ++;
        }
    }
}
