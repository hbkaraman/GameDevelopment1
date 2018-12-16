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

    // Drag & drop the objects in the inspector
    public EnemyDestroyDispatcher[] OnDestroyDispatchers;

    // You will be able to add a function once all the objects are destroyed
    public UnityEngine.Events.UnityEvent OnAllObjectsDestroyed;

    void Start()
    {
        for (int i = 0; i < OnDestroyDispatchers.Length; ++i)
            OnDestroyDispatchers[i].OnObjectDestroyed += OnObjectDestroyed;
    }

    void Update()
    {
        if (destroyCount == OnDestroyDispatchers.Length)
        {
            roomFinished = true;
        }
        if (roomEntered == true && roomFinished == false)
        {
            //doors[doorNum].doorCanOpen = false;
            for (int i = 0; i < doors.Length; i++)
                doors[i].doorCanOpen = false;
        }
        if (roomEntered == true && roomFinished == true)
        {
            for (int i = 0; i < doors.Length; i++)
                doors[i].doorCanOpen = true;
        }
    }

    private void OnObjectDestroyed(GameObject destroyedObject)
    {
        CheckAllObjectsAreDestroyed();
    }

    private void CheckAllObjectsAreDestroyed()
    {        
        for (int i = 0; i < OnDestroyDispatchers.Length; ++i)
        {
            if (OnDestroyDispatchers[i] != null || OnDestroyDispatchers[i].gameObject != null)
            {
                destroyCount += 1;
                return;
            }
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
