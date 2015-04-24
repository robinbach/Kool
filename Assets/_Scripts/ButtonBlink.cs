using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBlink : MonoBehaviour {
	private Image img;
	public delegate void SimulatePressButton();
	public int playerId;
	public bool HoldKey = false;
	TutorialView TV;
	// Use this for initialization
	void Start () {
		img = GetComponent<Image> ();
		Blink (1000, 1f);
		TV = UnityEngine.Object.FindObjectOfType<TutorialView>();
	}

	public void StayRed() {
		img.color = Color.red;
	}

	public void StayWhite() {
		img.color = Color.white;
	}

	public void Blink(int times = 5, float interval = 0.5f) {
		TV = UnityEngine.Object.FindObjectOfType<TutorialView>();
		StartCoroutine (
			BlinkCo(times, interval));
	}
	// helper func
	private IEnumerator BlinkCo(int times, float interval = 1.0f) {
		for (int i = 0; i < times; i++) {	
			if (!TutorialView.StopBlinking[playerId]){
				if (TV.holdButton){
					StayRed();
				} else {
					StartCoroutine (blinkHelper());
				}
			}
			else {
				StayWhite();
			}
			yield return new WaitForSeconds(interval);
		}
	}

	private IEnumerator blinkHelper(float interval = 0.2f) {
		StayRed ();
		yield return new WaitForSeconds (interval);
		StayWhite ();
	}
}


