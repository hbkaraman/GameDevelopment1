using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyDispatcher : MonoBehaviour
{
    public event System.Action<GameObject> OnObjectDestroyed;

    private void OnDestroy()
    {
        if (OnObjectDestroyed != null)
            OnObjectDestroyed(gameObject);

    }
}
