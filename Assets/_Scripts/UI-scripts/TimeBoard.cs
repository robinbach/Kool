using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBoard : MonoBehaviour {

	Text txt;
	static int time;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
		txt.enabled = false;
		time = GameStatus.Instance.GameMaxTime;
		StartCoroutine (TimeCountDown ());
	}

	IEnumerator TimeCountDown()
	{
		if (CameraStartAnim.Instance.done != true)
			yield return new WaitForSeconds(12.0f);

		txt.enabled = true;
		txt.text = "Start!";
		yield return new WaitForSeconds(3.0f);

		while(time > 0)
		{
			time--;
			txt.text = time.ToString("d3");
			yield return new WaitForSeconds(1.0f);
		}

		int status = GameStatus.Instance.EndGameByTimeLimit ();

		txt.fontSize = 50;

		switch(status)
		{
		case 0:
			txt.text = "Win!";
			break;
		case 1:
			txt.text = "Win!";
			break;
		default:
			txt.text = "Tie!";
			break;
		}
	}
		
	public static void EndGame()
	{
		time = 0;
	}
//	// Update is called once per frame
//	void Update () {
//
//		txt.text = GetScore(1) + " : " + GetScore(0);
//	}
//
//	private int GetScore(int teamNum){
//		return GameStatus.Instance.GameTargetRounds - GameStatus.Instance.GetTeamScore (teamNum);
//	}
}
