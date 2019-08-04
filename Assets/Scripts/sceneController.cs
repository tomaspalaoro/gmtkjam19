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
	public Vector3 cuartaPos;
	Vector3 platformPosition;

	int area;

	private void Start()
	{
		area = 0;
		player.transform.position = primeraPos;

		platform.SetActive(true);
		platformPosition = primeraPos;
		platformPosition.x += 6f;
		platform.transform.position = platformPosition;

		blackPanel.SetActive(false);
	}

	public void Respawn()
	{
		switch (area)
		{
			case 3:
				player.transform.position = cuartaPos;
				break;
			case 2:
				player.transform.position = terceraPos;
				break;
			case 1:
				player.transform.position = segundaPos;
				break;
			case 0:
				player.transform.position = primeraPos;
				break;
			default:
				print("Incorrect level.");
				break;
		}
	}

	public void NextArea(int numero)
	{
		area = numero;
		StartCoroutine(GotoNextArea());
		blackPanel.SetActive(true);
	}

	public void PasarTronco()
	{
		platform.SetActive(false);
	}

	IEnumerator GotoNextArea()
	{
		yield return new WaitForSeconds(0.9f);

		switch (area)
		{
			case 3:
				player.transform.position = cuartaPos;

				platform.SetActive(true);
				platformPosition = cuartaPos;
				platformPosition.x += 4f;
				platform.transform.position = platformPosition;

				bg.transform.position = new Vector3(200, 0, 20);
				Debug.Log("ir a area 4");
				break;
			case 2:
				player.transform.position = terceraPos;

				platform.SetActive(true);
				platformPosition = terceraPos;
				platformPosition.x += 4f;
				platform.transform.position = platformPosition;

				bg.transform.position = new Vector3(200, 0, 20);
				Debug.Log("ir a area 3");
				break;
			case 1:
				player.transform.position = segundaPos;

				platform.SetActive(true);
				platformPosition = segundaPos;
				platformPosition.x += 4f;
				platform.transform.position = platformPosition;

				bg.transform.position = new Vector3(100, 0, 20);
				Debug.Log("ir a area 2");
				break;
			default:
				print("Incorrect level.");
				break;
		}

		StartCoroutine(DesactivarPanel());		
	}

	IEnumerator DesactivarPanel()
	{
		yield return new WaitForSeconds(1f);
		blackPanel.SetActive(false);
	}
}
