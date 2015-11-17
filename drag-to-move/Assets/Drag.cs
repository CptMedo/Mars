using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Drag : MonoBehaviour{
	
	private bool mouseDown = false;
	private Vector2 startMousePos;
	private Vector2 startPos;
	private float maxSpeed = 4f;
	public float moveForce = 4f;
	private Rigidbody2D rb2d;

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	public void OnMouseDown()  {
		mouseDown = true;
		startPos = transform.position;
		startMousePos = Input.mousePosition;
	}

	public void OnMouseUp()  {
		Debug.Log("On pointer bvleiubver");
		mouseDown = false;
		rb2d.velocity = Vector2.zero;
		rb2d.angularVelocity = 0;
	}

	
	void FixedUpdate () 
	{
		if (mouseDown) {
			Debug.Log("update if");
			Vector2 currentPos = Input.mousePosition;
			Vector2 diff = currentPos - startMousePos;

			if (rb2d.velocity.x * moveForce < maxSpeed || rb2d.velocity.x * moveForce > -maxSpeed) {
				if (diff.x > 1) {
					rb2d.AddForce(Vector2.right * moveForce);
				} else if (diff.x < -1) {
					Debug.Log("pos < 1");
					rb2d.AddForce(Vector2.left * moveForce);
				}
			}

			if (Mathf.Abs(rb2d.velocity.x) > maxSpeed) {
				Debug.Log("velo > maxspeed");
				Debug.Log(rb2d.velocity.x);
				rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
			}
		}
	}
}