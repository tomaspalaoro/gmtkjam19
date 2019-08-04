using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneController : MonoBehaviour
{
	public GameObject player;
	public GameObject platform;
	public GameObject bg;
	public GameObject blackPanel;
	public Vector3 primeraPos;
	public Vector3 segundaPos;
	public Vector3 terceraPos;
	//public Vector3 cuartaPos;

	int area;

	private void Start()
	{
		area = 1;
		player.transform.position = primeraPos;
		blackPanel.SetActive(false);
	}

	public void NextArea()
	{
		StartCoroutine(GotoNextArea());
		blackPanel.SetActive(true);
	}

	IEnumerator GotoNextArea()
	{
		yield return new WaitForSeconds(0.9f);
		if (area == 1)
		{
			area = 2;
			player.transform.position = segundaPos;

			Vector3 platformPosition = segundaPos;
			platformPosition.x -= 3f;
			platform.transform.position = platformPosition;

			bg.transform.position = new Vector3(100, 0, 20);
		}
		else if (area == 2)
		{
			area = 3;
			player.transform.position = terceraPos;

			Vector3 platformPosition = terceraPos;
			platformPosition.x -= 3f;
			platform.transform.position = platformPosition;

			bg.transform.position = new Vector3(200, 0, 20);
		}
		else if (area == 3)
		{
			area = 4;
			//player.transform.position = cuartaPos;
		}
	}
}
