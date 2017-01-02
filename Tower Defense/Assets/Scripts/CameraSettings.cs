using UnityEngine;
using System.Collections;

public class CameraSettings : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera cam;
		cam = Camera.main;
		cam.aspect = 16 / 9;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
