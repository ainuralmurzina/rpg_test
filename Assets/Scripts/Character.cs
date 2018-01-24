using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	[SerializeField]
	protected float speed;
	protected Vector2 direction;

	private Animator animator;

	void Start(){
		animator = GetComponent<Animator> ();
	}

	protected virtual void FixedUpdate(){
		Move ();

		if(direction.x != 0 || direction.y != 0)
			AnimateMovement ();
		else
			animator.SetLayerWeight (1, 0f);
	}

	protected void Move(){
		transform.Translate (direction * speed * Time.deltaTime);
	}

	protected void AnimateMovement(){

		animator.SetLayerWeight (1, 1f);

		animator.SetFloat ("x", direction.x);
		animator.SetFloat ("y", direction.y);
	}
}
