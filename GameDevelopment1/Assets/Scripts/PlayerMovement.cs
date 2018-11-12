using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField]
	private float speed;

	private Vector2 direction;
	private Vector2 ShootDirection;

	public Transform ShotPosition;

	//public bool isShoot;
	public bool isShootleft;
	public bool isShootRight;


	public bool isMoving;
	
	public GameObject bullet;


    private float timeBtwShots;
    public float startTimeBtwShots;

    public int roomCount;

    public CameraMovement CamMove;
   
    void Start()
    {
		//localScale = GetComponent<Transform>().localScale;
		
	}

    void Update()
    {
		//For Movement
			GetInp();
			Move();

		//ForShoot
			ShootInp();
			Shoot();
    }

	public void Shoot()
	{
		if (timeBtwShots <= 0 )
		{
			if (isShootleft == true)
			{
				Debug.Log(isShootleft);
				Instantiate(bullet,ShotPosition.position,transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}

			if (isShootRight == true)
			{
				Instantiate(bullet,ShotPosition.position, transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}
				
		}
		else
		{
			isShootleft = false;
			isShootRight = false;
			timeBtwShots -= Time.deltaTime;
		}
		
	}

	public void Move()
	{
		transform.Translate(direction * speed * Time.deltaTime);
	}

	private void GetInp()
	{
		direction = Vector2.zero;

		if (Input.GetKey(KeyCode.W))
		{
			direction += Vector2.up;
		}
		if (Input.GetKey(KeyCode.A))
		{
			direction += Vector2.left;
		}
		if (Input.GetKey(KeyCode.S))
		{
			direction += Vector2.down;
		}
		if (Input.GetKey(KeyCode.D))
		{
			direction += Vector2.right;
		}
	}

	public void ShootInp()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			isShootleft = true;
			
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			isShootRight = true;
		
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
			//isShoot = true;
		
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			//isShoot = true;
		}
		
	}




    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "room1")
        {
            roomCount = 1;
            //CamMove.Shake(0.1f,0.1f);
            CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room2")
        {
            roomCount = 2;
            //CamMove.Shake(0.1f, 0.1f);
            CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room3")
        {
            roomCount = 3;
            //CamMove.Shake(0.1f, 0.1f);
            CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room4")
        {
            roomCount = 4;
            // CamMove.Shake(0.1f, 0.1f);
            CamMove.CameraShift();
        }
    }


}
