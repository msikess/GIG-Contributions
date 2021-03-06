#pragma strict
//Template for this was taken from the unity documentation site at
//https://docs.unity3d.com/ScriptReference/Input-inputString.html

//This script is a component of the Main Camera in this project, and it works, 
//but it might be better placed as a component of the Input Field


//This code will take input from a user via the Input Field and store it in a string, 'gt.text'
var handler : GameObject;

var userInput: String;

function Start () {
	//Start off with a clean slate
	userInput = "";
	//DontDestroyOnLoad(gameObject);
}

function Update () {
    for (var c : char in Input.inputString) {
        // Backspace - Remove the last character
        if (c == "\b"[0]) {
            if (userInput.Length != 0)
                userInput = userInput.Substring(0, userInput.Length - 1);
        }
        // End of entry
        else if (c == "\n"[0] || c == "\r"[0]) {// "\n" for Mac, "\r" for windows.
        	//I chose to split up the string and print it out, but you could do anything with the string.
            /*var words = userInput.Split();
            for (var word : String in words) {
            	print("Word is: " + word + "\n");
            }*/
            handler.GetComponent(Handler).output = userInput;
            //Clean the slate again.
            userInput = "";
        }
        // Normal text input - just append to the end
        else {
            userInput += c;
        }
    }
}
