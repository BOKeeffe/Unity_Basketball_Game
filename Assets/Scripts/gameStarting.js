#pragma strict
public var startingText : UI.Text;
var endTime : float;
var seconds : int;

function Start () {
	endTime = Time.time + 8;
	startingText.text = "Game starting in : ";
}

function Update () {
	var timeLeft : int = endTime - Time.time;
	if (timeLeft < 0) 
	{
		timeLeft = 0;
	}
	if (timeLeft == 0){
		Application.LoadLevel(1);
	}
	startingText.text = timeLeft.ToString();
	startingText.text = "Game starting in : " + timeLeft;
}