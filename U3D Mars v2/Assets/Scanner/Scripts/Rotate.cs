using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {


	public float speed = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 euler = transform.localEulerAngles;
		euler.z -= speed;
		transform.localEulerAngles = euler;
	}
}
