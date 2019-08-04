using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
	sceneController scenecontroller;
	bool troncoHaPasado;
	public int area;

    void Start()
    {
		scenecontroller = FindObjectOfType<sceneController>();
		troncoHaPasado = false;

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("platform") && !troncoHaPasado)
		{
			troncoHaPasado = true;
			Debug.Log("ha pasado");
			scenecontroller.PasarTronco();
		}
		else if (collision.gameObject.CompareTag("Player") && troncoHaPasado)
		{
			scenecontroller.NextArea(area);
		}
	}
}
