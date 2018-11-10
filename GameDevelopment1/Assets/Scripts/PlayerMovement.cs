using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody2D rb;
	private Vector2 localScale;
	private Vector2 moveVelocity;

	public bool isMoving =false;
	public float speed;

	public BulletScript bulletSc;
	public GameObject bullet;

	private float timeBtwShots;
	public float startTimeBtwShots;


	public Transform shotPointLeft;
	public Transform shotPointRight;
	public Transform shotPointUp;
	public Transform shotPointDown;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		//localScale = GetComponent<Transform>().localScale;
	}
	
	void Update ()
	{
		//For Movement
		Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		moveVelocity = moveInput * speed;

		//ForShoot

		if (timeBtwShots <= 0)
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				Instantiate(bullet, shotPointLeft.position, transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				Instantiate(bullet, shotPointRight.position, transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				Instantiate(bullet, shotPointUp.position, transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				Instantiate(bullet, shotPointDown.position, transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}
		}
		else
		{
			timeBtwShots -= Time.deltaTime;
		}
	}


	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
	}

}
