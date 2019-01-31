#pragma strict

/*class Node {
    var name : String;
    var next : Node;

    function Node(s : String) {
    name = s;
    next = first;
    }
}*/

//first = null;

var hasBook : boolean;

function Awake () {
	DontDestroyOnLoad (transform.gameObject);
}

function Start () {
	hasBook = false;
}

function Update () {
	
}

/*funciton addToInventory(s : String) {
	var newItem = new Node(s);
	first = newItem;
}*/

/*function removeFromInventory(index : int) {
	var cur = first;
	if (index == 0) {
		first = cur.next;
	}*/

