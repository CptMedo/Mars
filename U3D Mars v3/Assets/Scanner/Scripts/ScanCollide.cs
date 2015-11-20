using UnityEngine;
using System.Collections;

public class ScanCollide : MonoBehaviour {

	public float sizeTime = 0.1f;
	public float fadeInTime = 1f;
	public float fadeOutTime = 3f;
	bool scanned = false;
	public float timeToFadeOut = 1f;
	public float timeToStopPingPongSize = 1f;
	Vector3 initialSize;
	bool blink = false;
	public GameObject shockWave;
    public GameObject scanner;
	AudioSource sound;



	SpriteRenderer sr;
	float fade;
	float size = 1f;




	// Use this for initialization
	void Start () {

		sr = GetComponent<SpriteRenderer> ();
		fade = 0f;
		sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, fade);

		initialSize = this.transform.localScale;

		 sound = GetComponent<AudioSource>();


	}

	void SetFadeOut () {
		scanned = false;
	}

	void StopSizePingPong() {
		blink = false;

	}
	
	void Update () {
		
		if (scanned) {
			//size = Mathf.PingPong (Time.time *sizeTime, 0.1f);
			size = Mathf.PingPong(Time.deltaTime*sizeTime, 1.0f);
			fade = Mathf.Lerp(fade,1f,fadeInTime*Time.deltaTime);


			Invoke ("SetFadeOut", timeToFadeOut);

		}
		else{
			fade = Mathf.Lerp(fade,0f,fadeOutTime*Time.deltaTime);
		}

		sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, fade);


		if ((blink)){ // && (fade < 0.4f)) {

			this.transform.localScale = new Vector3(Mathf.PingPong(Time.time*sizeTime, 0.2f)+0.8f, Mathf.PingPong(Time.time*sizeTime, 0.2f)+0.8f, this.transform.localScale.z);
		}else{
			this.transform.localScale = initialSize;
		}

		/*
		if(fade < 0.2f){
			//Debug.Log (this.name + " catched by player");
			shockWave.SetActive(false);
		}else{
			shockWave.SetActive(true);
		}*/

	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "scan" && scanner.GetComponent<ScannerManager>().isScanning)
        {
			CancelInvoke("SetFadeOut");
			scanned=true;
			Debug.Log (this.name + " scanned");
			//shockWave.SetActive(true);
			if (fade < 0.4f) sound.Play();
			blink = true;
			Invoke ("StopSizePingPong", (1/sizeTime) * timeToStopPingPongSize);



		}else if (other.gameObject.tag == "Player"){

            if (scanned)
            {
                Debug.Log(this.name + " catched by player");
                shockWave.SetActive(true);
                sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, 0f);
            }
		}

	}


}
