using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public static CamFollow s; //singleton instance of this class  can be accessed by other scripts by: FollowCam.s.poi;  but only if you have only one instance!!!!!

	//camera following script needs a point of interest, which it can follow
	public GameObject poi; //don't make it public since it might change during runtime(e.g. next projectile)-->change via script

	private float CamZ;

	//awake is always called, even when the attached object is set unactive. start starts as soon as it's set active
	void Awake(){
		s = this;
		CamZ = transform.position.z;

	}

	void Update(){
		//check if poi is empty--- if there is no point of interes yet (in our case it would be the projectile)
		if (poi == null) {return;}

		Vector3 destination = poi.transform.position;
		destination.z = CamZ;

		transform.position = destination;
	}

}
