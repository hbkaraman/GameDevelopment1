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
	public float waittimeequ;
	public Animator anim;
	public float waitvideo;
	//public GameObject image;

	// Use this for initialization
	void Awake()
	{

	}

	// Update is called once per frame
	void Update()
	{
		videoTime += Time.deltaTime;

		if (videoTime >= video.clip.length - waitvideo)
		{
			waitTime += Time.deltaTime;
			//image.SetActive(true);
			anim.SetTrigger("end");

			if (waitTime >= waittimeequ)
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
