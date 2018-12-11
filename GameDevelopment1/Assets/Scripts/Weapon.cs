using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	

	private float timeBtwShots;
	public float startTimeBtwShots;

	public GameObject bullet;
    public Player player;

	Quaternion bulletDirection;

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
			if (Input.GetKey(KeyCode.DownArrow))
			{
				bulletDirection = Quaternion.Euler(0f, 0f, 270);
				ShootB();
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				bulletDirection = Quaternion.Euler(0f, 0f, 0);
				ShootB();
			}
			else if (Input.GetKey(KeyCode.UpArrow))
			{
				bulletDirection = Quaternion.Euler(0f, 0f, 90);
				ShootB();
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				bulletDirection = Quaternion.Euler(0f, 0f, 180);
				ShootB();
			}
		
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

}
