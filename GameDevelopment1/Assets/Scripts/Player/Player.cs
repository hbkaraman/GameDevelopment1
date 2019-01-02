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

    public AudioSource grootSource;
	public AudioSource cam;
	public AudioClip grootSound;
	public AudioClip Coin;
	public AudioClip Health;
	public AudioClip Mana;
	public AudioClip damagee;
	public AudioClip PickUp;

	public bool isDead;


	// Use this for initialization
	protected override void Start()
    {
        grootSource = GetComponent<AudioSource>();
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
            mana.MyCurrentValue += 5;
            bluePotCount -= 1;
            Instantiate(ManaEffect, transform.position, Quaternion.identity);
            iTween.ShakeScale(this.gameObject, iTween.Hash("x", 0.1, "time", 2, "easetype", "easeInOutSine"));
			grootSource.PlayOneShot(Mana);
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
            health.MyCurrentValue += 15;
            redPotCount -= 1;
            Instantiate(HealthEffect, transform.position, Quaternion.identity);
            iTween.ShakeScale(this.gameObject, iTween.Hash("x", 0.1, "time", 2, "easetype", "easeInOutSine"));
			grootSource.PlayOneShot(Health);
		}
	}

    public virtual void TakeDamage(float damage)
    {
        health.MyCurrentValue -= damage;
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
		grootSource.PlayOneShot(damagee);

        if (health.MyCurrentValue <= 0)
        {
			isDead = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        #region ROOMS
        if (other.gameObject.tag == "room1")
        {
            roomCount = 1;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            //CamMove.Shake(0.1f,0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room2")
        {
            roomCount = 2;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room3")
        {
            roomCount = 3;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room4")
        {
            roomCount = 4;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            // CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room5")
        {
            roomCount = 5;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            //CamMove.Shake(0.1f,0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room6")
        {
            roomCount = 6;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room7")
        {
            roomCount = 7;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room8")
        {
            roomCount = 8;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            // CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room9")
        {
            roomCount = 9;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            //CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "room10")
        {
            roomCount = 10;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
            // CamMove.Shake(0.1f, 0.1f);
            //CamMove.CameraShift();
        }
        if (other.gameObject.tag == "BossRoom")
        {
            roomCount = 11;
            grootSource.pitch = Random.Range(0.75f, 1.15f);
            grootSource.PlayOneShot(grootSound);
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
			grootSource.PlayOneShot(Coin);
			Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "redPot")
        {
            redPotCount += 1;
			grootSource.PlayOneShot(PickUp);
			Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "bluePot")
        {
            bluePotCount += 1;
			grootSource.PlayOneShot(PickUp);
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
}
