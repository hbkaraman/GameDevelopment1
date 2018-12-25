using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup healthgroup;

    [SerializeField]
    public Stat enemyHealth;

    [SerializeField]
    public float health;

	public float firstSpeed;
	public float speed;
	private float stunTime;
	public float startStunTime;

    public RoomScript rS;
    public bool Enabled;

	private SpriteRenderer sprite;

    //public Animator camAnim;
    public GameObject deathEffect;
    public GameObject explosion;
    public GameObject gold;
    public GameObject bluePot;
    public GameObject redPot;

    private int lootChance;

	private void Start()
    {
		sprite = GetComponent<SpriteRenderer>();
        enemyHealth.Initilized(health, health);
    }

    private void Update()
	{
		Stun();

		healthgroup.alpha = 1;

		if (enemyHealth.MyCurrentValue <= 0)
		{
			rS.destroyCount += 1;
			Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
			lootChance = Random.Range(0, 10);
		}
		if (lootChance == 4 || lootChance == 5)
		{
			Instantiate(gold, transform.position, Quaternion.identity);
		}
		if (lootChance == 6 || lootChance == 7)
		{
			Instantiate(bluePot, transform.position, Quaternion.identity);
		}
		if (lootChance == 7 || lootChance == 8)
		{
			Instantiate(redPot, transform.position, Quaternion.identity);
		}
	}

	private void Stun()
	{
		if (stunTime <= 0)
		{
			speed = firstSpeed;
			sprite.color = Color.white;
		}
		else
		{
			sprite.color = new Color(255, 255, 0, 256);
			speed = 0;
			stunTime -= Time.deltaTime;
		}
	}

	public void TakeDamage(int damage)
    {
		stunTime = startStunTime;
        //camAnim.SetTrigger("shake");
        Instantiate(explosion, transform.position, Quaternion.identity);
        enemyHealth.MyCurrentValue -= damage;
    }
}
