﻿using UnityEngine;
using System.Collections;

public class GenerateWizardUI : MonoBehaviour {

	public GameObject playerHealthPrefab;
	public GameObject namePrefab;
//	public GameObject specialSpellPrefab;
	public GameObject ButtonIcon;
	public GameObject ButtonIcon2;

	// Use this for initialization
	void Start () {
		StartCoroutine (LateGenerateWizardUI ());
	}

	IEnumerator LateGenerateWizardUI()
	{
		// wait for load scene done
		Debug.Log ("[UI] Prepare load player");

		yield return new WaitForSeconds (0.1f);
		GameObject[] playerCollection = GameObject.FindGameObjectsWithTag (TagList.Player);
		foreach(GameObject player in playerCollection)
		{

			UserInputManager userCtrl = player.GetComponent<UserInputManager>();
			// assign player ID
			int playerId = userCtrl.playerNum;
			GameObject health = Instantiate(playerHealthPrefab) as GameObject;
			health.transform.SetParent(this.transform);
			GameObject name = Instantiate(namePrefab) as GameObject;
			name.transform.SetParent(this.transform);
//			GameObject specialSpell = Instantiate(specialSpellPrefab) as GameObject;
//			specialSpell.transform.SetParent(this.transform);
			if (ButtonIcon){
				GameObject button = Instantiate(ButtonIcon) as GameObject;
				Debug.Log ("button instantiate");
				button.transform.SetParent(this.transform);
				button.GetComponent<ButtonView>().playerId = playerId;
				button.GetComponent<ButtonBlink>().playerId = playerId;
			}

			if (ButtonIcon2){
				GameObject button2 = Instantiate(ButtonIcon2) as GameObject;
				Debug.Log ("button instantiate");
				button2.transform.SetParent(this.transform);
				button2.GetComponent<ButtonView>().playerId = playerId;
				button2.GetComponent<AlwaysBlink>().playerId = playerId;
			}
			
			PlayerHealthView healthUI  = health.GetComponent<PlayerHealthView>();
			PlayerNameView nameUI = name.GetComponent<PlayerNameView>();
//			SpecialSpellView specialSpellUI = specialSpell.GetComponent<SpecialSpellView>();
			
			healthUI.playerId = playerId;
			nameUI.playerId = playerId;
//			specialSpellUI.playerId = playerId;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
