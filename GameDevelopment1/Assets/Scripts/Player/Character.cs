using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour {

	

	[SerializeField]
	protected Stat health;
	[SerializeField]
	private float initHealth;

	[SerializeField]
	protected Stat mana;
	[SerializeField]
	private float initMana;

	[SerializeField]
	private float speed;

	protected Vector2 direction;

	private Animator myAnimator;

	public Image LossScene;


	/*public bool IsMoving
	{
		get
		{
			return direction.x != 0 || direction.y != 0;
		}
	}*/


	protected Rigidbody2D myRigidbody;


	// Use this for initialization
	protected virtual void Start()
	{

		// For HealthBar "healthValue","maxHealth"
		health.Initilized(initHealth, initHealth);

		mana.Initilized(initMana, initMana);

		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();
	}
	

	protected virtual void Update()
	{
		
	}

	public void FixedUpdate()
	{
		Move();
	}


	public void Move()
	{
		// Playerı Hareket ettirmek için 
		myRigidbody.velocity = direction.normalized * speed;

		if(direction.x != 0 || direction.y != 0)
		{
			AnimateMovement(direction);
		}
		else
		{
			myAnimator.SetLayerWeight(1, 0);
		}

		
	}

	/*public void HandleLayers()
	{
		if(IsMoving)
		{

		}
	}*/

	public void AnimateMovement(Vector2 direction)
	{
		myAnimator.SetLayerWeight(1, 1);

		myAnimator.SetFloat("x", + direction.x);
		myAnimator.SetFloat("y", + direction.y);

	}

	
}
