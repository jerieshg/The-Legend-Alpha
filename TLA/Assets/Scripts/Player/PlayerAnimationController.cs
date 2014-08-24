using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {

	//Skeleton body reference animations
	private Animator skeletonAnimations;
	//Skeleton arm reference animations
	private Animator skeletonRightHandAnimations;
	private Animator skeletonLeftHandAnimations;
	//Player data reference
	private PlayerData playerManager;
	//Value for localScale
	private float x;

	void Start()
	{
		skeletonRightHandAnimations = GameObject.Find("NormalSkeletonRight").GetComponent<Animator>();
		skeletonLeftHandAnimations = GameObject.Find("NormalSkeletonLeft").GetComponent<Animator>();
		skeletonAnimations = GameObject.Find("_PlayerModel").GetComponent<Animator>();
		//Getting player data
		playerManager = GameObject.Find("_PlayerManager").GetComponent<PlayerData>();
		//Getting Sprite localScale
		x = transform.localScale.x;
	}

	void Update()
	{
		WalkAnimation();
		JumpAnimation();
		RightArm();
		LeftArm();
	}

	//Walk animation
	void WalkAnimation()
	{
		if(Input.GetKey(playerManager.moveRight))
		{
			transform.localScale = new Vector3(x,x,x);
			skeletonAnimations.SetFloat ("Walk",1.0f);
		}
		else if(Input.GetKey (playerManager.moveLeft))
		{
			transform.localScale = new Vector3(-x,x,x);
			skeletonAnimations.SetFloat ("Walk",1.0f);
		}	
		else if(Input.GetKeyUp (playerManager.moveRight) || Input.GetKeyUp(playerManager.moveLeft))
		{
			skeletonAnimations.SetFloat ("Walk",0.0f);
		}
	}

	//Jump Animations
	void JumpAnimation()
	{
		if(playerManager.grounded)
		{
			skeletonAnimations.SetBool ("Grounded",playerManager.grounded);
		}
		else
		{
			skeletonAnimations.SetBool ("Grounded",playerManager.grounded);
		}
	}

	//Arm States
	void RightArm()
	{
		if(playerManager.shieldOn)
		{
			skeletonRightHandAnimations.SetBool("ShieldOn",playerManager.shieldOn);
			RightArmShieldAction();
		}
		else
		{
			skeletonRightHandAnimations.SetBool("ShieldOn",playerManager.shieldOn);
		}
	}

	void RightArmShieldAction()
	{
		if(Input.GetKey(playerManager.rightArm))
		{
			skeletonRightHandAnimations.SetFloat("ShieldAction",1.0f);
		}
		else if(Input.GetKeyUp(playerManager.rightArm))
		{
			skeletonRightHandAnimations.SetFloat("ShieldAction",0.0f);
		}
	}

	void LeftArm()
	{
		if(playerManager.weaponOn)
		{
			skeletonLeftHandAnimations.SetBool("WeaponOn",playerManager.weaponOn);
			LeftArmWeaponAction();
		}
		else
		{
			skeletonLeftHandAnimations.SetBool("WeaponOn",playerManager.weaponOn);
		}
	}

	void LeftArmWeaponAction()
	{
		if(Input.GetKey(playerManager.leftArm))
		{
			skeletonLeftHandAnimations.SetFloat("Attack",1.0f);
			StartCoroutine(waitForCd(playerManager.attackSpeed));
		}
	}

	//Attack Speed Animation
	IEnumerator waitForCd(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		skeletonLeftHandAnimations.SetFloat("Attack",0.0f);
	}

}
