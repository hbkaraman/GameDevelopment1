﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public float distance;
	public int damage;
	public LayerMask whatIsSolid;

	public GameObject destroyEffect;

	Quaternion bulletDirection;
	public Rigidbody2D rb;


	private void Start()
	{
		Invoke("DestroyProjectile", lifeTime);
		rb = GetComponent<Rigidbody2D>();
		

		//Vector2 velTotal = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity + Vector2.right;
		rb.velocity = transform.right * speed;
	}

	private void Update()
	{
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, whatIsSolid);
		if (hitInfo.collider != null)
		{

			if (hitInfo.collider.CompareTag("Enemy"))
			{
				hitInfo.collider.GetComponent<EnemyScript>().TakeDamage(damage);
			}
			if (hitInfo.collider.CompareTag("Boss"))
			{
				hitInfo.collider.GetComponent<BoosScript>().TakeDamage(damage);
			}
			if (hitInfo.collider.CompareTag("BossMeele"))
			{
				hitInfo.collider.GetComponent<BossEnemyScript>().TakeDamage(damage);
			}
			DestroyProjectile();
		}

		//transform.Translate(Vector2.right* speed * Time.deltaTime);
		//Debug.Log("rot"+ this.transform.rotation.eulerAngles);
		//transform.Translate(transform.rotation.eulerAngles * speed * Time.deltaTime);

	}

	void DestroyProjectile()
	{
		Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
