using UnityEngine;
using System.Collections;

public class PlayerCollisionController : MonoBehaviour {

	//Player Data Reference
	private PlayerData playerData;
	
	void Start()
	{
		playerData = GameObject.Find("_PlayerManager").GetComponent<PlayerData>();
	}
	
	void OnCollisionEnter2D(Collision2D Entity)
	{
		if(Entity.gameObject.tag == "Ground")
		{
			playerData.grounded = true;
		}
	}
}
