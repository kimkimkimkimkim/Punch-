using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class FighterAnimationDemoFREE : MonoBehaviour {
	
	public Animator animator;
	public GameObject wall;
	public GameObject camera;
	public GameObject scoreText;
	public GameObject restartButton;
	public GameObject audioDestroy;
	public GameObject audioEnergy;

	private Transform defaultCamTransform;
	private Vector3 resetPos;
	private Vector3 firstPos;
	private Quaternion resetRot;
	private GameObject cam;
	private GameObject fighter;
	private Rigidbody rigidbody;
	private Transform wTransform;
	private int clickCount;

	void Start()
	{
		cam = GameObject.FindWithTag("MainCamera");
		defaultCamTransform = cam.transform;
		resetPos = defaultCamTransform.position;
		resetRot = defaultCamTransform.rotation;
		fighter = GameObject.FindWithTag("Player");
		fighter.transform.position = new Vector3(0,0,0);
		firstPos = camera.transform.position;
		wTransform = wall.transform;
	}

	void OnGUI () 
	{
		if (GUI.RepeatButton (new Rect (815, 535, 100, 30), "Reset Scene")) 
		{
			defaultCamTransform.position = resetPos;
			defaultCamTransform.rotation = resetRot;
			fighter.transform.position = new Vector3(0,0,0);
			animator.Play("Idle");
		}

		/*
		if (GUI.RepeatButton (new Rect (25, 20, 100, 30), "Walk Forward")) 
		{
			animator.SetBool("Walk Forward", true);
		}
		else
		{
			animator.SetBool("Walk Forward", false);
		}

		if (GUI.RepeatButton (new Rect (25, 50, 100, 30), "Walk Backward")) 
		{
			animator.SetBool("Walk Backward", true);
		}
		else
		{
			animator.SetBool("Walk Backward", false);
		}
		*/

		/*
		if (GUI.Button (new Rect (25, 20, 100, 30), "Punch")) 
		{
			animator.SetTrigger("PunchTrigger");


			//DelayMethodを3.5秒後に呼び出す
			Invoke("DestroyMethod", 1.0f);
		
		}
		*/
	}

	public void Punch(int count){
		animator.SetTrigger("PunchTrigger");

		clickCount = count;

		//DelayMethodを3.5秒後に呼び出す
		Invoke("DestroyMethod", 1.0f);
		Invoke ("MoveCamera", 2.0f);
	}

	void MoveCamera(){


		Vector3 targetPos = new Vector3 (firstPos.x,firstPos.y,(float)clickCount*0.5f + 0.25f);

		iTween.ValueTo (camera, iTween.Hash ("from",firstPos,"to",targetPos,"onupdate","UpdateCameraPos",
			"onupdatetarget",gameObject,"oncomplete","CompleteCameraMove","oncompletetarget",gameObject));

	}

	void UpdateCameraPos(Vector3 pos){
		camera.transform.position = pos;
	}

	void CompleteCameraMove(){
		scoreText.SetActive (true);
		restartButton.SetActive (true);

		scoreText.GetComponent<Text>().text = "Score : " + (clickCount * 0.5f) + "m";

	}

	void DestroyMethod()
	{
		audioDestroy.GetComponent<AudioSource> ().Play();
		audioEnergy.GetComponent<AudioSource> ().Stop();

		for (int i = 0; i < wTransform.childCount; i++) {

			if (i <= clickCount) {
				for (int j = 0; j < wall.transform.GetChild (i).childCount; j++) {
					Vector3 dir;
					dir = new Vector3 (
						Random.Range (-1f, 1f),
						Random.Range (-1f, 1f),
						Random.Range (-1f, 1f));
					rigidbody = wall.transform.GetChild (i).GetChild (j).gameObject.GetComponent<Rigidbody> ();
					rigidbody.AddForce (dir * 20, ForceMode.Impulse);
					rigidbody.velocity += (dir * 20) / rigidbody.mass;
				}
			} else {
				for (int j = 0; j < wall.transform.GetChild (i).childCount; j++) {
					GameObject obj;
					obj = wall.transform.GetChild (i).GetChild (j).gameObject;
					obj.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition;
				}

			}

		}
	}
}