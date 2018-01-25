﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	[SerializeField]
	protected float speed;
	protected Vector2 direction;

	private Rigidbody2D rigidbody;
	private Animator animator;

	protected bool IsMoving{
		get { return direction.x != 0 || direction.y != 0; }
	}

	protected virtual void Start(){
		animator = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	protected virtual void FixedUpdate(){
		Move ();
		HandleLayers ();
	}

	protected void Move(){
		rigidbody.velocity = direction.normalized * speed;
	}

	void HandleLayers (){
		if (IsMoving) {
			ActivateLayer("WalkLayer");
			animator.SetFloat ("x", direction.x);
			animator.SetFloat ("y", direction.y);
		}
		else
			ActivateLayer("IdleLayer");
	}

	void ActivateLayer(string layerName){
		for (int i = 0; i < animator.layerCount; i++)
			animator.SetLayerWeight (i, 0f);
		animator.SetLayerWeight (animator.GetLayerIndex(layerName), 1f);
	}

}
