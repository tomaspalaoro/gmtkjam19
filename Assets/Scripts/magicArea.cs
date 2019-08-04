using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicArea : MonoBehaviour
{
	//Vector3 posicionInicial;
	public GameObject mago;
	public GameObject plataforma;

	private void Awake()
	{
		//this.posicionInicial = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
	}

	void Update()
	{
		this.transform.position = new Vector3(mago.transform.position.x + 4, mago.transform.position.y + 1, this.transform.position.z); //el fondo sigue al jugador
	}

	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.CompareTag("platform"))
		{
			plataforma.GetComponent<dragObject>().DentroDeAlcance();
		}
	}
	private void OnTriggerExit2D(Collider2D trigger)
	{
		if (trigger.gameObject.CompareTag("platform"))
		{
			plataforma.GetComponent<dragObject>().FueraDeAlcance();
		}
	}
}
