using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speedometer : MonoBehaviour
{ 
    [SerializeField]private Rigidbody m_Rigidbody;
    public TMP_Text speedText;

    // Update is called once per frame
    void Update()
    {
        float speed = m_Rigidbody.velocity.magnitude * 3.6f;
        speedText.text = "Speed: " + Mathf.Round(speed) + " km/h";
    } 
}
