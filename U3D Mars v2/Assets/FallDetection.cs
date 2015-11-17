using UnityEngine;
using System.Collections;

public class FallDetection : MonoBehaviour {


	public GameObject GuiDeath;

	public bool death;


	// Use this for initialization
	void Start () {
		Init ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		Death();
		death = true;
		Time.timeScale = 0;
		//StartCoroutine(Restart());
	}


	void Restart() {

		//yield return new WaitForSeconds(3);
		Application.LoadLevel (2);//Application.loadedLevel);
	}

	
	void Death () {
		GuiDeath.SetActive (true);

		
	}
	
	void Init () {
		
		GuiDeath.SetActive (false);
		death = false;

		
	}





}
