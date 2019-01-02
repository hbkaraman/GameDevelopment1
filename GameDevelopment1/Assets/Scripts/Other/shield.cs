using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour {

    public AudioClip specialSound;
    private AudioSource specialSource;

	void Start () {
        specialSource = GetComponent<AudioSource>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            specialSource.PlayOneShot(specialSound);
        }
	}
}
