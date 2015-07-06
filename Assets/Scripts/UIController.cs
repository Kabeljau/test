using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	private Text buttonText;

	private static bool groupIsVisible;

	void Awake(){
		buttonText = GetComponentInChildren<Text> ();
		buttonText.enabled = false;
	}

	public void showText(){
		buttonText.enabled = true;
	}

	public void hideText(){
		buttonText.enabled = false;
	}

	public void showHideGroup(CanvasGroup group ){
		if (!groupIsVisible) {
				group.alpha = 1;
				group.interactable = true;
				group.blocksRaycasts = true;
				groupIsVisible = true;
		} else {
				group.alpha = 0;
				group.interactable = false;
				group.blocksRaycasts = false;
				groupIsVisible = false;
		}
	}


}
