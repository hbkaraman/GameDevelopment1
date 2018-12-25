using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRange : MonoBehaviour {

	private PatrolShootingEnemy enemy;

	private void Start()
	{
		enemy = GetComponentInParent<PatrolShootingEnemy>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "Player")
		{
			enemy.Target = collision.transform;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{

		if (collision.tag == "Player")
		{
			enemy.Target = null;
		}
	}
}
