using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyScript : MonoBehaviour {

	
	public float stoppingDistance;
	public float retreatDistance;

	private Transform player;
	public Transform shootingPosition;
	public Transform shootingPosition2;
	public GameObject enemyBullet;

	private float timeBtwShoots;
	public float startTimeBtwShoots;

	private int Randomize;

	private EnemyScript Enemy;


	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		Enemy = GetComponent<EnemyScript>();

		timeBtwShoots = startTimeBtwShoots;

		
	}

	void FixedUpdate()
	{
		Movement();
	}

	private void Movement()
	{
		if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
		{
			transform.position = Vector2.MoveTowards(transform.position, player.position, Enemy.speed * Time.deltaTime);
		}
		else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
		{
			transform.position = this.transform.position;

		}
		else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
		{
			transform.position = Vector2.MoveTowards(transform.position, player.position, -Enemy.speed * Time.deltaTime);
		}
	}

	void Update ()
	{
		Randomize = Random.Range(0, 2);

		if (timeBtwShoots <= 0)
		{
			if(Randomize == 0)
			{
				Instantiate(enemyBullet, shootingPosition.position, Quaternion.identity);
			} else if (Randomize == 1)
			{
				Instantiate(enemyBullet, shootingPosition2.position, Quaternion.identity);
			}
			timeBtwShoots = startTimeBtwShoots;
		}
		else
		{
			timeBtwShoots -= Time.deltaTime;
		}

	}
}
