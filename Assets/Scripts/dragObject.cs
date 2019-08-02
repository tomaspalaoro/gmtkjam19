using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragObject : MonoBehaviour
{
	/*private Vector3 cursorOffset; //diferencia entre la posición del objeto y la del cursor

	//private float posicionZObjeto;

	private void OnMouseDown() //al pulsar el objeto
	{
		//posicionZObjeto = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //leer la coordenada z del objeto
		
		cursorOffset = gameObject.transform.position - GetMouseWorldPos(); //Guardar la posición del objeto en el espacio menos la posicion del mouse en el espacio 3d
	}

	private Vector3 GetMouseWorldPos() //conseguir las coordenadas del ratón en el espacio 3d
	{
		//Posición x,y en píxeles del ratón, en dos dimensiones
		Vector3 mousePos = Input.mousePosition;

		//Usar la coordenada z del objeto
		//mousePos.z = posicionZObjeto;

		return Camera.main.ScreenToViewportPoint(mousePos);
	}
	private void OnMouseDrag()
	{
		transform.position = GetMouseWorldPos() + cursorOffset; //mover el objeto a la posicion del ratón sumando cierto offset
	}*/

	//public GameObject player;

	bool dragging = false;
	Vector3 mouseStartPos;
	Vector3 playerStartPos;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			dragging = true;
			mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			playerStartPos = gameObject.transform.position;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			dragging = false;
		}

		if (dragging)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			Vector3 move = mousePos - mouseStartPos;
			gameObject.transform.position = playerStartPos + move;
		}
	}
}
