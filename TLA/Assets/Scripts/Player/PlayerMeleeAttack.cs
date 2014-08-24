using UnityEngine;
using System.Collections;

public class PlayerMeleeAttack : MonoBehaviour {

	//Player Reference Data
	private PlayerData playerData;
	//Attack Action Variables
	private RaycastHit2D rayHit;
	public LayerMask enemyLayer;
	//Value for localScale
	private float x;

	void Start()
	{
		playerData = GameObject.Find("_PlayerManager").GetComponent<PlayerData>();
	}

	void FixedUpdate()
	{
		x = GameObject.Find("_Player").transform.localScale.x;
		Debug.DrawLine(transform.position,new Vector3(transform.position.x + playerData.weaponAttackRange * x, transform.position.y, transform.position.z),Color.blue);
	}

	void Attack()
	{
		if(Physics2D.Linecast(transform.position,new Vector3(transform.position.x + playerData.weaponAttackRange * x, transform.position.y, transform.position.z),enemyLayer))
		{
			Debug.DrawLine(transform.position,new Vector3(transform.position.x + playerData.weaponAttackRange * x, transform.position.y, transform.position.z),Color.red);
			rayHit = Physics2D.Linecast(transform.position,new Vector3(transform.position.x + playerData.weaponAttackRange * x, transform.position.y, transform.position.z),enemyLayer);
			rayHit.transform.SendMessage("takeDamage",playerData.strenght,SendMessageOptions.DontRequireReceiver);
		}
	}

}
