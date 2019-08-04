using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirTrampilla : MonoBehaviour
{
	public GameObject trampilla;

	private void Start()
	{
		trampilla.SetActive(true);
	}
	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.CompareTag("rock"))
		{
			trampilla.SetActive(false);
		}
	}
}
