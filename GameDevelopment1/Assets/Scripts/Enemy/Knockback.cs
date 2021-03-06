﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    private float thrust;
    private float KnockTime;
    private Rigidbody2D rb;
    private MeeleEnemy mE;
    private PatrolShootingEnemy pS_E;

	// Use this for initialization
	void Start () {
        rb=GetComponent<Rigidbody2D>();
        mE = GetComponent<MeeleEnemy>();
	}
	
	// Update is called once per frame
	void Update () {
        thrust = Random.Range(80, 160);
        KnockTime = Random.Range(4, 5);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kalkan")
        {
            mE.enabled = false;
            Rigidbody2D kalkan = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 difference = transform.position - kalkan.transform.position;
            difference = difference.normalized * thrust;
            rb.AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(KnockOut(rb));
        }
    }

    IEnumerator KnockOut(Rigidbody2D enemy)
    {
        yield return new WaitForSeconds(KnockTime);
        mE.enabled = true;
    }
}
