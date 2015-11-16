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

	// Use this for initialization
	void Start () {

		//	txt = gameObject.GetComponent<Text>(); 

		be = camera.GetComponent<Blur>(); 

	

		InvokeRepeating("Blur", 0, 0.1f);

		be.blurSize = 10.0f;

	}


	void Blur () {

		if (blur >0){
			blur = blur - 0.5f;
			be.blurSize = blur;
		}

	}


	
	// Update is called once per frame
	void Update () {
	
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
