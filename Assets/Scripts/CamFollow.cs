using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public static CamFollow s; //singleton instance of this class  can be accessed by other scripts by: FollowCam.s.poi;  but only if you have only one instance!!!!!

	//camera following script needs a point of interest, which it can follow
	public  GameObject poi; //don't make it public since it might change during runtime(e.g. next projectile)-->change via script

	public GameObject GO_left; //needed to calculate the middle--> to be able to see everything
	public GameObject GO_right;

	private float CamZ;
	private float minCamY;
	private float leftCam;
	private Vector2 minXY;

	private GameObject slingshot;
	private GameObject goal;
	public static GameObject empty;
	public static GameObject lastPoi;

	Vector3 destination;

	public float speed;

	private TrailRenderer trailRen;

	//awake is always called, even when the attached object is set unactive. start starts as soon as it's set active
	void Awake(){
		s = this;
		CamZ = transform.position.z;
		minCamY = transform.position.y;
		leftCam = transform.position.x;



		slingshot = GameObject.FindWithTag ("Slingshot");
		empty = GameObject.FindWithTag ("Empty");
		goal = GameObject.FindWithTag ("Goal");

		Debug.Log (slingshot);

		if (GO_left == null) {
			setEmptyToMiddle ();
		} else {
			setEmptyToMiddle(GO_left, GO_right);
		}
		lastPoi = poi;

	}

	void FixedUpdate(){
		//check if poi is empty--- if there is no point of interes yet (in our case it would be the projectile)

		Debug.Log ("poi:" + poi);

		if (poi == null) {
//			trailRen.enabled = false;

			//set the destination to the zero vector
			//destination = Vector3.zero;
			destination = lastPoi.transform.position;

			//Debug.Log ("vector Zero: " + Vector3.zero);
			//Debug.Log ("position: " + transform.position);
		} else {
			//Debug.Log ("poi != null");
			//get its position
			destination = poi.transform.position;


			//check if the poi is a projectile
			if (poi.tag == "Projectile") {
				//Debug.Log ("poi is a projectile");
				/*if (poi.GetComponent<Rigidbody> () == null) {
					Debug.Log ("poi has no rigidbody");
					return;
				}*/
				// check if its resting
				if (poi.GetComponent<Rigidbody> ().IsSleeping () /*&& Input.GetMouseButtonUp(0)*/) {
					poi = null;

					//Debug.Log ("poi is set null");
					return;
				}
			}
		}

			destination.z = CamZ;

		//	destination.x = Mathf.Max (minXY.x, destination.x); //prevents camera of jumping under the bottom----- not really?? :( 
		//	destination.y = Mathf.Max (minXY.y, destination.y);


		transform.position = Vector3.Lerp (transform.position, destination, speed * Time.deltaTime);

		this.GetComponent<Camera> ().orthographicSize = 5 + destination.y;
		if (poi == empty) {
			if(GO_left != null){
				this.GetComponent<Camera> ().orthographicSize = getSize (GO_left ,GO_right)  + 5;
			}else{
			this.GetComponent<Camera> ().orthographicSize = getSize ()  + 2;
			}
		}
		

	}

	public void setPoi(GameObject target){
		poi = target;
		lastPoi = target;
		Debug.Log ("sets poi");
	}


	private void setEmptyToMiddle(GameObject A, GameObject B){
		Vector3 a = A.transform.position;
		Vector3 b = B.transform.position;
		Vector3 middle = (a+b)/2;
		empty.transform.position = middle;
		//Instantiate (goal, middle, new Quaternion(0, 0, 0, 0));
	}

	private void setEmptyToMiddle(){
		Vector3 s = slingshot.transform.position;
		Vector3 g = goal.transform.position;
		Vector3 middle = (s+g)/2;
		empty.transform.position = middle;
		//Instantiate (goal, middle, new Quaternion(0, 0, 0, 0));
	}

	private float getSize(){
		return ((Vector3.Distance (slingshot.transform.position, goal.transform.position)) / this.GetComponent <Camera> ().aspect) / 2;
	}
	private float getSize(GameObject A, GameObject B){
		return ((Vector3.Distance (A.transform.position, B.transform.position)) / this.GetComponent <Camera> ().aspect) / 2;

	}

}
