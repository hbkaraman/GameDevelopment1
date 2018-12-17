using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosScript : MonoBehaviour {

	[SerializeField]
	private CanvasGroup healthgroup;

	[SerializeField]
	private Stat bossHealth;

	[SerializeField]
	private float health;

	public Image winScene;


	//public Animator camAnim;
	public GameObject deathEffect;
	public GameObject explosion;

	private void Start()
	{
		bossHealth.Initilized(health, health);
	}

	private void Update()
	{
		healthgroup.alpha = 1;

		if (bossHealth.MyCurrentValue <= 0)
		{
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);

			winScene.enabled = true;
		}
	}

	public void TakeDamage(int damage)
	{
		//camAnim.SetTrigger("shake");
		Instantiate(explosion, transform.position, Quaternion.identity);
		bossHealth.MyCurrentValue -= damage;

	}
}
