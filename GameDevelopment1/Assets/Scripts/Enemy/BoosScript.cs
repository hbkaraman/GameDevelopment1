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
	public Transform enemSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform shootingPosition;
    public GameObject enemyBullet;

    public GameObject[] lineBullet;
    public Transform ShottingPoint;

    private float timeBtwShoots;
    public float startTimeBtwShoots;

	private float timeBtwShootsLine;
	public float startTimeBtwShootsLine;


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

	public GameObject ınstanEnemy;

	private float Timer;
	private float waitTimer = 4f;

    private void Start()
    {
        Enemy = GetComponent<EnemyScript>();
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        shooting = true;
        waitTime = startWaitTime;
        canMove = true;
        lineShoot = false;

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

        if (bossHealth.MyCurrentValue <= 150 && bossHealth.MyCurrentValue >= 130)
        {
            StartCoroutine(Invisible());
		
        }
        if (bossHealth.MyCurrentValue <= 130)
        {
            startWaitTime = 1f;
            startTimeBtwShoots = 0.4f;


			Timer += Time.deltaTime;

			if(Timer> waitTimer)
			{
				Spawn();
				Timer = -5;
			}
		
        }
        if (bossHealth.MyCurrentValue <= 40)
        {
            StartCoroutine(ShootLine());
        }
    }

    IEnumerator Invisible()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        startTimeBtwShoots = 0.1f;
        yield return new WaitForSeconds(2f);
     /*   GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(2f);
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);*/
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

	void Spawn()
	{
		enemSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 44.4f);
		Instantiate(ınstanEnemy, enemSpot.position, Quaternion.identity);
		enemSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 44.4f);
		Instantiate(ınstanEnemy, enemSpot.position, Quaternion.identity);
		enemSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 44.4f);
		Instantiate(ınstanEnemy, enemSpot.position, Quaternion.identity);

	}

	void Shoot()
    {
        if (shooting)
        {
            if (target != null)
            {   
                if (timeBtwShoots <= 0)
                {

					Instantiate(enemyBullet, shootingPosition.position, Quaternion.identity);
					isShoot = true;
			
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
            if (timeBtwShootsLine <= 0)
            {
                for (int a = 0; a < 4; a++)
                {
                    Instantiate(lineBullet[a], ShottingPoint.position, Quaternion.identity);
                    timeBtwShootsLine = startTimeBtwShootsLine;
                }
            }
            else
            {
                timeBtwShootsLine -= Time.deltaTime;
            }
        }
    }
}
