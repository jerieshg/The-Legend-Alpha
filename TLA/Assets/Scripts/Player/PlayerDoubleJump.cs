using UnityEngine;
using System.Collections;

public class PlayerDoubleJump : MonoBehaviour {

	//Player Reference Data
	private PlayerData playerData;
	private bool canDoubleJump = false;

	void Start()
	{
		playerData = GameObject.Find("_PlayerManager").GetComponent<PlayerData>();
	}
	
	void FixedUpdate()
	{
		DoubleJump();
	}
	
	//Double Jump Logic
	void DoubleJump()
	{
		if(playerData.grounded)
		{
			canDoubleJump = true;

			if(Input.GetKeyDown(playerData.jump))
			{
				gameObject.rigidbody2D.AddForce(new Vector2(0.0f, playerData.jumpForce));
				playerData.grounded = false;
			}
		}
		else
		{
			if(canDoubleJump && Input.GetKeyDown(playerData.jump))
			{
				Debug.Log("Double Jump");
				gameObject.rigidbody2D.AddForce(new Vector2(0.0f, playerData.jumpForce));
				canDoubleJump = false;
			}
		}
	}

}
