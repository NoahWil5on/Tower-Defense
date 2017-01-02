using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

	public List<GameObject> enemies;
	GameObject enemy;
	public GameObject text;

	private float timer;
	private float levelTimer;

	int levelNum;
	int enemyCount;
	int spawned;
	int killed;
	public float spawnRate;
	public int difficulty;

	public int Killed{ get { return killed; } set { killed = value; } }

	// Use this for initialization
	void Start () {
		spawnRate = 1 / spawnRate;
		levelNum = 1;
		enemyCount = levelNum * difficulty;
	}
	
	// Update is called once per frame
	void Update () {

		if (enemyCount == killed) {
			levelNum++;
			levelTimer = 0;
			enemyCount = 0;
		}
		if (levelTimer > 3) {
			Spawn ();
			text.GetComponent<TextMesh> ().text = "";
		} else {
			NewLevel();
			text.GetComponent<TextMesh> ().text = "Level: " + levelNum.ToString ();
		}

	}
	void NewLevel(){
		levelTimer += Time.deltaTime;
		if (levelTimer > 3) {
			spawned = 0;
			killed = 0;
			enemyCount = levelNum*difficulty;
		}
	}
	void Spawn(){
		timer += Time.deltaTime;
		if (spawned < enemyCount) {
			if (timer > spawnRate) {
				spawned++;
				timer = 0;
				if(spawned > enemyCount*4/5 && enemyCount > 15){
					enemy = enemies[3];
				}
				else if(spawned > enemyCount*2/3 && enemyCount > 10){
					enemy = enemies[2];
				}
				else if(spawned > enemyCount/2 && enemyCount > 5){
					enemy = enemies[1];
				}
				else{
					enemy = enemies[0];
				}
				Instantiate (enemy, transform.position, Quaternion.identity);
			}
		}
	}
}
