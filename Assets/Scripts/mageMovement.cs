using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mageMovement : MonoBehaviour
{
	public mageController controller;
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
	}

	void Update()
    {
		if (!usandoMagia)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			animator.SetFloat("speed", Mathf.Abs(horizontalMove));

			animator.SetBool("isDragging", false);
		}
		else
		{
			horizontalMove = 0;
			animator.SetBool("isDragging", true);
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
}
