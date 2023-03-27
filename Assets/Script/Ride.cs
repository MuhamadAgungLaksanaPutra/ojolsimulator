using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ride : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 COG;

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_streeringAngle;

    public WheelCollider banDepanW;
    public WheelCollider banBelakangW;
    public BoxCollider stang;
    public Transform banDepanT;
    public Transform banBelakangT;

    public float maxSteerAngle = 30f;
    public float motorForce = 1000f;
    public float brakeTorque = 120f;
    public bool isbrake = false;

    [Range(-80, 80)]public float layingammount;
    [Range(0.000001f, 1 )] [SerializeField] float leanSmoothing;
    public float targetlayingAngle;

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_streeringAngle = maxSteerAngle * m_horizontalInput;
        banDepanW.steerAngle = m_streeringAngle;

        targetlayingAngle = maxSteerAngle * -m_horizontalInput;
    }

    private void Accelerate()
    {
        banBelakangW.motorTorque = m_verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPoses(banDepanW,banDepanT);
        UpdateWheelPoses(banBelakangW, banBelakangT);
    }

    private void UpdateWheelPoses(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void HandBrake()
    {
        if(Input.GetKey(KeyCode.Space))
        {
           isbrake = true;
        }
        else
        {
            isbrake = false;
        }

        if (isbrake == true)
        {
            banDepanW.brakeTorque = brakeTorque;
            banBelakangW.brakeTorque = brakeTorque;
            banDepanW.motorTorque = 0;
            banBelakangW.motorTorque = 0;
        }
        else
        {
            banDepanW.brakeTorque = 0;
            banBelakangW.brakeTorque = 0;
        }
    }

    private void DownPresureOnSpeed()
	{
		Vector3 downforce = Vector3.down; 
		float downpressure;
		if (rb.velocity.magnitude > 5)
		{
			downpressure = rb.velocity.magnitude;
			rb.AddForce(downforce * downpressure, ForceMode.Force);
		}

	}
 
    private void LayOnTrun()
    {
        Vector3 currentRot = transform.rotation.eulerAngles;

        if (rb.velocity.magnitude < 1)
		{
			layingammount = Mathf.LerpAngle(layingammount, 0f, 0.05f);		
			transform.rotation = Quaternion.Euler(currentRot.x, currentRot.y, layingammount);
			return;
		}

		if (m_streeringAngle < 0.5f && m_streeringAngle > -0.5  ) //We're stright
		{
			layingammount =  Mathf.LerpAngle(layingammount, 0f, leanSmoothing);			
		}
		else //We're turning
		{
			layingammount = Mathf.LerpAngle(layingammount, targetlayingAngle, leanSmoothing );		
			rb.centerOfMass = new Vector3(rb.centerOfMass.x, COG.y, rb.centerOfMass.z);
        }
        transform.rotation = Quaternion.Euler(currentRot.x, currentRot.y, layingammount);
    }
    
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        HandBrake();
        LayOnTrun();
        DownPresureOnSpeed();
    }
}
