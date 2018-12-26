using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour {

	private Player Player;

	// Use this for initialization
	void Start ()
	{
		Player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.gameObject.transform.position=Player.transform.position;
	}
}
