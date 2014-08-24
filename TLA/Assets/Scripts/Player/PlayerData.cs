using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	//Player handling
	public float speed = 4;
	public float speedMultiplier = 2;
	public float defenceMultiplier = 2;
	public float jumpForce = 350;
	[HideInInspector]
	public bool grounded = false;

	//Attributes
	public float strenght = 4;
	public float defence = 2;
	public float magic = 0;
	public float attackSpeed = 2;
	public float spellCoolDown = 0;
	public float weaponAttackRange = 0.9f;

	//Hp and Mana (Maybe Stamina in future)
	public float hitPoints = 100;
	public float manaPoints = 50;

	//Player Controls
	public KeyCode moveRight;
	public KeyCode moveLeft;
	public KeyCode jump;
	public KeyCode rightArm;
	public KeyCode leftArm;
	public KeyCode sprint;
	//Player equipment

	[HideInInspector]
	public bool shieldOn = false;
	[HideInInspector]
	public bool weaponOn = false;
	

}
