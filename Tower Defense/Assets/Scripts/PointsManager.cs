﻿using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour {

	int score;

	public int Score{ get { return score; } set { score = value; } }

	// Use this for initialization
	void Start () {
		score = 200;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<TextMesh> ().text = score.ToString ();
	}
}
