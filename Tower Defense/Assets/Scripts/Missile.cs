using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

	Vector3 position;
	Vector3 velocity;
	bool destruct;
	float timer;

	public float maxSpeed;
	public float distanceDetect;

	GameObject target;
	GameObject parent;

	public GameObject Target{ get { return target; } set { target = value; } }
	public GameObject Parent{ get { return parent; } set { parent = value; } }

	// Use this for initialization
	void Start () {
		destruct = false;
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!target)
			destruct = true;
		if (destruct) {
			float x_ = Mathf.Cos(transform.rotation.eulerAngles.z*Mathf.Deg2Rad);
			float y_ = Mathf.Sin(transform.rotation.eulerAngles.z*Mathf.Deg2Rad);
			velocity = new Vector3(x_,y_,0)*maxSpeed;
			timer += Time.deltaTime;
			position += velocity *Time.deltaTime;
			transform.position = position;
			if(timer > 3){
				Destroy(gameObject);
			}
			return;
		}
		if (target) {
			velocity = Seek (target.transform.position);
			position += velocity * Time.deltaTime;
		} else {
			/*target = parent.GetComponent<Turret>().Current;
			if(!target)*/
				destruct = true;
			//return;
		}
		transform.rotation = Quaternion.Euler (0, 0, Mathf.LerpAngle( 
        	transform.rotation.eulerAngles.z,Mathf.Atan2 (velocity.y,velocity.x)*180/Mathf.PI,.1f));
		transform.position = position;
		CheckDestroy ();
	}
	void CheckDestroy(){
		if (!target)
			return;
		if ((target.transform.position - transform.position).sqrMagnitude < distanceDetect * distanceDetect) {
			target.GetComponent<Vehicle>().Health--;
			Destroy(gameObject);
		}
	}
	Vector3 Seek(Vector3 target){
		return ((position-target)-velocity).normalized*maxSpeed*(-1);
	}
}
