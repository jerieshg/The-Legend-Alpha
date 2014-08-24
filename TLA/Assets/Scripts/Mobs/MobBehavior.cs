using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MobBehavior))]
[RequireComponent (typeof(MobStats))]
[RequireComponent (typeof(MobController))]
[RequireComponent (typeof(MobCollisionController))]

public class MobBehavior : MonoBehaviour {

	private MobStats mobStats;
	private MobCollisionController mobCollision;
	//Behavior Action Variables
	private RaycastHit2D View;
	private RaycastHit2D attackRange;
	public LayerMask playerMask;
	private Vector3 target;
	//LocalScale
	private float x;
	//Mob Selectors
	public bool Hostile;
	public bool Neutral;
	public bool Passive;

	void Start()
	{
		mobStats = GetComponent<MobStats>();
		mobCollision = GetComponent<MobCollisionController>();
		//Setting Local Variables
		x = transform.localScale.x;
	}

	void FixedUpdate()
	{
		//Selected Behaviours activated
		MobBehaviorSelector();
	}

	void MobBehaviorSelector()
	{
		if(Hostile)
		{
			Detect();
		}
		else if(Neutral)
		{

		}
		else
		{

		}
	}

	void Detect()
	{

		View = Physics2D.Linecast(transform.position,new Vector3(transform.position.x + mobStats.viewDistance * x, transform.position.y, transform.position.z),playerMask);

		if(View)
		{
			Debug.DrawLine(transform.position,new Vector3(transform.position.x + mobStats.viewDistance * x, transform.position.y, transform.position.z),Color.red);
			Follow(View.transform.position);
		}
		else
		{
			Debug.DrawLine(transform.position,new Vector3(transform.position.x + mobStats.viewDistance * x, transform.position.y, transform.position.z),Color.green);
		}
	}

	void Follow(Vector3 target)
	{
		transform.position = Vector3.MoveTowards( transform.position, target, Time.deltaTime * mobStats.speed);
	}




}
