using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public float posx;
    private float speed = 0.5f;
    private Vector2 destination;
    void Start()
    {
        // posx = GetComponent<RectTransform>().localPosition.x;
        
    }


    void Update()
    {

        destination = new Vector2(posx, this.gameObject.GetComponent<RectTransform>().localPosition.y);
        this.transform.localPosition =  Vector2.Lerp(this.gameObject.GetComponent<RectTransform>().localPosition, destination, speed);

           

    }
}
