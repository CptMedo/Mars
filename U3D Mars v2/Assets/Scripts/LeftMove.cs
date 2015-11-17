using UnityEngine;
using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D.Platformer;

public class LeftMove : MonoBehaviour {

	public Transform player;

	public void OnMouseDown()  {
		Debug.Log ("mouse down");
		player.GetComponent<PlayerInput>().direction = -1;
	}
	
	public void OnMouseUp()  {
		Debug.Log ("mouse up");
		player.GetComponent<PlayerInput>().direction = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
