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

    public Player playerMovement;

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
