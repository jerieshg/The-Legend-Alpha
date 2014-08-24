using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {

	private MobStats mobStats;

	void Start()
	{
		mobStats = GetComponent<MobStats>();
	}

	void FixedUpdate()
	{
		CheckIfAlive();
	}
	
	public void takeDamage(float damage)
	{
		//Debug.Log("Damage "+ damage);
		mobStats.hitPoints -= mobStats.hitPoints - blockHp(damage);
	}
	
	void CheckIfAlive()
	{
		if(mobStats.hitPoints <= 0)
		{
			Die ();
		}
	}
	
	float blockHp(float damage)
	{
		float DamageCalc = damage - mobStats.defence;
		
		if(DamageCalc > 1)
		{
			Debug.Log (DamageCalc);
			return DamageCalc;
		}
		else
		{
			Debug.Log (DamageCalc);
			return 0.0f;
		}
	}
	
	void Die()
	{
		Debug.Log("Enemy has been slain");
		Destroy(gameObject);
	}
}
