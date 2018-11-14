using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	public Player player;

	public Animator anim;


    // Update is called once per frame

    private void Start()
    {
        anim.enabled = false;
    }

    void Update ()
	{
		if (player.isDoorOpen)
		{
            //anim.enabled = true;
            anim.SetInteger("int", 1);
        }
        else
        {
        	anim.SetInteger("int", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.enabled = true;
        }
    }
}
