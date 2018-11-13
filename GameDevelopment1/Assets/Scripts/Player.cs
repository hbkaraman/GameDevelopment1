﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {


	public CameraMovement CamMove;
	public int roomCount;
	public bool isDoorOpen;


	// Use this for initialization
	protected override void Start ()
	{
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		GetInput();

		base.Update();
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
		if (other.gameObject.tag == "Door")
		{
			isDoorOpen = true;
		}
	}
}