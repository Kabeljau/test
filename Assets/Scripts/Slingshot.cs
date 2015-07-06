﻿using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	//Inspector fields
	public GameObject defaultProjectilePrefab;

	public float velocityMult;

	private bool shotProjectile;

	private GameObject oldProjectile;
	//internal fields
	private static GameObject prefabProjectile;

	private GameObject launchPoint;
	private bool aimingMode;

	private Vector3 launchPos;
	private GameObject projectile;

	void Awake()
	{
		Transform launchPointTrans = transform.Find ("Launchpoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive (false);
		launchPos = launchPoint.transform.position;

		prefabProjectile = defaultProjectilePrefab;
	}


	void OnMouseEnter(){  
	
		launchPoint.SetActive(true);
		//Debug.Log ("onmouseenter");
	}

	public void selectProjectile(GameObject prefab){
		prefabProjectile = prefab;
	}

	void OnMouseExit(){
		if (!aimingMode) {
			launchPoint.SetActive (false);
		}
		//Debug.Log ("onmouseExit");
	}

	void OnMouseDown(){ 
		if (prefabProjectile == null) {
			Debug.Log ("no projectile assigned!");
			return;
		}
		//player can aim
		aimingMode = true;

		//instantiate a projectile
		projectile = Instantiate (prefabProjectile) as GameObject; //would be just an Object otherwise

		if (oldProjectile == null) {
			oldProjectile = projectile;
		} else {
			Destroy (oldProjectile);
			oldProjectile= projectile;
		}


		//position of projectile at launchpoint
		projectile.transform.position = launchPos;

		//turn off physics while player is aiming
		projectile.GetComponent<Rigidbody> ().isKinematic = true;


	}

	void Update(){
		//check aiming mode
		if (!aimingMode)
			return;

		//get the mouse position in 3d space
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z; //always on the same level of camera
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D); 

		//calculate vector between mouse position and launch position
		Vector3 mouseDelta = mousePos3D - launchPos;


		//constrain the delta to radius of the shere collider
		float maxMagnitude = this.GetComponent<SphereCollider> ().radius;

		mouseDelta = Vector3.ClampMagnitude (mouseDelta, maxMagnitude);

	
		//set the projectile to the new position 
		projectile.transform.position = launchPos + mouseDelta;



		//check mouse button released  //fire it off!! Baaaaammmmmm!!!
		if (Input.GetMouseButtonUp(0)) {
			aimingMode = false;
			launchPoint.SetActive(false);
			projectile.GetComponent<Rigidbody> ().isKinematic = false;
			projectile.GetComponent<Rigidbody> ().velocity = -mouseDelta * velocityMult;
			CamFollow.s.poi = projectile;
			shotProjectile = true;
		}





	}









}
