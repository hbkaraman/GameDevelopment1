using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScripts : MonoBehaviour {

	
    public void StartGame()
    {
        SceneManager.LoadScene("SecondScene");
    }
    public void Quit ()
    {
       Application.Quit();
    }
}
