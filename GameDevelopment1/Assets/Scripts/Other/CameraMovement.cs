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
    public Transform room5;
    public Transform room6;
    public Transform room7;
    public Transform room8;
    public Transform room9;
    public Transform room10;

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
        else if (playerMovement.roomCount == 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, room5.position, speed * Time.deltaTime);
        }
        else if (playerMovement.roomCount == 6)
        {
            transform.position = Vector2.MoveTowards(transform.position, room6.position, speed * Time.deltaTime);
        }
        else if (playerMovement.roomCount == 7)
        {
            transform.position = Vector2.MoveTowards(transform.position, room7.position, speed * Time.deltaTime);
        }
        else if (playerMovement.roomCount == 8)
        {
            transform.position = Vector2.MoveTowards(transform.position, room8.position, speed * Time.deltaTime);
        }
        else if (playerMovement.roomCount == 9)
        {
            transform.position = Vector2.MoveTowards(transform.position, room9.position, speed * Time.deltaTime);
        }
        else if (playerMovement.roomCount == 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, room10.position, speed * Time.deltaTime);
        }
    }
}
