using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour {

	public Animator anim;
	public string sceneName;
	private bool isKeyPress = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.anyKey && isKeyPress == false)
		{
			isKeyPress = true;
			StartCoroutine(LoadScene());
		}
	}

	IEnumerator LoadScene()
	{
		anim.SetTrigger("end");
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(sceneName);

	
	}


	/*public void StartGame()
	{
		SceneManager.LoadScene(sceneName);
		//StartCoroutine(LoadScene());
	}
	public void Quit()
	{
		Application.Quit();
	}*/
}
