using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	protected override void FixedUpdate(){
		GetInput ();	
		base.FixedUpdate ();
	}

	void GetInput(){
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		direction = new Vector2 (x, y);
	}
}
