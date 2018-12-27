using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingBulletDown : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public int damage;

	public GameObject destroyEffect;
	private Rigidbody2D rb;


	// Use this for initialization
	void Start()
	{
		Invoke("DestroyProjectile", lifeTime);

		rb = GetComponent<Rigidbody2D>();

		rb.velocity = Vector2.down * speed;
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			collision.GetComponent<Player>().TakeDamage(damage);
			DestroyProjectile();
		}

		if (collision.tag == "Kalkan")
		{
			DestroyProjectile();
		}
	}


	void DestroyProjectile()
	{
		Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
