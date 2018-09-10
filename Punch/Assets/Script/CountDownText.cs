using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownText : MonoBehaviour {

	public GameObject camera;
	public GameObject instructionText;

	private Color color;
	private int countdown = 3;

	void Start () {
		color = gameObject.GetComponent<TextMeshProUGUI> ().color;
	}

	void OnEnable(){
		iTween.ValueTo (gameObject, iTween.Hash ("from",1,"to",0,"onupdate","UpdateColor","onupdatetarget",gameObject,
			"oncomplete","CompleteColor","oncompletetarget",gameObject,"time",1));
	}

	void UpdateColor(float alfa){
		gameObject.GetComponent<TextMeshProUGUI> ().color = new Color (color.r,color.g,color.b,alfa);
	}

	void CompleteColor(){
		countdown--;
		if (countdown <= 0) {
			//ゲーム開始
			instructionText.SetActive(true);
			camera.GetComponent<GameManager> ().isClickable = true;
			gameObject.SetActive (false);
		}
		gameObject.GetComponent<TextMeshProUGUI> ().text = countdown.ToString();
		gameObject.GetComponent<TextMeshProUGUI> ().color = new Color (color.r,color.g,color.b,1);
		iTween.ValueTo (gameObject, iTween.Hash ("from",1,"to",0,"onupdate","UpdateColor","onupdatetarget",gameObject,
			"oncomplete","CompleteColor","oncompletetarget",gameObject));
	}
}
