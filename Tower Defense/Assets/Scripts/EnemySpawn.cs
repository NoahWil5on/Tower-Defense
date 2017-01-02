using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject basicEnemy;

	private float timer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 1) {
			timer = 0;
			Instantiate(basicEnemy, transform.position,Quaternion.identity);
		}
	}
}
