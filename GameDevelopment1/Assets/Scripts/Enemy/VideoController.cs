using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

	public VideoPlayer video;
	public string Level;
	private float videoTime;
	private float waitTime;
	private float waittimeequ = 3;

	// Use this for initialization
	void Awake()
	{

	}

	// Update is called once per frame
	void Update()
	{
		videoTime += Time.deltaTime;

		if (videoTime >= video.clip.length)
		{
			waitTime += Time.deltaTime;

			if(waitTime >= waittimeequ)
			{
				SceneManager.LoadScene(Level);
			}
		}
		/*
		if (videoTime >= video.clip.length)
		{
			
		}
		*/
	}
}
