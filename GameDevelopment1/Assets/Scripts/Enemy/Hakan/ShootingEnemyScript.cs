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

    private AudioSource shootSource;
    public AudioClip shootSound;

	private int Randomize;

	private EnemyScript Enemy;

    private Animator anim;

	private bool isShoting;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		Enemy = GetComponent<EnemyScript>();
		anim = GetComponent<Animator>();
        shootSource = GetComponent<AudioSource>();

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
		if (isShoting == true)
		{
            shootSource.PlayOneShot(shootSound);
			anim.SetInteger("State", 1);
		}
		else
		{
			anim.SetInteger("State", 0);
		}
		Attack();
	}

	private void Attack()
	{
		if (timeBtwShoots <= 0)
		{
			if (Randomize == 0)
			{

				Instantiate(enemyBullet, transform.position, Quaternion.identity);
				isShoting = true;
			}
			else if (Randomize == 1)
			{
				Instantiate(enemyBullet, shootingPosition2.position, Quaternion.identity);
				isShoting = true;
			}

			timeBtwShoots = startTimeBtwShoots;

		}
		else
		{
			timeBtwShoots -= Time.deltaTime;
			isShoting = false;
		}
		
	}

}
