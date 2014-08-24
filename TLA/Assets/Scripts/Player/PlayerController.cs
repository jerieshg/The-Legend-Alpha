using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Player Reference Data
	private PlayerData playerData;
	//Shield Action Logic variables
	private float DefenceMultiplier;
	private float currentSpeed = 0.0f;

	void Start()
	{
		playerData = GameObject.Find("_PlayerManager").GetComponent<PlayerData>();
	}

	void Update()
	{
		ShieldAction();
	}

	void FixedUpdate()
	{
		checkIfAlive();
	}

	void ShieldAction()
	{
		if(playerData.shieldOn)
		{
			if(Input.GetKeyDown (playerData.rightArm))
			{
				currentSpeed = playerData.speed;
				DefenceMultiplier = playerData.defenceMultiplier;
				playerData.defence = playerData.defence * playerData.defenceMultiplier;
				playerData.speed = playerData.speed - 2;
			}
			else if(Input.GetKeyUp (playerData.rightArm))
			{
				playerData.defence = DefenceMultiplier;
				playerData.speed = currentSpeed	;
			}
		}
	}

	void takeDamage(float damage)
	{
		playerData.hitPoints -= damage;
		Debug.Log("You took "+damage);
	}

	void checkIfAlive()
	{
		if(playerData.hitPoints <= 0)
		{
			Destroy(gameObject);
		}
	}

}
