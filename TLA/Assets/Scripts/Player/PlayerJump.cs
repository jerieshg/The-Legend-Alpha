using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	//Player Reference Data
	private PlayerData playerData;

	void Start()
	{
		playerData = GameObject.Find("_PlayerManager").GetComponent<PlayerData>();
	}

	void FixedUpdate()
	{
		jump();
	}

	//Jump Logic
	void jump()
	{
		if(playerData.grounded)
		{
			if(Input.GetKey(playerData.jump))
			{
				gameObject.rigidbody2D.AddForce(new Vector2(0.0f, playerData.jumpForce));
				playerData.grounded = false;
			}
		}
	}
}
