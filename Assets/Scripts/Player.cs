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

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!isAttacking && !IsMoving) {
				attackRoutine = StartCoroutine (Attack ());
			}
		}
	}

	IEnumerator Attack(){
		isAttacking = true;
		animator.SetBool ("attack", isAttacking);
		yield return new WaitForSeconds (1f);
		StopAttack ();
	}
}
