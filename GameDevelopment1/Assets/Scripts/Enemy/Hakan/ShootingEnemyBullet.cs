using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyBullet : MonoBehaviour {

	public float speed;

	private Transform player;
	private Vector2 target;

	public GameObject DestroyEffect;


	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;

		target = new Vector3(player.position.x, player.position.y, player.position.z);
	}

	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);

		if(transform.position.x == target.x && transform.position.y == target.y)
		{
			DestroyBullet();	
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			DestroyBullet();
		}

		if (collision.CompareTag("Kalkan"))
		{
			DestroyBullet();
		}

		if (collision.gameObject.tag == ("wall"))
		{
			DestroyBullet();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag==("wall"))
		{
			DestroyBullet();
		}
	}

	void DestroyBullet()
	{
		Instantiate(DestroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
