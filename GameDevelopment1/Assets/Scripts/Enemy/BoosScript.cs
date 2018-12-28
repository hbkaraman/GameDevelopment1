using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosScript : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup healthgroup;

    [SerializeField]
    private Stat bossHealth;

    [SerializeField]
    private float health;


    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform shootingPosition;
    public Transform shootingPosition2;
    public GameObject enemyBullet;

    public GameObject[] lineBullet;
    public Transform ShottingPoint;

    private float timeBtwShoots;
    public float startTimeBtwShoots;

    private int Randomize;

    private Animator Anim;

    private bool isShoot;
    private bool isIdle;
    private bool shooting;
    public bool bossDown;
    public bool lineShoot;
    public bool canMove;

    private EnemyScript Enemy;

    private Rigidbody2D rb;

    private Transform target;
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

    public Image winScene;

    //public Animator camAnim;
    public GameObject deathEffect;
    public GameObject explosion;

    private void Start()
    {
        Enemy = GetComponent<EnemyScript>();
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        shooting = true;
        waitTime = startWaitTime;
        canMove = true;

        moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 44.4f);

        bossHealth.Initilized(health, health);
    }

    private void Update()
    {
        Debug.Log(bossHealth.MyCurrentValue);
        healthgroup.alpha = 1;

        Movement();

        Shoot();

        if (isShoot == true)
        {
            Anim.SetInteger("State", 1);
        }
        else
        {
            Anim.SetInteger("State", 0);
        }

        if (bossHealth.MyCurrentValue <= 5f)
        {
            Debug.Log("aaa");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            winScene.enabled = true;
            Time.timeScale = 0;
            Destroy(gameObject);
        }

        if (bossHealth.MyCurrentValue <= 150 && bossHealth.MyCurrentValue >= 100)
        {
            StartCoroutine(Invisible());
        }
        if (bossHealth.MyCurrentValue <= 100)
        {
            startWaitTime = 1f;
            startTimeBtwShoots = 0.4f;
        }
        if (bossHealth.MyCurrentValue <= 50)
        {
            StartCoroutine(ShootLine());
        }
    }

    IEnumerator Invisible()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 150);
        startTimeBtwShoots = 0.1f;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 50);
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(3f);
        startTimeBtwShoots = 0.7f;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator ShootLine()
    {
        lineShoot = true;
        //canMove = false;
        yield return new WaitForSeconds(5f);
        lineShoot = false;
        //canMove = true;
    }

    void Movement()
    {
        if (canMove)
        {
            //rb.MovePosition(Vector2.MoveTowards(transform.position, moveSpot.position, Enemy.speed * Time.deltaTime));
            transform.position = (Vector3.MoveTowards(transform.position, moveSpot.position, Enemy.speed * Time.deltaTime));

            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 44.4f);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        //camAnim.SetTrigger("shake");
        Instantiate(explosion, transform.position, Quaternion.identity);
        bossHealth.MyCurrentValue -= damage;

    }

    void Shoot()
    {
        if (shooting)
        {
            if (target != null)
            {
                Randomize = Random.Range(0, 2);

                if (timeBtwShoots <= 0)
                {
                    if (Randomize == 0)
                    {
                        Instantiate(enemyBullet, shootingPosition.position, Quaternion.identity);
                        isShoot = true;

                    }
                    else if (Randomize == 1)
                    {
                        Instantiate(enemyBullet, shootingPosition2.position, Quaternion.identity);
                        isShoot = true;
                    }
                    timeBtwShoots = startTimeBtwShoots;
                }
                else
                {
                    timeBtwShoots -= Time.deltaTime;
                    isShoot = false;
                }
            }
        }

        if (lineShoot)
        {
            if (timeBtwShoots <= 0)
            {
                for (int a = 0; a < 4; a++)
                {
                    Instantiate(lineBullet[a], ShottingPoint.position, Quaternion.identity);
                    timeBtwShoots = startTimeBtwShoots;
                }
            }
            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
        }
    }
}
