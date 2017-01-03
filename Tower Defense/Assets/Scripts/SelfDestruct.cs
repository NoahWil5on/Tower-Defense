using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	public bool ticks;
	public float timer;
	public float frames;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		frames--;
		timer -= Time.deltaTime;
		if (ticks) {
			if (timer <= 0) {
				Destroy (gameObject);
			}
		} else if (frames <= 0) {
			Destroy(gameObject);
		}
	}
}
