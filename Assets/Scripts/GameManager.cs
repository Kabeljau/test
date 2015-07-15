using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class GameManager : MonoBehaviour {

	//public static int score;
	public int minScore;

	public delegate void scoreChanged();
	public static event scoreChanged OnScoreChange;

	private static int Score;
	public static int score{
		get{return Score;}
		set{
			Score = value;
			if(OnScoreChange != null){
				OnScoreChange();
			}		
		}
	}

	public static Text scoreText;

	public static bool scoreReached;

	private Button final_projectile;






	void Awake(){
		scoreText = GameObject.Find ("scoreNumber").GetComponent<Text> ();
		score = 0;
		scoreText.text = "" + score;
		scoreReached = false;
		OnScoreChange += checkScore;
		OnScoreChange += updateScore;

		final_projectile = GameObject.FindWithTag ("finalProjectile").GetComponent<Button>();
	}

	public void updateScore(){
		scoreText.text = "" + score;
	}

	private void checkScore(){
		if (score >= minScore) {
			scoreReached = true;
		}
	}




	public void quitGame(){
		Application.Quit ();
	}

}
