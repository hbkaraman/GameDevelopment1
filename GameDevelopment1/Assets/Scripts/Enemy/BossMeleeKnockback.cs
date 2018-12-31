using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeKnockback : MonoBehaviour
{

    private float bossThrust;
    private float bossKnockTime;
    private Rigidbody2D bossRb;
    private BossEnemyMeele bossMelee;
    private PatrolShootingEnemy pS_E;

    // Use this for initialization
    void Start()
    {
        bossRb = GetComponent<Rigidbody2D>();
        bossMelee = GetComponent<BossEnemyMeele>();
    }

    // Update is called once per frame
    void Update()
    {
        bossThrust = Random.Range(80, 160);
        bossKnockTime = Random.Range(4, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kalkan")
        {
            bossMelee.enabled = false;
            Rigidbody2D kalkan = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 difference = transform.position - kalkan.transform.position;
            difference = difference.normalized * bossThrust;
            bossRb.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(BossKnockOut(bossRb));
        }
    }

    IEnumerator BossKnockOut(Rigidbody2D enemy)
    {
        yield return new WaitForSeconds(bossKnockTime);
        bossMelee.enabled = true;
    }
}
