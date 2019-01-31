using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour {

	[System.Serializable]
	public class Path {
		public string Verdict;
		public Page Destination;
	}

	public int Number;		
	public string Name;
	public string Dialogue;
	public string[] Effects;
	public string TargetAction;
	public string TargetObject;
	public Path[] Paths; 
	private Dictionary<string, Page> PathMap;

	// Use this for initialization
	void Start () {
		//for(int i = 0; i < Paths.Length; i++){
		//	PathMap.Add(Paths[i].Verdict, Paths[i].Destination);
		//}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Page NextPage (string verdict) {
		for(int i = 0; i < Paths.Length; i++){
			if(Paths[i].Verdict == verdict){
				return Paths[i].Destination;
			}
		}
		return this;
		/*
		Page next;
		PathMap.TryGetValue(verdict, out next);
		if (next.Name == "SELF") { return this; }
		else { return next; }
		*/
	}
}
