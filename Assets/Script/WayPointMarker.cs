using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class WayPointMarker : MonoBehaviour
{
    public Image img;
    public Transform target;
    public TMP_Text meter;

    // Update is called once per frame
    private void Update()
    {/*
        img.transform.position = GetComponent<Cinemachine>().main.WorldToScreenPoint(target.position);
        
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;
    
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);
        if(Vector3.Dot((target.position -transform.position), transform.forward) < 0)
        {
            if(pos.x <Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }
        pos.x = Mathf.Clamp(pos.x, minY, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxX);

        img.transform.position = pos;
        meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() +"m";
        */
    }
}
