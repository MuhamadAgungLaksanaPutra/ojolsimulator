using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderanScript : MonoBehaviour
{
	public GameObject uiObject;
	public bool UI;
	public bool Orderan;

	int progress = 0;

	void Start()
	{
		uiObject.SetActive(false);
	}

	void OnTriggerEnter(Collider player)
	{
		if (player.gameObject.tag == "Motor")
		{
			uiObject.SetActive(true);
			StartCoroutine("WaitForSec");
		}

		progress = 1;
		CekProgress(); 
	}
	
	void CekProgress()
	{
		if (progress == 0)
		{
			UI = false;
			Orderan = false;
		}
		else if (progress == 1)
		{
			UI = true;
			Orderan = false;
		}
		else if (progress == 2)
		{
			UI = false;
			Orderan	 = true;
		}
		else
		{
			UI = true;
		}
	}
	
	IEnumerator WaitForSec()
	{
		yield return new WaitForSeconds(15);
		Destroy(uiObject);
		Destroy(gameObject);
	}
}
