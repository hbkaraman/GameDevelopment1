using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	[SerializeField]
	protected Stat mana;

	private float initMana = 50;

	public PotionScript potionmana;

	private float timeBtwShots;
	public float startTimeBtwShots;

	public GameObject bullet;

	protected bool isManaFinish;
	
	Quaternion bulletDirection;

	// Use this for initialization
	void Start ()
	{
		// For ManaBar
		mana.Initilized(initMana, initMana);
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (isManaFinish == false)
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

		ManabarEnd();
	}

	void ShootB()
	{
		if (timeBtwShots <= 0)
		{
			mana.MyCurrentValue -= 1;
			Instantiate(bullet, this.gameObject.transform.position, bulletDirection);
			timeBtwShots = startTimeBtwShots;		
		}
		else
		{
			timeBtwShots -= Time.deltaTime;
		}
	}

	public void ManabarEnd()
	{
		if(mana.MyCurrentValue <= 0)
		{
			isManaFinish = true;
		}
		else if(mana.MyCurrentValue != 0)
		{
			isManaFinish = false;
		}
	}

	public void ManaPotion()
	{
		if(potionmana.potiontriggered == true)
		{
			mana.MyCurrentValue += 10;
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
