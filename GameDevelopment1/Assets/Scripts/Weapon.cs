using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	private float timeBtwShots;
	public float startTimeBtwShots;

	public GameObject bullet;

	Quaternion bulletDirection;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKey(KeyCode.DownArrow))
		{
			bulletDirection = Quaternion.Euler(0f, 0f, 270);
			ShootB();
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			bulletDirection = Quaternion.Euler(0f, 0f, 0);
			ShootB();
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			bulletDirection = Quaternion.Euler(0f, 0f, 90);
			ShootB();
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			bulletDirection = Quaternion.Euler(0f, 0f, 180);
			ShootB();
		}

		//Shoot();
	}

	void ShootB()
	{
		if (timeBtwShots <= 0)
		{
			Instantiate(bullet, this.gameObject.transform.position, bulletDirection);
			timeBtwShots = startTimeBtwShots;		
		}
		else
		{
			timeBtwShots -= Time.deltaTime;
		}
	}

	/*public void Shoot()
	{
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

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
	}*/
}
