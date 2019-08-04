using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragObject : MonoBehaviour
{
	Rigidbody2D rb2d;
	GameObject particulas;
	public int potenciaMagica;
	public int newDrag;
	public float velGiro;
	bool dragging;
	bool useGravity;
	bool enArea;
	//bool colisionando;
	//Vector3 mouseStartPos;
	//Vector3 playerStartPos;
	//Vector3 newPos;
	RaycastHit2D hit;

	public Rigidbody2D roca;
	public GameObject inicioGUI;


	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		particulas = transform.GetChild(0).gameObject;
	}

	private void Start()
	{
		//Inicializar parámetros
		dragging = false;
		useGravity = true;
		enArea = false;
		//colisionando = false;
		particulas.SetActive(false);

		roca.gravityScale = 0;

		inicioGUI.SetActive(true);
	}
	private Vector3 GetMousePos() //conseguir las coordenadas del ratón 2d del ratón
	{
		//Posición x,y en píxeles del ratón, en dos dimensiones
		Vector3 mousePos = Input.mousePosition;

		return Camera.main.ScreenToWorldPoint(mousePos);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && (hit.collider != null)) //pulsar click izquierdo en el collider
		{
			if (enArea && hit.collider.tag == "platform" && !dragging) // && !colisionando
			{
				//Start dragging
				dragging = true;
				mageMovement.usandoMagia = true;

				//Posiciones iniciales al empezar a arrastrar
				//mouseStartPos = GetMousePos();
				//playerStartPos = gameObject.transform.position;

				inicioGUI.SetActive(false);

				Debug.Log("OnMouseDown");
			}
			else
			{
				Debug.Log(hit.collider.tag);
			}
		}
		if (Input.GetMouseButtonUp(0)) //soltar click izquierdo
		{
			//Stop Dragging
			StopDragging();
		}		

		if (dragging)
		{
			//Posición nueva
			//newPos = GetMousePos() - mouseStartPos;

			//Mover objeto
			//if (!colisionando) gameObject.transform.position = playerStartPos + newPos;

			var dir = GetMousePos() - transform.position;

			rb2d.drag = newDrag;
			rb2d.angularDrag = newDrag - 1;

			rb2d.AddForce(dir * potenciaMagica);

			if (Input.GetMouseButton(1)) //pulsar botón secundario
			{
				rb2d.AddTorque(velGiro, ForceMode2D.Force);
				/*
				if (rb2d.rotation == 0f)
				{
					rb2d.rotation = -90f;
				}
				else
				{
					rb2d.rotation = 0f;
				}				
				*/
				//Debug.Log("torque");
			}			

			if (!particulas.activeSelf) particulas.SetActive(true);
		}
	}

	private void FixedUpdate()
	{
		hit = Physics2D.Raycast(GetMousePos(), Vector2.zero);

		if (dragging) // && !colisionando
		{
			if (useGravity) useGravity = false;
			//rb2d.velocity = Vector3.zero;
			//rb2d.angularVelocity = 0f;
			//gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
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

	public void DentroDeAlcance()
	{
		if (!enArea) enArea = true;
		Debug.Log("area tocada");
	}

	public void FueraDeAlcance()
	{
		if (enArea) enArea = false;
		//Stop Dragging
		StopDragging();		

		Debug.Log("area left");
	}

	public void StopDragging()
	{
		if (dragging) dragging = false;
		rb2d.drag = 0f;
		rb2d.angularDrag = 0.01f;
		if (!useGravity) useGravity = true;
		if (particulas.activeSelf) particulas.SetActive(false);
		if (mageMovement.usandoMagia) mageMovement.usandoMagia = false;
	}

	private void OnCollisionEnter2D(Collision2D c1)
	{
		if (c1.collider.gameObject.CompareTag("rock"))
		{
			if (roca.gravityScale != 1)
			{
				roca.gravityScale = 1;
			}

			Debug.Log("roca falsa tocada");
		}
	}
}
