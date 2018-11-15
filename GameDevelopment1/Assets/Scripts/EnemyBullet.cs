using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float hitChance = 0f;

    private GameObject target;
    private Vector3 missOffset = Vector3.zero;
    private bool isHitting = false;
    private bool isCheckingChance = true;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(target.GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheckingChance)
        {
            float chance = Random.Range(0f, 100f);
            if (chance <= hitChance)
            {
                isHitting = true;
                transform.LookAt(target.GetComponent<Transform>().position + new Vector3(0f, 1f, 0f));
            }
            else
            {
                isHitting = false;
                missOffset = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0f);
                transform.LookAt(target.GetComponent<Transform>().position + missOffset);
            }
            Debug.Log("IsHitting = " + isHitting);
        }

        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        isCheckingChance = false;

        transform.Translate(Vector3.forward * Time.timeScale / 5);

        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
        isCheckingChance = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            // TODO
            Debug.Log("I hit player!");
            GetComponent<LineRenderer>().enabled = false;
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Environment")
        {
            Debug.Log("I hit environment!");
            Destroy(gameObject);
        }
    }
}
