using UnityEngine;
using System.Collections;

public abstract class StoreButton : MonoBehaviour {

	public GameObject defense;
	public int price;

	protected GameObject pointManager;
	protected GameObject temp;
	protected Vector3 position;

	// Use this for initialization
	void Start () {
		pointManager = GameObject.Find ("Score");
		temp = null;
	}
	
	// Update is called once per frame
	protected virtual void Update () {

	}
	void OnMouseOver(){
		if (pointManager.GetComponent<PointsManager> ().Score >= price
			&& Input.GetMouseButtonDown (0) && !temp) {
			temp = Instantiate(defense,
			                   position,
			                   Quaternion.identity) as GameObject;
			pointManager.GetComponent<PointsManager>().Score -= price;
		}
	}
}
