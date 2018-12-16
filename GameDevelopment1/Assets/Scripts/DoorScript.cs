using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	public Player player;

	public Animator anim;
    public bool doorCanOpen;
    public Collider2D myCol;


    // Update is called once per frame

    private void Start()
    {
        doorCanOpen = true;
        myCol = GetComponent<BoxCollider2D>();
    }

    void Update ()
	{
        if (doorCanOpen == false)
        {
            myCol.isTrigger = false;
        }
        else if (doorCanOpen == true)
        {
            myCol.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&doorCanOpen==true)
        {
            anim.SetInteger("int", 1);
            anim.speed = 1;
            anim.Play("KapiOpen");
            //anim.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetInteger("int", 0);
            anim.speed = 1;
            anim.Play("KapiKapali");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetInteger("int", 0);
            anim.speed = 1;
            anim.Play("KapiKapali");
        }
    }
}
