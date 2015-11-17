using UnityEngine;
using System.Collections;

public class ItemsCollect : MonoBehaviour {



	void Start() {
		audio = GetComponent<AudioSource>();
	}


	// Update is called once per frame
	void Update () {
	
	}


	AudioSource audio;
	

	
	void OnCollisionEnter(Collision collision) {
	/*	foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}
		if (collision.relativeVelocity.magnitude > 2)
			audio.Play();*/
		//Destroy (this.gameObject);

		//colliders.Add(collision.collider); // saves the enemy for later respawn
		collision.collider.gameObject.active = false; // deactivate instead of destroy so you could later reactivate (respawn) him

	}


}
