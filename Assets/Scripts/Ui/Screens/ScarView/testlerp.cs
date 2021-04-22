using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testlerp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var destination = new Vector2(10f, 10f);
        this.transform.localPosition =  Vector2.Lerp(this.gameObject.GetComponent<RectTransform>().localPosition, destination, 0.0005f);
    }
}
