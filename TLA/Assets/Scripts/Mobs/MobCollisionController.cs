﻿using UnityEngine;
using System.Collections;

public class MobCollisionController : MonoBehaviour {



	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "wall")
		{

		}
	}

}
