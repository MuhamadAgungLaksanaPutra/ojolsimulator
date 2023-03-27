using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tujuan : MonoBehaviour
{
	public GameObject uiObject;


	void start()
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
	}

	IEnumerator WaitForSec()
	{
		yield return new WaitForSeconds(5);
		Destroy(uiObject);
		Destroy(gameObject);
	}
}
