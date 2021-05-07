using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkStepsManager : MonoBehaviour
{
    public Sprite checkedIcon;
    public Sprite uncheckedIcon;
    private bool done = false;

    public string KKS = "0"; 
    void Start()
    {
        
    }
    void OnMouseDown()
    {
        if(!done) {
            this.gameObject.GetComponent<Image>().sprite = checkedIcon;
            SystemEvents.current.StepDone(KKS, "true");
            done = true;
        } else {
            done = false;
            this.gameObject.GetComponent<Image>().sprite = uncheckedIcon;
            SystemEvents.current.StepDone(KKS, "false");
        }
    }
}
