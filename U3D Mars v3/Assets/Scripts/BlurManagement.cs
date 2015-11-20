using UnityEngine;
using System.Collections;
using  UnityEngine.UI;

public class BlurManagement : MonoBehaviour {


	public Text txtZoom;
	public Text txtCoordsXYZ;
	public Text txtCoordsSpheric;	
	public Text txtDebug1;	
	public Text txtDebug2;

	TBOrbit tbo;


	//float distance = 0;
	float blur = 0;
	public GameObject planet;
	//public GameObject cam;

	Blur be;
	public Camera camera;

	// Use this for initialization
	void Start () {

		//	txt = gameObject.GetComponent<Text>(); 

		be = camera.GetComponent<Blur>(); 

		tbo = camera.GetComponent<TBOrbit>(); 


	}


	//public  float[] 

	public void CartesianToSpherical(float x, float y, float z) {
		float[] retVal = new float[2];

		float phi=0, teta =0;
		
		Vector3 v = new Vector3(x, y, z);
		
		
		if (x == 0) {
			x = Mathf.Epsilon;
		}
		//retVal[0] = Mathf.Atan(z / x);

		teta = (Mathf.Atan(z/ x) * Mathf.Rad2Deg );
		//teta = Mathf.Asin(x / v.magnitude) * Mathf.Rad2Deg;

		if (x < 0) {
			//retVal[0] += Mathf.PI;

			teta -= 90; 
		}else {
			//retVal[0] += Mathf.PI;
			
			teta += 90; 
		}  
		teta = -teta;
		//retVal[1] = Mathf.Asin(y / v.magnitude);
		phi = Mathf.Asin(y / v.magnitude) * Mathf.Rad2Deg;
		
	//	txtCoordsSpheric.text = "phi: " + retVal[0] + " - teta: " + retVal[1] + " - rho: " + v.magnitude;
		txtCoordsSpheric.text = "teta: " + teta + " - phi: " + phi + " - rho: " + v.magnitude;

		//tbo.idealPitch = 360* Mathf.Floor( tbo.idealPitch / 360)+ phi;   // latitude
		//tbo.idealYaw = 360* Mathf.Floor( tbo.idealYaw / 360) -teta;  //longitude



		float result1 = Mathf.Floor (Mathf.Abs (tbo.idealYaw) / 180) * Mathf.Sign(tbo.idealYaw)*180;
		float result2 = Mathf.Floor(Mathf.Abs(tbo.idealPitch) / 180) * Mathf.Sign(tbo.idealPitch)*180;


	//	tbo.idealYaw =  result1 -teta;  //longitude
		tbo.idealPitch = result2 + phi;   // latitude


		txtDebug1.text = "Yaw:" + result1.ToString(); 
		txtDebug2.text = "teta:" + teta; 
		//result.ToString();


		//return retVal;

	}



	
	// Update is called once per frame
	void Update () {
	
//		distance = Vector3.Distance (planet.transform.position, camera.transform.position);
//		txt.text = distance.ToString();


		if (Input.GetMouseButtonDown(0)){
			Debug.Log("Pressed left click.");

			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);

			Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

			if (Physics.Raycast(ray, out hit)) {
				//Transform objectHit = hit.transform;
				
			//	txt.text = hit.distance.ToString();


				if (hit.distance > 5.0f){
					blur = 0;
					//be.blurSize = blur;

				}else if (hit.distance < 0.2f){
						//blur = 0;
					Application.LoadLevel(1);

				}else{
					blur = Mathf.Abs(5-hit.distance) * 10;
					//be.blurSize = blur;
					//be.blurIterations = blur.;
				}
				/*
				if (blur > 40.0f){
					//blur = 0;
					be.blurIterations = 1;
					be.downsample=1;
					
				}else{
					be.blurIterations = 0;
					be.downsample=1;
				}*/

				txtZoom.text = blur.ToString(); //hit.distance.ToString();
				txtCoordsXYZ.text = "x: " + hit.point.x + " - y: " + hit.point.y + " - z: " + hit.point.z;
				//txtCoords.text = "phi: " + retVal[0] + " - teta: " + retVal[1] + " - rho: " + v.magnitude;

				CartesianToSpherical(hit.point.x, hit.point.y, hit.point.z);

				be.blurSize = blur;
				
				// Do something with the object that was hit by the raycast.
			}

		}



	}
}
