using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {


	[SerializeField]
	private float speed;

	protected Vector2 direction;

	private Animator myAnimator;

	/*public bool IsMoving
	{
		get
		{
			return direction.x != 0 || direction.y != 0;
		}
	}*/


	private Rigidbody2D myRigidbody;


	// Use this for initialization
	protected virtual void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
	}
	

	protected virtual void Update()
	{
		Move();
	}

	public void FixedUpdate()
	{
	
	}


	public void Move()
	{
		// Playerı Hareket ettirmek için 
		transform.Translate(direction.normalized * speed * Time.deltaTime);

		AnimateMovement(direction);
	}

	/*public void HandleLayers()
	{
		if(IsMoving)
		{

		}
	}*/

	public void AnimateMovement(Vector2 direction)
	{
		myAnimator.SetFloat("x", + direction.x);
		myAnimator.SetFloat("y", + direction.y);

	}


}
