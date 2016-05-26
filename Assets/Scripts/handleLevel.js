#pragma strict
public var levelText : UI.Text;
function Start () {
	levelText.text = "";
}

function Update () {
	levelSetup();
}

function levelSetup(){
	if (Application.loadedLevel == 1){
		levelText.text = "Level: 1";
	}
	if (Application.loadedLevel == 2){
		levelText.text = "Level: 2";
	}
	if (Application.loadedLevel == 3){
		yield WaitForSeconds(3);
		Application.LoadLevel(0);
	}
}