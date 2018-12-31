using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public CameraMovement CamMove;

    public GameObject destroyEffect;
    public GameObject shield;

    public int roomCount;
    public int goldCount;
    public int redPotCount;
    public int bluePotCount;

    public bool isDoorOpen;
    public bool redPotUsed;
    public bool isManaFinish;
    public bool isManaFull;

    public Animator FrameAnim;
    public GameObject HealthEffect;
    public GameObject ManaEffect;

    private float timer;
    private float specialTime = 3f;

    private bool isSpecialActive;
    public GameObject minimapCont;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        redPotCount = 1;
        bluePotCount = 1;
    }

    // Update is called once per frame
    protected override void Update()
    {
        ManaBarStats();

        timer += Time.deltaTime;
        if (isManaFinish == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isSpecialActive == false)
            {
                timer = 0;
                isSpecialActive = true;
            }
            if (isSpecialActive == true)
            {
                myRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                shield.SetActive(true);

                if (timer >= specialTime)
                {
                    timer = 0;
                    mana.MyCurrentValue -= 10;
                    isSpecialActive = false;
                    shield.SetActive(false);
                    myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }


        if (health.MyCurrentValue > 70)
        {
            FrameAnim.SetInteger("State", 2);

        }
        else if (health.MyCurrentValue < 70 && health.MyCurrentValue > 35)
        {
            FrameAnim.SetInteger("State", 0);

        }
        else if (health.MyCurrentValue < 35)
        {
            FrameAnim.SetInteger("State", 1);
        }



        GetInput();

        base.Update();

        CamMove.CameraShift();




    }

    void ManaBarStats()
    {
        if (mana.MyCurrentValue == 50)
        {
            isManaFull = true;
        }
        else if (mana.MyCurrentValue < 50)
        {
            isManaFull = false;
        }

        if (mana.MyCurrentValue == 0)
        {
            isManaFinish = true;
        }
        else if (mana.MyCurrentValue != 0)
        {
            isManaFinish = false;
        }

        if (Input.GetKeyDown(KeyCode.G) && mana.MyCurrentValue < 50 && bluePotCount > 0)
        {
            mana.MyCurrentValue += 10;
            bluePotCount -= 1;
            Instantiate(ManaEffect, transform.position, Quaternion.identity);
        }
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.F) && health.MyCurrentValue < health.MyMaxValue && redPotCount > 0)
        {
            health.MyCurrentValue += 10;
            redPotCount -= 1;
            Instantiate(HealthEffect, transform.position, Quaternion.identity);

        }
    }


    public virtual void TakeDamage(float damage)
    {
        health.MyCurrentValue -= damage;
        Instantiate(destroyEffect, transform.position, Quaternion.identity);

        if (health.MyCurrentValue <= 0)
        {
            LossScene.enabled = true;

            if (LossScene.enabled == true)
            {
                Time.timeScale = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        #region ROOMS
        if (other.gameObject.tag == "room1")
        {
            roomCount = 1;
            //CamMove.Shake(0.1f,0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room2")
        {
            roomCount = 2;
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room3")
        {
            roomCount = 3;
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room4")
        {
            roomCount = 4;
            // CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room5")
        {
            roomCount = 5;
            //CamMove.Shake(0.1f,0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room6")
        {
            roomCount = 6;
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room7")
        {
            roomCount = 7;
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room8")
        {
            roomCount = 8;
            // CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room9")
        {
            roomCount = 9;
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room10")
        {
            roomCount = 10;
            // CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "BossRoom")
        {
            roomCount = 11;
            // CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
            minimapCont.SetActive(false);
        }
        #endregion
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);

            if (isSpecialActive == false)
            {
                TakeDamage(10);
            }
        }
      

        if (other.gameObject.tag == "gold")
        {
            goldCount += 5;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "redPot")
        {
            redPotCount += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "bluePot")
        {
            bluePotCount += 1;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            isDoorOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            isDoorOpen = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (isSpecialActive == false)
            {
                // TakeDamage(10);
            }
        }

        if (collision.gameObject.tag == "Boss")
        {
            if (isSpecialActive == false)
            {
                //TakeDamage(30);
            }
        }
    }





}
