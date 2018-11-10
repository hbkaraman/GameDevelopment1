using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Camera gameplayCamera;
    //float shakeAmount = 0f;
    public float speed;

    public Transform room1;
    public Transform room2;
    public Transform room3;
    public Transform room4;

    public PlayerMovement playerMovement;

    private void Awake()
    {
        if (gameplayCamera == null)
        {
            gameplayCamera = Camera.main;
        }
    }

    private void Update()
    {

    }

    /*#region SHAKE
    public void Shake(float amount, float duration)
    {
        shakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", duration);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector2 camPos = gameplayCamera.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;
            gameplayCamera.transform.position = camPos;

        }

    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        gameplayCamera.transform.localPosition = Vector2.zero;
    }
    #endregion*/

    public void CameraShift()
    {
        if (playerMovement.roomCount == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, room1.position, speed * Time.deltaTime);
        }
        else if (playerMovement.roomCount == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, room2.position, speed * Time.deltaTime);
        }
        else if (playerMovement.roomCount == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, room3.position, speed * Time.deltaTime);
        }
        else if (playerMovement.roomCount == 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, room4.position, speed * Time.deltaTime);
        }
    }
}
