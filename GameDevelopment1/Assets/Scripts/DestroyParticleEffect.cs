using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleEffect : MonoBehaviour {

	private float timer;
	private float DestroyTime = 2f;

	void Update()
	{

		timer += Time.deltaTime;

		DestroyEffects();

	}

	void DestroyEffects()
	{
		if (timer >= DestroyTime)
		{
			timer = 0;
			Destroy(gameObject);
		}

	}
}
