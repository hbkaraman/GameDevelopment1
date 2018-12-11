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

    private int lootChance;


	//public Animator camAnim;
	public GameObject deathEffect;
	public GameObject explosion;
    public GameObject gold;
    public GameObject bluePot;
    public GameObject redPot;

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
            lootChance = Random.Range(0, 10);
		}
        Debug.Log(lootChance);
        if (lootChance == 4 || lootChance == 5)
        {
            Instantiate(gold, transform.position, Quaternion.identity);
        }
        if (lootChance == 6 || lootChance ==7 )
        {
            Instantiate(bluePot, transform.position, Quaternion.identity);
        }
        if (lootChance == 7 || lootChance == 8)
        {
            Instantiate(redPot, transform.position, Quaternion.identity);
        }

    }

    public void TakeDamage(int damage)
	{
		//camAnim.SetTrigger("shake");
		Instantiate(explosion, transform.position, Quaternion.identity);
		enemyHealth.MyCurrentValue -= damage;
	}
}
