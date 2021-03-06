﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomScript : MonoBehaviour
{
    public Player pScript;

    public bool roomEntered;
    public bool roomInside;
    public bool roomFinished;
    public int destroyCount;
    public int roomFinishCount;

    public DoorScript[] doors;

    public Image minimapImage;
    public Image deactiveMinimapImage;

    public EnemyScript[] OnDestroyDispatchers;

    public UnityEngine.Events.UnityEvent OnAllObjectsDestroyed;

	private float timer;
	private float wait = 5;

    void Update()
    {
        if (destroyCount == OnDestroyDispatchers.Length)
        {
            roomFinished = true;
        }

        if (roomEntered == true && roomFinished == false)
        {
            for (int i = 0; i < doors.Length; i++)
                doors[i].doorCanOpen = false;

            for (int a = 0; a < OnDestroyDispatchers.Length; a++)
            {
				timer += Time.deltaTime;
				
				if(timer > wait)
				{
					OnDestroyDispatchers[a].gameObject.SetActive(true);
				}
            }
        }

        if (roomEntered == true && roomFinished == true)
        {
            for (int i = 0; i < doors.Length; i++)
                doors[i].doorCanOpen = true;
            roomFinishCount += 1;
        }

        if (roomInside == true)
        {
            minimapImage.gameObject.SetActive(true);
        }
        if (roomInside == false&&roomEntered==true)
        {
            minimapImage.gameObject.SetActive(false);
            deactiveMinimapImage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            roomEntered = true;
            roomInside = true;
            roomFinishCount += 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            roomInside = false;
        }
    }
}
