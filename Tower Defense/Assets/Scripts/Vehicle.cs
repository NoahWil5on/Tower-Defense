using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Vehicle : MonoBehaviour {

	GameObject scoreManager;
	protected GameObject current;
	protected int current_num;
	NodeManager nodeManager;
	
	public float distanceDetect;

	protected Vector3 position;
	protected Vector3 velocity;

	public int health;
	public int damage;
	public float maxSpeed;

	public int Health{ get { return health; } set { health = value; } }

	// Use this for initialization
	protected void Start () {

		//Makes starting node the first in the node list
		nodeManager = GameObject.Find ("NodeManager").GetComponent<NodeManager> ();
		scoreManager = GameObject.Find("Score");
		current = nodeManager.nodes[0];
		current_num = 0;

		velocity = Vector3.zero;
		position = transform.position;
	}
	
	// Update is called once per frame
	protected void Update () {
		if (health < 1) {
			GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>().Killed++;
			Destroy(gameObject);
		}
		CheckNext ();
		velocity = Seek (current.transform.position);
		position += velocity*Time.deltaTime;
		transform.position = position;
		transform.rotation = Quaternion.Euler (0, 0, Mathf.LerpAngle( 
			transform.rotation.eulerAngles.z,Mathf.Atan2 (velocity.y,velocity.x)*180/Mathf.PI,.1f));
	}
	protected Vector3 Seek(Vector3 target){
		return ((position-target)-velocity).normalized*maxSpeed*(-1);
	}
	protected void CheckNext(){
		if (DistSqr(position, current.transform.position) < distanceDetect * distanceDetect) {
			if (current_num == nodeManager.nodes.Count - 1) {
				scoreManager.GetComponent<ScoreManager>().Health -= damage;
				GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>().Killed++;
				Destroy(gameObject);
				return;
			}
			current_num++;
			current = nodeManager.nodes[current_num];
		}
	}
	protected float DistSqr(Vector3 FIRST_, Vector3 SECOND_){
		float x_;
		float y_;

		x_ = Mathf.Pow ((FIRST_.x - SECOND_.x), 2);
		y_ = Mathf.Pow((FIRST_.y - SECOND_.y), 2);

		return (x_ + y_);
	}
}
