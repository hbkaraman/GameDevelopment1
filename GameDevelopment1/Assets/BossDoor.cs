using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{

    public RoomManager RM;
    public Animator anim;
    public Collider2D bossCol;

    void Start()
    {
        bossCol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (RM.bossDoor == true)
        {
            bossCol.isTrigger = true;
        }
        if (RM.bossDoor == false)
        {
            bossCol.isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (RM.bossDoor == true)
            {
                anim.SetInteger("int", 1);
                anim.speed = 1;
                anim.Play("KapiOpen1");
            }
            RM.bossDoor = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (RM.bossDoor == true)
            {
                anim.SetInteger("int", 0);
                anim.speed = 1;
                anim.Play("KapiKapali1");
            }
        }
    }
}
