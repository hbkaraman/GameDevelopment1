using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float fireTime = 2f;
    public float shootingDistance = 100000f;

    private GameObject player;
    private Transform playerTransform;
    private bool canShoot = true;
    private bool playerTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrigger == true)
        {
            if (playerTransform.position.z - transform.position.z <= shootingDistance)
            {
                if (canShoot)
                    StartCoroutine(Fire());
            }
        }
    }

    IEnumerator Fire()
    {
        canShoot = false;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(fireTime);
        canShoot = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerTrigger = false;
        }
    }

}
