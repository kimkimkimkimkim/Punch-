using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartText : MonoBehaviour {

	private Color color;

	// Use this for initialization
	void Start () {
		color = gameObject.GetComponent<TextMeshProUGUI> ().color;

		iTween.ValueTo (gameObject, iTween.Hash ("from",1,"to",0,"onupdate","UpdateColor","onupdatetarget",gameObject,
			"oncomplete","CompleteColor","oncompletetarget",gameObject));
	}

	void UpdateColor(float alfa){
		gameObject.GetComponent<TextMeshProUGUI> ().color = new Color (color.r,color.g,color.b,alfa);
	}

	void CompleteColor(){
		gameObject.GetComponent<TextMeshProUGUI> ().color = new Color (color.r,color.g,color.b,1);
		iTween.ValueTo (gameObject, iTween.Hash ("from",1,"to",0,"onupdate","UpdateColor","onupdatetarget",gameObject,
			"oncomplete","CompleteColor","oncompletetarget",gameObject));
	}
}
