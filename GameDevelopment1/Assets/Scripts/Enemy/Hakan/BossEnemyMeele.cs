using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyMeele : MonoBehaviour {

	private Transform target;

	private Animator anim;
	private Vector2 direction;
	public float StopDistan;

	private float timeBtwAttack;
	public float startTimeBtwAttack;
	public float attackRange;
	public LayerMask Player;
	public float damage;

	public Transform Target
	{
		get
		{
			return target;
		}

		set
		{
			target = value;
		}
	}
	public GameObject damageEffect;

	private Rigidbody2D rb;

	private BossEnemyScript Enemy;



	private void Start()
	{
		Enemy = GetComponent<BossEnemyScript>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		FollowTarget();
	}

	public void AnimateMovement(Vector2 direction)
	{
		anim.SetLayerWeight(1, 1);

		anim.SetFloat("x", +direction.x);

	}

	private void FollowTarget()
	{
		if (direction.x != 0)
		{
			AnimateMovement(direction);
		}


		if (target != null)
		{
			direction = (target.transform.position - transform.position);

			if (Vector2.Distance(transform.position, target.position) > StopDistan)
			{
				rb.MovePosition(Vector2.MoveTowards(transform.position, target.position, Enemy.speed * Time.deltaTime));
			}

			float distance = Vector2.Distance(target.position, transform.position);


			if (distance <= StopDistan)
			{

				if (target != null)
				{

					anim.SetLayerWeight(1, 0);
					if (timeBtwAttack <= 0)
					{
						Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(transform.position, attackRange, Player);
						for (int i = 0; i < playerToDamage.Length; i++)
						{
							playerToDamage[i].GetComponent<Player>().TakeDamage(damage);
						}


						timeBtwAttack = startTimeBtwAttack;
					}
					else
					{
						timeBtwAttack -= Time.deltaTime;
					}

				}

			}
		}
		else
		{
			anim.SetLayerWeight(1, 1);
			direction = Vector2.zero;
		}
	}

	private void Attack()
	{


	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.black;
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}