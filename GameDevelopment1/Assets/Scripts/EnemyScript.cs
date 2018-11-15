using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	[SerializeField]
	private CanvasGroup healthgroup;

	[SerializeField]
	private Stat enemyHealth;

	[SerializeField]
	private float health;


	//public Animator camAnim;
	public GameObject deathEffect;
	public GameObject explosion;

	private void Start()
	{
		enemyHealth.Initilized(health, health);
	}

	private void Update()
	{
		healthgroup.alpha = 1;

		if (enemyHealth.MyCurrentValue <= 0 )
		{
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	public void TakeDamage(int damage)
	{
		//camAnim.SetTrigger("shake");
		Instantiate(explosion, transform.position, Quaternion.identity);
		enemyHealth.MyCurrentValue -= damage;
	}
}
