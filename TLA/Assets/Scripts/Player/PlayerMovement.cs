using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//Player Reference Data
	private PlayerData playerData;

	void Start()
	{
		playerData = GameObject.Find("_PlayerManager").GetComponent<PlayerData>();
	}

	void FixedUpdate()
	{
		move();
	}

	void move()
	{
		if(Input.GetKey(playerData.moveLeft) || Input.GetKey (playerData.moveRight))
		{
			float movement = Input.GetAxisRaw("Horizontal");
			transform.Translate(movement * playerData.speed * Time.deltaTime,0,0);
		}
	}

}
