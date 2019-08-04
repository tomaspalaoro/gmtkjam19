using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class mageMovement : MonoBehaviour
{
	public mageController controller;
	public sceneController escena;
	public GameObject vcamMago;
	public GameObject vcamTronco;
	public float runSpeed;

	Animator animator;
	float horizontalMove;
	bool jump;

	public static bool usandoMagia;

	private void Awake()
	{
		animator = gameObject.GetComponent<Animator>();
	}

	private void Start()
	{
		horizontalMove = 0f;
		jump = false;
		usandoMagia = false;
		vcamTronco.SetActive(false);
		vcamMago.SetActive(true);
	}

	void Update()
    {
		if (!usandoMagia)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			animator.SetFloat("speed", Mathf.Abs(horizontalMove));

			animator.SetBool("isDragging", false);

			vcamTronco.SetActive(false);
			vcamMago.SetActive(true);
		}
		else
		{
			horizontalMove = 0;
			animator.SetBool("isDragging", true);

			if (Input.GetKeyDown(KeyCode.E))
			{
				vcamTronco.SetActive(true);
				vcamMago.SetActive(false);
			}
		}

		if(Input.GetButtonDown("Jump"))
		{
			jump = true;
			//animator.SetBool("isJumping", true);
		}
    }

	private void FixedUpdate()
	{
		//Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime,false, jump); //horizontal * move the same amount, dont wanna crouch, wanna jump
		jump = false; //dont keep on jumping forever
	}

	/*
	public void OnLanding()
	{
		animator.SetBool("isJumping", false);
	}
	*/

	private void OnCollisionEnter2D(Collision2D c1)
	{
		if (c1.collider.gameObject.CompareTag("deadly"))
		{
			escena.Respawn();
		}
	}
}
