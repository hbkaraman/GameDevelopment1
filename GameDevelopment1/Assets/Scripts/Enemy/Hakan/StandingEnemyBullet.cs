using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingEnemyBullet : MonoBehaviour {

	public float speed;
	public float distance;
	public float lifeTime;
	public int damage;
	public LayerMask whatIsSolid;

	public GameObject destroyEffect;
	private Rigidbody2D rb;


	// Use this for initialization
	void Start ()
	{
		Invoke("DestroyProjectile",lifeTime);

		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, whatIsSolid);
		if (hitInfo.collider != null)
		{
			if (hitInfo.collider.CompareTag("Player"))
			{
				hitInfo.collider.GetComponent<Player>().TakeDamage(damage);
			}

			DestroyProjectile();
		}
	}

	void DestroyProjectile()
	{
		Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
