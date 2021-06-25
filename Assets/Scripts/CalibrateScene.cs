using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateScene : MonoBehaviour
{
    public GameObject content;
    public float moveValue = 1f;
    public float rotValue = 3f;
    public float scaleValue = 0.2f;

    public void SetMove(float x)
    {
        moveValue = x;
    }

    public void SetRot(float x)
    {
        rotValue = x;
    }

    public void SetScale(float x)
    {
        scaleValue = x;
    }

    public void Move(string a)
    {

        switch (a)
        {
            case "x":
                content.transform.Translate(new Vector3(moveValue, 0, 0));
                break;
            case "y":
                content.transform.Translate(new Vector3(0, moveValue, 0));
                break;
            case "z":
                content.transform.Translate(new Vector3(0, 0, moveValue));
                break;
            default:
                break;
        }

    }

    public void Rotate(string a)
    {
        switch (a)
        {
            case "x":
                content.transform.Rotate(new Vector3(rotValue, 0 , 0));
                break;
            case "y":
                content.transform.Rotate(new Vector3(0, rotValue, 0));
                break;
            case "z":
                content.transform.Rotate(new Vector3(0, 0, rotValue));
                break;
            default:
                break;
        }

    }

    public void Scale(string a)
    {
        switch (a)
        {
            case "x":
                content.transform.localScale += new Vector3(scaleValue, 0, 0);
                break;
            case "y":
                content.transform.localScale += new Vector3(0, scaleValue, 0);
                break;
            case "z":
                content.transform.localScale += new Vector3(0, 0, scaleValue);
                break;
            default:
                break;
        }

    }


}
