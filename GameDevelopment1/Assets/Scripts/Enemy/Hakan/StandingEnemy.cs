using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingEnemy : MonoBehaviour {

	private float timeBtwShoots;
	public float startTimeBtwShoots;

	public GameObject Bullet;
	public Transform ShottingPoint;

	void Start()
	{
		
	}

	void Update()
	{
		
		if (timeBtwShoots <= 0)
		{
			Instantiate(Bullet, ShottingPoint.position, Quaternion.identity);
			timeBtwShoots = startTimeBtwShoots;
		}
		else
		{
			timeBtwShoots -= Time.deltaTime;
		}

	}

}
