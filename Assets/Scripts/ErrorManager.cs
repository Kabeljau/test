using UnityEngine;
using System.Collections;

public class ErrorManager : MonoBehaviour {

	public Transform[] errorPoints;

	public GameObject obj_spawn;
	public GameObject obj_twitch;
	public GameObject obj_unicorn;

	private GameObject cam;

	bool runs_1;
	bool runs_2;
	bool runs_3;
	bool runs_4;
	bool runs_5;

	void Start(){
		runs_1 = false;
		runs_2 = false;
		runs_3 = false;
		runs_4 = false;
		runs_5 = false;
		GameManager.OnScoreChange += activateError;
		cam = GameObject.FindWithTag ("MainCamera");
	}

	void activateError(){

		if(GameManager.score > 20 && !runs_1){  //how to tell him to call it only once??
		
			runs_1 = true;
		}else if(GameManager.score > 20 && !runs_2){
			StartCoroutine(twitch (errorPoints[0]));
			runs_2 = true;
		}else if(GameManager.score > 20 && !runs_3){
			pfudor (errorPoints[1]);
			runs_3 = true;
		}else if(GameManager.score > 20 && !runs_4){
			StartCoroutine(spawn (errorPoints[2]));
			runs_4 = true;
		}else if(GameManager.score > 100 &&!runs_5){
				flipCamera();
			runs_5 = true;
		}
	}

	private IEnumerator twitch(Transform pos){
		GameObject obj = Instantiate (obj_twitch, pos.position, pos.rotation) as GameObject;
		Debug.Log ("twitch is running");
		float counter = 0;
		float time = Random.Range (0, 1.2f);
		while (true) {
			obj.transform.position += new Vector3 (0.2f, 0.4f, 0);
			counter += 0.03f;
			if(counter > time){
				obj.transform.position = pos.position;
				counter = 0;
				time = Random.Range (0, 1.2f);
			}
			yield return null;
		}


	}



	private IEnumerator spawn(Transform pos){
		Debug.Log ("spawn is running");
		while (true) {
			Instantiate (obj_spawn, pos.position, pos.rotation);
			yield return new WaitForSeconds(0.05f);
		}
	}

	private void flipCamera(){
		Debug.Log ("flips Camera");
		cam.transform.Rotate (0, 0, -200);

	}

	private void pfudor(Transform pos){
		Debug.Log ("pfudor is running");
		Instantiate (obj_unicorn, pos.position, pos.rotation);
	}
}
