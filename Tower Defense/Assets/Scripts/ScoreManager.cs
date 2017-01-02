using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int health;

	public int Health{ get { return health; } set { health = value; } }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 0) {
			health = 0;
		}
		GetComponent<TextMesh> ().text = health.ToString ();
	}
}
