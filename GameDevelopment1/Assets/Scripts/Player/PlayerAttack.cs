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

	public float attackRangeX;
	public float attackRangeY;
	public LayerMask whatIsEnemies;



	// Use this for initialization
	void Start()
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
				Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosDown.position, new Vector2(attackRangeX,attackRangeY), 0 , whatIsEnemies);
				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					enemiesToDamage[i].GetComponent<EnemyScript>().TakeDamage(damage);
				}
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosRight.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					enemiesToDamage[i].GetComponent<EnemyScript>().TakeDamage(damage);
				}

			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosUp.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					enemiesToDamage[i].GetComponent<EnemyScript>().TakeDamage(damage);
				}
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosLeft.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
					enemiesToDamage[i].GetComponent<EnemyScript>().TakeDamage(damage);
				}
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
		Gizmos.DrawWireCube(attackPosDown.position, new Vector3(attackRangeX,attackRangeY,1));

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(attackPosRight.position, new Vector3(attackRangeX, attackRangeY, 1));

		Gizmos.color = Color.black;
		Gizmos.DrawWireCube(attackPosUp.position, new Vector3(attackRangeX, attackRangeY, 1));

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(attackPosLeft.position, new Vector3(attackRangeX, attackRangeY, 1));
	}
}
