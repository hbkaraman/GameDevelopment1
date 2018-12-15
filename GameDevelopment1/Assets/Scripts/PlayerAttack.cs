using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private float timeBtwAttack;
	public float startTimeBtwAttack;
	public int damage;

	public Transform attackPosRight;
	public Transform attackPosDown;
	public Transform attackPosLeft;
	public Transform attackPosUp;
	public float attackRange;
	public LayerMask whatIsEnemies;



	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if(timeBtwAttack <= 0)
		{
			// adjusment directions

			if (Input.GetKey(KeyCode.DownArrow))
			{
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosDown.position, attackRange, whatIsEnemies);
				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					enemiesToDamage[i].GetComponent<EnemyScript>().TakeDamage(damage);
				}
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosRight.position, attackRange, whatIsEnemies);
				for(int i = 0; i < enemiesToDamage.Length; i++)
				{
					enemiesToDamage[i].GetComponent<EnemyScript>().TakeDamage(damage);
				}
				
			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				
			}


			timeBtwAttack = startTimeBtwAttack;
		}else
		{
			timeBtwAttack -= Time.deltaTime;
		}
	}

	 void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(attackPosRight.position, attackRange);

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPosDown.position, attackRange);
	}
}
