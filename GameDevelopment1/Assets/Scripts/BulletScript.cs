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

	private void Start()
	{
		Invoke("DestroyProjectile", lifeTime);
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
			DestroyProjectile();
		}

		/*if ())
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}*/

	}

	void DestroyProjectile()
	{
		Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
