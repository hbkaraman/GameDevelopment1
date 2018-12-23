using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{

	private MeeleEnemy enemy;

	private void Start()
	{
		enemy = GetComponentInParent<MeeleEnemy>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if(collision.tag == "Player")
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
