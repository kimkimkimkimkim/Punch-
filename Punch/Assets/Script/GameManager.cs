using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject bgm;
	public GameObject click;
	public GameObject audioCountDown;
	public GameObject audioEnergy;
	public GameObject man;
	public GameObject startText;
	public GameObject countdownText;
	public GameObject instructionText;
	public GameObject[] magicRing = new GameObject[6];
	public bool isClickable = false;


	private bool isStart = false;
	private bool didPunch = false;
	private bool flag = true;
	private int clickCount = 0;
	private float timer = 0;
	private float timelimit = 5.0f;

	private int phase1 = 1;
	private int phase2 = 12;
	private int phase3 = 24;
	private int phase4 = 36;
	private int phase5 = 48;
	private int phase6 = 60;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 左クリックされた瞬間にif文の中を実行
		if(Input.GetMouseButtonDown(0)){
			if (!isStart) {

				bgm.GetComponent<AudioSource> ().Stop();
				audioCountDown.GetComponent<AudioSource> ().Play();

				//最初
				// 処理
				startText.SetActive (false);

				//カウントダウン開始
				countdownText.SetActive (true);

				isStart = true;
			} else {
				//ゲーム開始
				if (isClickable) {
					//ゲージを貯める
					clickCount++;

				}
			}
		}

		if (isClickable) {
			timer += Time.deltaTime;
		}

		if (timer >= timelimit) {
			isClickable = false;
			instructionText.SetActive (false);

			if (!didPunch) {
				//パンチ
				man.GetComponent<FighterAnimationDemoFREE> ().Punch (clickCount);
				didPunch = true;
			}
		}

		//魔法陣パワーアップ
		if (clickCount >= phase1 && clickCount < phase2) {
			if (flag) {
				audioEnergy.GetComponent<AudioSource> ().Play ();
				flag = false;
			}
			ShowMagicRing (1);
		}else if (clickCount >= phase2 && clickCount < phase3) {
			if (!flag) {
				audioEnergy.GetComponent<AudioSource> ().Play ();
				flag = true;
			}
			ShowMagicRing (2);
		}else if (clickCount >= phase3 && clickCount < phase4) {
			if (flag) {
				audioEnergy.GetComponent<AudioSource> ().Play ();
				flag = false;
			}
			ShowMagicRing (3);
		}else if (clickCount >= phase4 && clickCount < phase5) {
			if (!flag) {
				audioEnergy.GetComponent<AudioSource> ().Play ();
				flag = true;
			}
			ShowMagicRing (4);
		}else if (clickCount >= phase5 && clickCount < phase6) {
			if (flag) {
				audioEnergy.GetComponent<AudioSource> ().Play ();
				flag = false;
			}
			ShowMagicRing (5);
		}else if (clickCount >= phase6) {
			if (!flag) {
				audioEnergy.GetComponent<AudioSource> ().Play ();
				flag = true;
			}
			ShowMagicRing (6);
		}
	}

	/// <summary>
	/// num番目のmagic_ringを表示(1<=num<=6) 
	/// </summary>
	/// <param name="num">Number.</param>
	void ShowMagicRing(int num){
		for(int i=0;i<6;i++){
			if (i+1 != num) {
				magicRing [i].SetActive (false);
			}
		}
		magicRing [num - 1].SetActive (true);
	}
}
