using UnityEngine;
using System.Collections;
using  UnityEngine.UI;

public class BlurManagement2 : MonoBehaviour {


//	public Text txt;
	//float distance = 0;
	float blur = 10.0f;
	//public GameObject planet;

	Blur be;
	public Camera camera;

	private bool  TitleOK = false;


	float Fade = 0f;
	float fadeInTime = 0.5f;
	float fadeOutTime = 1.3f;

	public Text guiTitle;



	// Use this for initialization
	void Start () {

		//	txt = gameObject.GetComponent<Text>(); 

		be = camera.GetComponent<Blur>(); 
		//text = guiTitle.GetComponent<SpriteRenderer> ();
		
		be.enabled = true;

		InvokeRepeating("Blur", 0, 0.1f);

		//startTime = Time.time;

		be.blurSize = 10.0f;

	}


	void Blur () {

		if (blur >0){
			blur = blur - 0.5f;
			be.blurSize = blur;
		}else{

			be.enabled = false;
	//		this.enabled = false;
		}

	}


	
	// Update is called once per frame
	void Update () {


		//if (Fade > 2f) {
		//	Fade= Mathf.Lerp(Fade,2f,Time.deltaTime*fadeTime);
		//	guiTitle.color = new Color(guiTitle.color.r, guiTitle.color.g, guiTitle.color.b, Fade);

		if (TitleOK == false){
			Fade= Mathf.Lerp(Fade,1f,Time.deltaTime*fadeInTime);
			guiTitle.color = new Color(guiTitle.color.r, guiTitle.color.g, guiTitle.color.b, Fade);


	//	float a = Mathf.PingPong (Time.time / duration, 1.0f);
	//	guiTitle.color = new Color(1f, 1f, 1f, a);

			if (Fade > 0.8f) TitleOK = true;


		}else{
			//Destroy(this.gameObject);
			Fade= Mathf.Lerp(Fade,0f,Time.deltaTime*fadeOutTime);
			guiTitle.color = new Color(guiTitle.color.r, guiTitle.color.g, guiTitle.color.b, Fade);


			if (Fade < 0.1f) TitleOK = true;

		}
	
//		distance = Vector3.Distance (planet.transform.position, camera.transform.position);
//		txt.text = distance.ToString();




	/*	RaycastHit hit;
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out hit)) {
			//Transform objectHit = hit.transform;
			
		//	txt.text = hit.distance.ToString();


			if (hit.distance > 5.0f){
				blur = 0;
				//be.blurSize = blur;
			}else{
				blur = Mathf.Abs(5-hit.distance) * 10;
				//be.blurSize = blur;
				//be.blurIterations = blur.;
			}

			txt.text = blur.ToString(); //hit.distance.ToString();

			be.blurSize = blur;
			
			// Do something with the object that was hit by the raycast.
		}
*/



	}
}
