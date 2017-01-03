using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

	bool visible;

	// Use this for initialization
	void Start () {
		visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		visible = GameObject.Find ("EnemySpawner").GetComponent<EnemySpawn> ().Between;
		if (visible) {
			gameObject.GetComponent<Renderer> ().enabled = true;
		} else {
			gameObject.GetComponent<Renderer> ().enabled = false;
		}
		//print (GameObject.Find ("EnemySpawner").GetComponent<EnemySpawn> ().Between);
	}
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0) && visible) {
			GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>().Between = false;
		}
	}
}
