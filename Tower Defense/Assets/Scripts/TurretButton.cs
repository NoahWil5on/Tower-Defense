using UnityEngine;
using System.Collections;

public class TurretButton : StoreButton {

	// Update is called once per frame
	protected override void Update () {
		position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		position = new Vector3 (position.x, position.y, .5f);
		if (temp) {
			temp.GetComponent<Turret>().enabled = false;
			temp.transform.position = position;
			if(Input.GetMouseButtonUp(0)){
				temp.GetComponent<Turret>().enabled = true;
				temp = null;
			}
		}
	}
}
