using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingEnemy : MonoBehaviour {

	private float timeBtwShoots;
	public float startTimeBtwShoots;

	public GameObject Bullet;
	public Transform ShottingPoint;

	private bool isShot;
	private Animator anim;

    private AudioSource standingSource;
    public AudioClip standingSound;

	void Start()
	{
		anim = GetComponent<Animator>();
        standingSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (isShot == true)
		{
            
            anim.SetBool("isShoot", true);
		}
		else
		{
			anim.SetBool("isShoot", false);
		}

		if (timeBtwShoots <= 0)
		{
			Instantiate(Bullet, ShottingPoint.position, Quaternion.identity);
			standingSource.PlayOneShot(standingSound);
			isShot = true;
			timeBtwShoots = startTimeBtwShoots;
		}
		else
		{
			timeBtwShoots -= Time.deltaTime;
			isShot = false;
		}
	}
}
