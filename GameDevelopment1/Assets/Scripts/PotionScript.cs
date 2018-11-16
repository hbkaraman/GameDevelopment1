using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour {

	public bool potiontriggered;
	public Weapon mana;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			potiontriggered = true;

			if (mana.isManaFull == false)
			{
				Destroy(gameObject);
			}
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			potiontriggered = false;
		
		}
	}
}
