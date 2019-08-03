using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragObject : MonoBehaviour
{
	bool dragging;
	Vector3 mouseStartPos;
	Vector3 playerStartPos;

	Vector3 newPos;

	bool useGravity;

	private void Start()
	{
		dragging = false;
		useGravity = true;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0)) //pulsar click izquierdo
		{
			dragging = true;

			//Posiciones iniciales al empezar a arrastrar
			mouseStartPos = GetMousePos();
			playerStartPos = gameObject.transform.position;
		}
		else if (Input.GetMouseButtonUp(0)) //soltar click izquierdo
		{
			dragging = false;
			if (!useGravity)
			{
				GetComponent<Rigidbody2D>().gravityScale = 1;
				useGravity = true;
			}
		}

		if (dragging)
		{
			//Posición nueva
			newPos = GetMousePos() - mouseStartPos;
		}
	}

	private Vector3 GetMousePos() //conseguir las coordenadas del ratón 2d del ratón
	{
		//Posición x,y en píxeles del ratón, en dos dimensiones
		Vector3 mousePos = Input.mousePosition;

		return Camera.main.ScreenToWorldPoint(mousePos);
	}

	private void FixedUpdate()
	{
		if (dragging)
		{
			if (useGravity)
			{
				GetComponent<Rigidbody2D>().gravityScale = 0;
				useGravity = false;
			}
			gameObject.transform.position = playerStartPos + newPos; //mover objeto a nueva posición
		}
	}
}
