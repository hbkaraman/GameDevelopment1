using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapScript : MonoBehaviour {

    public Player player;
    public Image[] activeImage;
    public bool roomExit;

	void Start () {
		
	}
	
	void Update () {
        if (player.roomCount == 1)
        {
            activeImage[0].gameObject.SetActive(true);
        }
        if (player.roomCount == 2)
        {
            activeImage[1].gameObject.SetActive(true);
        }
        if (player.roomCount == 3)
        {
            activeImage[2].gameObject.SetActive(true);
        }
        if (player.roomCount == 4)
        {
            activeImage[3].gameObject.SetActive(true);
        }
    }
}
