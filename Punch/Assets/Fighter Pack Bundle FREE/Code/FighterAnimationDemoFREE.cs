using UnityEngine;
using System.Collections;

public class FighterAnimationDemoFREE : MonoBehaviour {
	
	public Animator animator;
	public GameObject wall;

	private Transform defaultCamTransform;
	private Vector3 resetPos;
	private Quaternion resetRot;
	private GameObject cam;
	private GameObject fighter;
	private Rigidbody rigidbody;
	private Transform wTransform;

	void Start()
	{
		cam = GameObject.FindWithTag("MainCamera");
		defaultCamTransform = cam.transform;
		resetPos = defaultCamTransform.position;
		resetRot = defaultCamTransform.rotation;
		fighter = GameObject.FindWithTag("Player");
		fighter.transform.position = new Vector3(0,0,0);
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

		if (GUI.Button (new Rect (25, 20, 100, 30), "Punch")) 
		{
			animator.SetTrigger("PunchTrigger");


			//DelayMethodを3.5秒後に呼び出す
			Invoke("DestroyMethod", 1.0f);
		
		}
	}

	void DestroyMethod()
	{
		for (int i = 0; i < wTransform.childCount; i++) {

			Vector3 dir;
			dir = new Vector3 (
				Random.Range (-1f, 1f),
				Random.Range (-1f, 1f),
				Random.Range (-1f, 1f));
			rigidbody = wall.transform.GetChild (i).gameObject.GetComponent<Rigidbody> ();
			rigidbody.AddForce (dir * 20, ForceMode.Impulse);
			rigidbody.velocity += (dir * 20) / rigidbody.mass;

		}
	}
}