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

	public virtual void TakeDamage(float damage)
	{
		health.MyCurrentValue -= damage;

		if (health.MyCurrentValue <= 0)
		{
			LossScene.enabled = true;

			if(LossScene.enabled == true)
			{
				Time.timeScale = 0;
			}
		}
	}
}
