using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState{
	idle, 
	playing, 
	levelEnd
}

public class GameController : MonoBehaviour {

	public static GameController s;

	public GameObject[] castles;


	public Text gtLevel;
	public Text gtScore;

	public Vector3 castlePos;

	private int level;
	private int maxLevel;
	private int shots;

	private GameObject castle;

	private GameState state;

	private string mysteriousString = "Slingshot";


	void Awake(){
		s = this;
	}

	void StartLevel(){
		//if there are old castles, destroy them
		//if there are old projectiles, destroy them
		//instantiate a new castle
		//shots = 0;
		//reset camera
		// create function switchView(string target)
	}

	public void switchView(string target){
		//switch over all possible views: slingshot, caslte, both
			//set poi of followcam on according value
			//
	}


	/*what is also needed:
	 * update gui texts
	 * check level end
	 * go to next level
	 */
}
