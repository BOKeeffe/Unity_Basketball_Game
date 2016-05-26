#pragma strict
public var target: Transform;
public var orbitSpeed : int = 30;
function Start () {

}
function Update(){
    transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * orbitSpeed);
}