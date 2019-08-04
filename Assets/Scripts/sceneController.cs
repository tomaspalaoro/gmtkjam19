using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneController : MonoBehaviour
{
	public GameObject player;
	public GameObject platform;
	public GameObject bg;
	public GameObject blackPanel;
	public GameObject endScreen;
	public Vector3 primeraPos;
	public Vector3 segundaPos;
	public Vector3 terceraPos;
	public Vector3 cuartaPos;
	public Vector3 quintaPos;
	Vector3 platformPosition;
	Rigidbody2D rb2d;

	int area;

	private void Awake()
	{
		rb2d = platform.GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		area = 0; //nivel menos uno
		player.transform.position = primeraPos;

		platform.SetActive(true);
		platformPosition = primeraPos;
		platformPosition.x += 6f;
		platform.transform.position = platformPosition;

		blackPanel.SetActive(false);
		endScreen.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			NextArea(area);
		}
	}

	public void Respawn()
	{
		switch (area)
		{
			case 4:
				player.transform.position = quintaPos;
				break;
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
		mageMovement.usandoMagia = false;
		platform.SetActive(false);
	}

	IEnumerator GotoNextArea()
	{
		yield return new WaitForSeconds(0.9f);

		//reset rigidbody
		rb2d.velocity = Vector3.zero;
		rb2d.angularVelocity = 0f;
		rb2d.rotation = -90f;
		mageMovement.usandoMagia = false;

		switch (area)
		{
			case 5:
				endScreen.SetActive(true);
				break;
			case 4:
				player.transform.position = quintaPos;

				platform.SetActive(true);
				platformPosition = quintaPos;
				platformPosition.x += 4f;
				platform.transform.position = platformPosition;

				bg.transform.position = new Vector3(400, -13.14f, 20);
				Debug.Log("ir a area 5");
				break;
			case 3:
				player.transform.position = cuartaPos;

				platform.SetActive(true);
				platformPosition = cuartaPos;
				platformPosition.x += 4f;
				platform.transform.position = platformPosition;

				bg.transform.position = new Vector3(300, 0, 20);
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
			case 0:
				player.transform.position = primeraPos;

				platform.SetActive(true);
				platformPosition = primeraPos;
				platformPosition.x += 6f;
				platform.transform.position = platformPosition;

				bg.transform.position = new Vector3(0, 0, 20);
				Debug.Log("ir a area spawn");
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
