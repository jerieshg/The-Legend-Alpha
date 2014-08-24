using UnityEngine;
using System.Collections;

public class PlayerSprint : MonoBehaviour {

	//Player Reference Data
	private PlayerData playerData;
	private float currentSpeed = 0.0f;

	void Start()
	{
		playerData = GameObject.Find("_PlayerManager").GetComponent<PlayerData>();

	}

	void FixedUpdate()
	{
		Sprint();
	}

	void Sprint()
	{	
		if(Input.GetKeyDown (playerData.sprint))
		{
			currentSpeed = playerData.speed;
			playerData.speed = playerData.speed * playerData.speedMultiplier;
		}
		else if(Input.GetKeyUp (playerData.sprint))
		{
			playerData.speed = currentSpeed;
		}
	}
}
