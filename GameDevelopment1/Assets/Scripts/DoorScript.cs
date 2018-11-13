using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	public Player player;

	private Animator anim;

	// Update is called once per frame
	void Update ()
	{
		if (player.isDoorOpen)
		{
			anim.SetInteger("int", 1);
		}
		else
		{
			anim.SetInteger("int", 0);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}


}
