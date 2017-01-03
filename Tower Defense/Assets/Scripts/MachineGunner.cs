using UnityEngine;
using System.Collections;

public class MachineGunner : MonoBehaviour {
	
	private float timer;
	public float range;
	public float ROF;
	private Vector3 missileVelocity;
	
	GameObject closest;
	public GameObject missile;
	GameObject tempMissile;
	GameObject[] enemies;
	
	public GameObject Current{ get { return closest; } }
	
	// Use this for initialization
	void Start () {
		ROF = 1 / ROF;
		range = range * range;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//Only calls point if there are objects on the screen
		if (closest && RemainInRange()) {
			Point (closest);
			Fire ();
		} else {
			Closest();
		}
	}
	/// <summary>
	/// Fires a missile
	/// </summary>
	void Fire(){

		if (timer > ROF) {
			closest.GetComponent<Vehicle>().Health --;
			missileVelocity = closest.transform.position - transform.position;
			
			float angle = Mathf.Atan2 (missileVelocity.y, missileVelocity.x);
			float x = Mathf.Cos (angle) * 1.2f;
			float y = Mathf.Sin (angle) * 1.2f;
			
			tempMissile = Instantiate (missile, 
			                           new Vector3 (transform.position.x + x, transform.position.y + y, transform.position.z), 
			                           Quaternion.identity) as GameObject;
			
			angle *= 180 / Mathf.PI;
			tempMissile.transform.rotation = Quaternion.Euler (0, 0, angle);
			
			timer = 0;
		} 
	}
	/// <summary>
	/// Finds the closest enemy to the turret
	/// </summary>
	void Closest(){
		float recordDistance = float.MaxValue;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies.Length == 0) {
			closest = null;
			return;
		}
		foreach (GameObject e in enemies) {
			float tempDistance = (e.transform.position-transform.position).sqrMagnitude;
			if(tempDistance < recordDistance){
				recordDistance = tempDistance;
				if(recordDistance < range){
					closest = e;
				}
			}
		}
	}
	bool RemainInRange(){
		if((closest.transform.position - transform.position).sqrMagnitude < range)
		{return true;}
		else
		{return false;}
	}
	/// <summary>
	/// Rotates Turret towards the obj parameter
	/// </summary>
	/// <param name="obj">Object.</param>
	void Point(GameObject obj){
		/*transform.rotation = Quaternion.Euler (0,0,
			Mathf.LerpAngle(transform.rotation.eulerAngles.z,Mathf.Atan2((obj.transform.position.y-transform.position.y),
		            (obj.transform.position.x-transform.position.x))*Mathf.Rad2Deg,.1f));*/
		transform.rotation = Quaternion.Euler (0,0,
		                                       Mathf.Atan2((obj.transform.position.y-transform.position.y),
		            (obj.transform.position.x-transform.position.x))*Mathf.Rad2Deg);
	}
}
