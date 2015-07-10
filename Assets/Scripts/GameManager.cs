using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static int score;
	public int minScore;
	

	public static Text scoreText;

	private Button final_projectile;




	void Awake(){
		scoreText = GameObject.Find ("scoreNumber").GetComponent<Text> ();
		score = 0;
		scoreText.text = "" + score;

		final_projectile = GameObject.FindWithTag ("finalProjectile").GetComponent<Button>();
		final_projectile.interactable = false;
	}

	public static void updateScore(){
		scoreText.text = "" + score;
	}

	private void checkScore(){
		if (score >= minScore) {
			final_projectile.interactable = true;
		}
	}

	void Update(){
		checkScore ();
	}

	public void quitGame(){
		Application.Quit ();
	}

}
