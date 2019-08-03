using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicArea : MonoBehaviour
{
	Vector3 posicionInicial;
	public GameObject mago;

	private void Awake()
	{
		this.posicionInicial = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
	}

	void Update()
	{
		this.transform.position = new Vector3(mago.transform.position.x + posicionInicial.x, this.transform.position.y, this.transform.position.z); //el fondo sigue al jugador
	}
}
