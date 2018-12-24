using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolShootingEnemy : MonoBehaviour {
	
	
	private float waitTime;
	public float startWaitTime;

	public Transform moveSpot;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;


	public Transform shootingPosition;
	public Transform shootingPosition2;
	public GameObject enemyBullet;


	private float timeBtwShoots;
	public float startTimeBtwShoots;

	private int Randomize;

	private Animator Anim;

	private bool isShoot;
	private bool isIdle;

	private EnemyScript Enemy;

	private Rigidbody2D rb;




	void Start ()
	{
		Enemy = GetComponent<EnemyScript>();
		Anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		waitTime = startWaitTime;

		moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
	}
	
	
	void Update ()
	{

		Movement();

		Shoot();


		if(isShoot == true)
		{
			Anim.SetInteger("State", 1);
		}
		else
		{
			Anim.SetInteger("State", 0);
		}


	}

	void Movement()
	{

		rb.MovePosition(Vector2.MoveTowards(transform.position, moveSpot.position, Enemy.speed * Time.deltaTime));
	

		if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
		{
			if (waitTime <= 0)
			{
				moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
				waitTime = startWaitTime;
			}
			else
			{
				waitTime -= Time.deltaTime;
			}
		}
	}


	void Shoot()
	{

		Randomize = Random.Range(0, 2);

		if (timeBtwShoots <= 0)
		{
			if (Randomize == 0)
			{
				Instantiate(enemyBullet, shootingPosition.position, Quaternion.identity);
				isShoot = true;

			}
			else if (Randomize == 1)
			{
				Instantiate(enemyBullet, shootingPosition2.position, Quaternion.identity);
				isShoot = true;
			}
			timeBtwShoots = startTimeBtwShoots;
		}
		else
		{
			timeBtwShoots -= Time.deltaTime;
			isShoot = false;
		}

	}
}
