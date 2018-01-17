#pragma strict
var maxFallDistance = -1;

function Start () {

}

function Update () {
	if (transform.position.y <= maxFallDistance) {
		Application.LoadLevel("MainMenu");
	}
	if (transform.position.y >= PlayerPrefs.GetInt("Score")) {
		PlayerPrefs.SetInt("Score", transform.position.y);
	}
}