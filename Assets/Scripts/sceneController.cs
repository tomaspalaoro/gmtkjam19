using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneController : MonoBehaviour
{
	public GameObject player;
	public GameObject platform;
	public GameObject bg;
	public Vector3 primeraPos;
	public Vector3 segundaPos;
	public Vector3 terceraPos;
	//public Vector3 cuartaPos;

	int area;

	private void Start()
	{
		area = 1;
		player.transform.position = primeraPos;
	}

	public void NextArea()
	{
		if (area == 1)
		{
			area = 2;
			player.transform.position = segundaPos;
		}
		else if (area == 2)
		{
			area = 3;
			player.transform.position = terceraPos;
		}
		else if (area == 3)
		{
			area = 4;
			//player.transform.position = cuartaPos;
		}
	}
}
