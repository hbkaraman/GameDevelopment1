using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    public float speed ;
    public GameObject player;
    public Vector3 playerOffset;
    public bool playerTriggered;
    public GameObject enemy;

    void Start () {
        playerOffset = new Vector3(Random.Range(0,2),Random.Range(0,2), 0);
    }

    void Update () {

        if (playerTriggered == true)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position - playerOffset, speed*Time.deltaTime);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerTriggered = true;
        }
    }
}
