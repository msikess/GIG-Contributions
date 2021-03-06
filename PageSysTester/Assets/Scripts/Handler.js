#pragma strict
import UnityEngine.SceneManagement;
//import UnityEditor.EditorApplication;

var output : String;

var isOpen;

var sceneNum : int;

function Start () {
	sceneNum = SceneManager.GetActiveScene().buildIndex;
}

function Update () {
	switch (sceneNum)
	{
	case 0:
		if(output =="hatch"){
			SceneManager.LoadScene(""+(sceneNum+2));
		}
		break;
	case 1:
		if(output =="mountains"){
			SceneManager.LoadScene(""+(sceneNum+2));
		}
		break;
	case 2:
		if(output =="go in"){
			SceneManager.LoadScene(""+(sceneNum+2));
		}
		break;
	case 3:
		if(output =="open"){
			isOpen = true;
		}
		if (output == "upstairs" && isOpen){
			//EditorApplication.LoadLevelAdditiveInPlayMode("4");
			SceneManager.LoadScene(""+(sceneNum+2));
		}
		break;
	case 4:
		if(output =="downstairs"){
			//SceneManager.UnloadSceneAsync(""+(sceneNum));
			SceneManager.LoadScene(""+sceneNum);
		}
		break;
	}
}
