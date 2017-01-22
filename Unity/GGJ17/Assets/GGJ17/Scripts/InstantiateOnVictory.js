#pragma strict

var popCorn : GameObject;
var tering : GameObject;

function Start () {
	
}

function FixedUpdate () {
    Instantiate(popCorn, gameObject.transform.position, Quaternion.identity);
    transform.Rotate(Vector3.up, 30 * Time.deltaTime);
}

function TeringHond () {
    tering.SetActive(true);

}
