using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject basicEnemy;
	public GameObject text;

	private float timer;
	private float levelTimer;

	int levelNum;
	int enemyCount;
	int spawned;
	int killed;
	public int difficulty;

	public int Killed{ get { return killed; } set { killed = value; } }

	// Use this for initialization
	void Start () {
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
			if (timer > 1) {
				spawned++;
				timer = 0;
				Instantiate (basicEnemy, transform.position, Quaternion.identity);
			}
		}
	}
}
