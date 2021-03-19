using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerMenu : MonoBehaviour
{

    public GameObject openedOB;
    public GameObject closedOB;
    public Image DiffLayer;
    public GameObject DiffLayerOBJ;
    private float speed = 0.2F;
    private bool close = true;

    private Vector3 opened;
    private Vector3 closed;

    private float FadeSpeed = 0.5f;

    void Start()
    {
        
        opened = openedOB.transform.position;
        closed = closedOB.transform.position;
               StartCoroutine(FadeInDiff());
    }

    // Update is called once per frame
    void Update()
    {
        if(close) {
            transform.position = Vector3.Lerp(transform.position, closed, speed);
        } else {
            transform.position = Vector3.Lerp(transform.position, opened, speed);
        }

        
    }

    public void ToggleBurger() {

        if (close) {
            close = false;
                DiffLayerOBJ.SetActive(true);
                StartCoroutine(FadeInDiff());
        } else {
            close = true;
            StartCoroutine(FadeOutDiff());
                  DiffLayerOBJ.SetActive(false);
        }
    }

    IEnumerator FadeOutDiff() {

        for(float t = 0.5f ; DiffLayer.GetComponent<Image>().color.a > 0; t -= Time.deltaTime / FadeSpeed) {
            Color tmpColor = DiffLayer.GetComponent<Image>().color;
            // tmpColor.a = Time.deltaTime * 10;
            tmpColor.a = t;
            // DiffLayer.GetComponent<Image>().color.a = Time.deltaTime / 2;
            DiffLayer.GetComponent<Image>().color = tmpColor;
               yield return null;
        }
        yield return null;
    }


    IEnumerator FadeInDiff() {

        for(float t = 0 ; DiffLayer.GetComponent<Image>().color.a < 0.5f; t += Time.deltaTime / FadeSpeed) {
            Color tmpColor = DiffLayer.GetComponent<Image>().color;
            // tmpColor.a = Time.deltaTime * 10;
            tmpColor.a = t;
            // DiffLayer.GetComponent<Image>().color.a = Time.deltaTime / 2;
            DiffLayer.GetComponent<Image>().color = tmpColor;
               yield return null;
        }
        yield return null;
    }
}
