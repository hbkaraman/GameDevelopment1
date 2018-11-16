using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public CameraMovement CamMove;

    public int roomCount;

    public bool isDoorOpen;

    public GameObject destroyEffect;

	public GameObject shield;

	private float timer;

	private float specialTime = 3f;

	private bool isSpecialActive;

	// Use this for initialization
	protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {

		timer += Time.deltaTime;

		if (Input.GetKey(KeyCode.Space))
		{
			timer = 0;
			isSpecialActive = true;
			shield.SetActive(true);
		}
		if(isSpecialActive == true)
		{

			myRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

			if (timer >= specialTime)
			{
				timer = 0;
				isSpecialActive = false;
				shield.SetActive(false);
				myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
			}

		}
		

		if (Input.GetKey(KeyCode.R))
		{
			Time.timeScale = 1;
			Application.LoadLevel(Application.loadedLevel);
		}

		GetInput();

		base.Update();

        CamMove.CameraShift();
    }


    private void GetInput()
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "room1")
        {
            roomCount = 1;
            //CamMove.Shake(0.1f,0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room2")
        {
            roomCount = 2;
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room3")
        {
            roomCount = 3;
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room4")
        {
            roomCount = 4;
            // CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }

        if (other.gameObject.tag == "bullet")
        {
			Destroy(other.gameObject);

			if(isSpecialActive == false)
			{
				TakeDamage(10);
				Instantiate(destroyEffect, transform.position, Quaternion.identity);
			}   
        }
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Door")
		{
			isDoorOpen = true;
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		{
			if(isSpecialActive == false)
			{
				TakeDamage(10);
			}
		}

		if (collision.gameObject.tag == "Boss")
		{
			if (isSpecialActive == false)
			{
				TakeDamage(30);
			}
		}
	}
}
