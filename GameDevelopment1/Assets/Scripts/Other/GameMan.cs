using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour {

	public Player player;
	public BoosScript boos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(player.isDead == true)
		{
			SceneManager.LoadScene("LossScene");
		}

		if(boos.isDead == true)
		{
			SceneManager.LoadScene("WinScene");
		}
	}
	
}
