using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WorldModel : MonoBehaviour {

	// Persistent Data
	public Page CurPage;
	private int Score;
	public GameObject Landing;
	// UI
	public Text Scorekeeper;
	public InputField UserInput;
	public Text Dialogue;

	// Use this for initialization
	void Start () {
		Dialogue.text = CurPage.Dialogue;
		Score = 0;
		Scorekeeper.text = "Health: " + Score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Enable, Disable, and LevelFinishedLoading functions copied from
	// http://answers.unity3d.com/questions/1174255/since-onlevelwasloaded-is-deprecated-in-540b15-wha.html
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable()
	{
	    
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		
		Landing = GameObject.Find("Wake Up");
		CurPage = Landing.GetComponent(typeof(Page)) as Page;
		Dialogue.text = CurPage.Dialogue;	
	}


	public void Respond (){
		CurPage = CurPage.NextPage(EvaluateInput());
		Dialogue.text = CurPage.Dialogue;

		//Debug.Log(CurPage.Name);
		// Run all effects associated with arriving at new page.
		for(int i = 0; i < CurPage.Effects.Length; i++){
			ExecuteEffect(CurPage.Effects[i]);
		}
		Scorekeeper.text = "Health: " + Score;
		
	}


	void ExecuteEffect (string effect){
		char [] delimiters = {','};
		string[] parameters = effect.Split(delimiters);
		if(parameters[0].Equals("Health")){
			if (parameters.Length != 2){
				Debug.LogException(new Exception("Insufficient parameters for Health"));	
			} else {
				Score += Int32.Parse(parameters[1]);
				Scorekeeper.text = "Health: " + Score;
			}
		} else if (parameters[0].Equals("Scene Change")){
			if (parameters.Length != 2){
				Debug.LogException(new Exception("No scene to switch to"));	
			} else {
				Debug.Log(parameters[1]);
				SceneManager.LoadScene( "" + parameters[1].Trim());
			}
		}  
	}

	string EvaluateInput(){
		char [] delimiters = {','};
		string[] parameters = CurPage.TargetAction.Split(delimiters);
		//Debug.Log("User Input: " + UserInput.text + ", Target Action: " + CurPage.TargetAction);
		int i;
		for (i = 0; i < parameters.Length; i++) {
			if (UserInput.text.Equals (parameters [i].Trim ())) {
				//Debug.Log("Proceed");
				return ("Proceed"+i);
			}
		}
			//Debug.Log("Repeat");
			return "Repeat";
}
}
