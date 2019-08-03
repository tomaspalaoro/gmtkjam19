using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
	sceneController scenecontroller;

    void Start()
    {
		scenecontroller = FindObjectOfType<sceneController>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		scenecontroller.NextArea();
	}
}
