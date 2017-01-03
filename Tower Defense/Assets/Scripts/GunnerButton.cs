using UnityEngine;
using System.Collections;

public class GunnerButton : StoreButton {
	
	// Update is called once per frame
	protected override void Update () {
		position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		position = new Vector3 (position.x, position.y, .5f);
		if (temp) {
			temp.GetComponent<MachineGunner>().enabled = false;
			temp.transform.position = position;
			if(Input.GetMouseButtonUp(0)){
				temp.GetComponent<MachineGunner>().enabled = true;
				temp = null;
			}
		}
	}
}
