using UnityEngine;
using System.Collections;
using  UnityEngine.UI;

//[AddComponentMenu("Camera-Control/Mouse drag Orbit with zoom")]
public class rotateonmouse : MonoBehaviour
{
	public Transform target;
	Color fromColor, toColor, fromColorEmission;

	public GameObject locker;



	// Camera Drag variables
	public float distance = 5.0f;
	public float zoomZone = 0.0f;
	public float xSpeed = 120.0f;
	public float ySpeed = 120.0f;
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	public float distanceMin = .5f;
	public float distanceMax = 15f;
	public float smoothTime = 2f;
	public float dragTreshold = 1.0f;
	float rotationYAxis = 0.0f;
	float rotationXAxis = 0.0f;
	float velocityX = 0.0f;
	float velocityY = 0.0f;
	float velocityXInit = 0.0f;
	float velocityYInit = 0.0f;
	Quaternion rotation ;
	Quaternion fromRotation ;
	Quaternion toRotation;
	
	// Debug GUI
	public GameObject button;
//	public Text txtPlay;
	public Text txtZoom;
	public Text txtCoordsXYZ;
	public Text txtCoordsSpheric;	
	public Text txtDebug1;	
	public Text txtDebug2;	
	public Text txtGesture;	
	public Text txtZone;



	public Color colorBlue;
	public Color colorRed;
	public Color colorWhite;
	public Color colorGrey;
	public Color colorOrange;
	public Color colorBrown;

	// Game Management variables
	public enum GestureTypes {DragEnd, DragBegin, DragOn, None, MouseDown, MouseUp, Frozen};
	private GestureTypes gesture;

	public enum GameManager {Start, Selection, Zoom, Pause};
	private GameManager gameManager;

	public enum Zones {red, blue, white, orange, brown, grey, none};
	private Zones currentZone;

	private GameObject currentZoneObject;
	
	// Blur variables
	float blur = 0;
	Blur be;

	// Audio variables
	AudioSource audio;
	public AudioClip[] sounds; // set the array size and fill the elements with the sounds


	void OnGUI(){

		if(  (currentZone == Zones.blue) || (currentZone == Zones.none)){

			locker.SetActive(false);

			// Make the second button.
			if(GUI.Button(new Rect(10,90,200,100), "Play")) {
				//Application.LoadLevel(2);
				gameManager = GameManager.Zoom;
			}
		}else{


			locker.SetActive(true);
		}
	}


	
	// Use this for initialization
	void Start()
	{

		gesture = GestureTypes.None;
		gameManager = GameManager.Start;
		currentZone = Zones.none;

		ResetZonesColor();

		// init cam position
		toRotation = transform.rotation;
		rotation = toRotation;	
		Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
		Vector3 position = rotation * negDistance + target.position;
		transform.rotation = rotation;	
		transform.position = position;

		Vector3 angles = transform.eulerAngles;
		rotationYAxis = angles.y;
		rotationXAxis = angles.x;
		
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}

		be = GetComponent<Camera>().GetComponent<Blur>(); 
		audio = GetComponent<AudioSource>(); 
	}

	void ResetZonesColor()
	{
		txtZone.text = "";
		currentZone = Zones.none;
		// all zones in white
		Renderer rend ;
		//GameObject zone = GameObject.Find("Zones");
		
		foreach (Transform child in target.transform){
			//child.gameObject.renderer.enabled = false;
			rend = child.gameObject.GetComponent<Renderer>();
			rend.material.SetColor("_Color", Color.white);
	//		rend.material.SetColor("_EmissionColor", Color.black);
		//	rend.material.DisableKeyword ("_EMISSION");
		}

	}


	void PlayRandomSound(){ // call this function to play a random sound
		//if (audio.isPlaying) return; // don't play a new sound while the last hasn't finished
		audio.clip = sounds[Random.Range(0,sounds.Length)];
		audio.Play();
	}


	void DragBegin()
	{

	}

	void DragOn()
	{

	}

	void DragEnd()
	{	

	}
	
	void MouseDown()
	{
		
	}

	void MouseUp()
	{

		if (gameManager != GameManager.Zoom) {

			RaycastHit hit;
			Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			
			//Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
			
			if (Physics.Raycast(ray, out hit)) {
				
				txtCoordsXYZ.text = "x: " + hit.point.x + " - y: " + hit.point.y + " - z: " + hit.point.z;			
				float[] retVal = CartesianToSpherical(hit.point.x, hit.point.y, hit.point.z);
				toRotation = Quaternion.Euler(retVal[0], retVal[1], 0);

				Renderer rend ;
				//GameObject zone = GameObject.Find("Zones");

				if (txtZone.text == "Zone "+ hit.collider.gameObject.tag){

					// Double clic zone -> Zoom
					gameManager = GameManager.Zoom;

				}else{

					// Simple clic selection zone
					PlayRandomSound();
					ResetZonesColor();
					rend = hit.collider.gameObject.GetComponent<Renderer>();

					currentZone = (Zones)System.Enum.Parse (typeof(Zones), hit.collider.gameObject.tag.ToString());
					currentZoneObject = GameObject.FindGameObjectWithTag(currentZone.ToString());

					fromColor = Color.white;
					fromColorEmission = Color.black;
					toColor = GetColor(currentZone.ToString());
				//	txtZone.color = GetColor(currentZone.ToString());

					txtZone.text =  "Zone "+ GetElement(currentZone.ToString()); //hit.collider.gameObject.tag;
					txtZone.color = GetColor(currentZone.ToString());
					//txtPlay.color = GetColor(currentZone.ToString());
				}

			}else{

				ResetZonesColor();


			}
	  	}
	}

	void Update () {

		// apparition couleur en "fade in"
		if (currentZone != Zones.none){


			fromColor = Color.Lerp(fromColor, toColor, Time.deltaTime * smoothTime);
			fromColorEmission = Color.Lerp(fromColorEmission, toColor, Time.deltaTime * smoothTime);
			currentZoneObject.GetComponent<Renderer>().material.SetColor("_Color", fromColor); //*  Mathf.LinearToGammaSpace(0.6f)); 

	/*		if (currentZone == Zones.white){
				currentZoneObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", fromColorEmission *  Mathf.LinearToGammaSpace(0.1f));
				currentZoneObject.GetComponent<Renderer>().material.EnableKeyword ("_EMISSION");
				txtZone.color = Color.grey;
			}*/

			//button.SetActive(true);

		}else{

			//button.SetActive(false);
		}
	}


	void LateUpdate()
	{

		if (Input.GetMouseButtonDown(0)){

			velocityXInit = Mathf.Abs(velocityX);
			velocityYInit = Mathf.Abs(velocityY);

			Debug.Log ("MouseDown");
			txtGesture.text = "MouseDown";
			gesture = GestureTypes.MouseDown;
			MouseDown();

		} else
		if (Input.GetMouseButton(0)){

			velocityX += xSpeed * Input.GetAxis("Mouse X") * 0.02f;
			velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;

			if ((Mathf.Abs(velocityX) > velocityXInit + dragTreshold) || (Mathf.Abs(velocityY) > velocityYInit + dragTreshold)){ 

					if (gesture == GestureTypes.MouseDown){
						Debug.Log ("DragBegin");
						txtGesture.text = "DragBegin";
						gesture = GestureTypes.DragBegin;
						DragBegin();
					}else{
						Debug.Log ("DragOn");
						txtGesture.text = "DragOn";
						gesture = GestureTypes.DragOn;
						DragOn();
					}
			}
		} else
		if (Input.GetMouseButtonUp(0)){

			velocityXInit = Mathf.Abs(velocityX);
			velocityYInit = Mathf.Abs(velocityY);

			if (gesture == GestureTypes.DragOn){
					Debug.Log ("DragEnd");
					txtGesture.text = "DragEnd";
					gesture = GestureTypes.DragEnd;
					DragEnd();
			}else{
					Debug.Log ("MouseUp");
					txtGesture.text = "MouseUp";
					gesture = GestureTypes.MouseUp;
					MouseUp();
			}
			
		}

			// On each lateUpdate during selection phase:

			// on clic:
		if (gameManager != GameManager.Zoom) {

			if((gesture == GestureTypes.MouseDown) || (gesture == GestureTypes.MouseUp)){ 
				rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * smoothTime);

			}else{ // on drag: 
				rotationYAxis += velocityX;
				rotationXAxis -= velocityY;	
				rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
				
				toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
				rotation = toRotation;

				velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
				velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
			}




		}else{


			RaycastHit hit;

			if (Physics.Raycast(transform.position, transform.forward, out hit, 20)){

				distance = Mathf.Lerp(distance, hit.distance, Time.deltaTime * smoothTime /2);
				//txtZone.text= "Zoom " + distance.ToString();

				if (hit.distance > 5.0f){
					blur = 0;
				}else if (hit.distance < 0.6f){
					Application.LoadLevel(2);
					
				}else{
					blur = Mathf.Abs(5-hit.distance) * 10;
				}
					
				txtZoom.text = blur.ToString(); 
				be.blurSize = blur;
			}

		}
		Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
		Vector3 position = rotation * negDistance + target.position;
		
		transform.rotation = rotation;
		transform.position = position;

	}
	
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}

	public float[] CartesianToSpherical(float x, float y, float z) {

		float[] retVal = new float[2];
		float phi=0, teta =0;
		Vector3 v = new Vector3(x, y, z);
		
		if (x == 0) x = Mathf.Epsilon;

		// longitude
		teta = (Mathf.Atan(z/ x) * Mathf.Rad2Deg );
		if (x < 0) teta -= 90; 
		else teta += 90; 
		teta = -teta;

		//latitude
		phi = Mathf.Asin(y / v.magnitude) * Mathf.Rad2Deg;

		txtCoordsSpheric.text = "teta: " + teta + " - phi: " + phi + " - rho: " + v.magnitude;
	
		retVal[0] = phi;
		retVal[1] = teta;
		
		return retVal;
		
	}

	public Color GetColor(string aColor)
	{
		switch (aColor) {
		case "blue":
			return colorBlue; //colorBlue;  
		case "brown":
			return colorGrey; //colorBrown;    
		case "red":
			return colorGrey;
		case "orange":
			return colorGrey; //colorOrange;
		case "grey":
			return colorGrey; //colorGrey;
		case "white":
			return colorGrey; //colorWhite;
		default:
			return colorGrey; //colorRed;
		}

	}

	public string GetElement(string aColor)
	{
		switch (aColor) {
		case "blue":
			return "d'atterissage"; 
		case "brown":
			return "de minerai (Vérouillée)";    
		case "red":
			return "d'eau (Vérouillée)";
		case "orange":
			return "d'énergie (Vérouillée)";
		case "grey":
			return "de minerai (Vérouillée)";
		case "white":
			return "d'oxygène (Vérouillée)";
		default:
			return "";
		}
		
	}

}