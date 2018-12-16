using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{

    public float startTimeBtwShots;
    public GameObject bullet;
    public GameObject player;
    public EnemyFollow eF;
    public Vector3 direction;

    Quaternion bulletDirection;

    private float timeBtwShots;

    void Update()
    {
        Debug.Log(bulletDirection);
        transform.LookAt(player.transform);
        direction = gameObject.transform.position;
        bulletDirection = Quaternion.LookRotation(player.transform.position-transform.position);

        Debug.Log(eF.playerTriggered);
        if (eF.playerTriggered==true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, direction, bulletDirection);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
