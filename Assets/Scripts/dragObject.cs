using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragObject : MonoBehaviour
{
	Rigidbody2D rb2d;
	bool dragging;
	bool useGravity;
	bool enArea;
	Vector3 mouseStartPos;
	Vector3 playerStartPos;
	Vector3 newPos;


	private void Awake()
	{
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		dragging = false;
		useGravity = true;
	}

	private void Update()
	{		
		if (Input.GetMouseButtonUp(0)) //soltar click izquierdo
		{
			//Stop Dragging
			dragging = false;
			if (!useGravity) useGravity = true;
		}		

		if (dragging)
		{
			//Posición nueva
			newPos = GetMousePos() - mouseStartPos;

			gameObject.transform.position = playerStartPos + newPos; //mover objeto a nueva posición

			if (Input.GetMouseButtonDown(1)) //pulsar botón secundario
			{
				if (rb2d.rotation == 0f)
				{
					rb2d.rotation = -90f;
				}
				else
				{
					rb2d.rotation = 0f;
				}				
			}
		}
	}

	private void OnMouseDown() //pulsar click izquierdo en el collider
	{
		if (enArea)
		{
			dragging = true;

			//Posiciones iniciales al empezar a arrastrar
			mouseStartPos = GetMousePos();
			playerStartPos = gameObject.transform.position;
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
			if (useGravity) useGravity = false;
			rb2d.velocity = Vector3.zero;
			rb2d.angularVelocity = 0f;
			//gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);

			//gameObject.transform.position = playerStartPos + newPos; //mover objeto a nueva posición
		}
		if (useGravity && (rb2d.gravityScale != 1))
		{
			rb2d.gravityScale = 1;
		}
		else if (!useGravity && (rb2d.gravityScale != 0))
		{
			rb2d.gravityScale = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.CompareTag("magic"))
		{
			if (!enArea) enArea = true;
			Debug.Log("area tocada");
		}
	}
	private void OnTriggerExit2D(Collider2D trigger)
	{
		if (enArea) enArea = false;
		//Stop Dragging
		if (dragging) dragging = false;
		if (!useGravity) useGravity = true;

		Debug.Log("area left");
	}
	
	/*
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.gameObject.CompareTag("wall"))
		{
			//Stop Dragging
			if (dragging) dragging = false;
			if (!useGravity) useGravity = true;
		}
	}
	*/
}
