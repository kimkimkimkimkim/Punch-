using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {

	public GameObject audioClick;

	public void OnClick(){
		//audioClick.GetComponent<AudioSource> ().Play ();
		Application.LoadLevel("GameScene"); // シーンの名前かインデックスを指定
	}
}
