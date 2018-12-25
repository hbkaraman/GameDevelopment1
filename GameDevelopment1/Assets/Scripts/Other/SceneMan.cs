using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour {

	public Animator anim;
	public string sceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator LoadScene()
	{
		//anim.SetTrigger("end");
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(sceneName);
	}


	public void StartGame()
	{
		SceneManager.LoadScene(sceneName);
		//StartCoroutine(LoadScene());
	}
	public void Quit()
	{
		Application.Quit();
	}
}
