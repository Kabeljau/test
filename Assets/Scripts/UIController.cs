using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {


	private static bool groupIsVisible;



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

	public void showImage(Image playImage){
		playImage.enabled = true;
	}

	public void changeScene(string scene){
		Application.LoadLevel (scene);
	}


}
