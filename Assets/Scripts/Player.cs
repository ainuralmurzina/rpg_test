using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	[SerializeField] private Stat health;
	[SerializeField] private Stat mana;

	protected override void Start(){
		base.Start ();
		health.Initialize ();
		mana.Initialize ();
	}

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
