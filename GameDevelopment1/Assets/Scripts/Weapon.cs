﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	private float timeBtwShots;
	public float startTimeBtwShots;
	public Transform shotPoint;
	public float offset;

	public GameObject bullet;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

		if (timeBtwShots <= 0)
		{
			if (Input.GetMouseButton(0))
			{

				Instantiate(bullet, shotPoint.position, transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}
		}
		else
		{
			timeBtwShots -= Time.deltaTime;
		}
	}

	public void Shoot()
	{
		
	}
}
