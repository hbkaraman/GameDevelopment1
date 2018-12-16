using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public Player pScript;

    public bool roomEntered;
    public bool roomFinished;
    public int destroyCount;

    public DoorScript[] doors;

    public EnemyScript[] OnDestroyDispatchers;

    public UnityEngine.Events.UnityEvent OnAllObjectsDestroyed;


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
                OnDestroyDispatchers[a].gameObject.SetActive(true);
            }

        }

        if (roomEntered == true && roomFinished == true)
        {
            for (int i = 0; i < doors.Length; i++)
                doors[i].doorCanOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            roomEntered = true;
        }
    }
}
