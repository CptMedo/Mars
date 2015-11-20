using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	float CamRotIntro = 20.0f;
	public float smoothTime = 0.1f;
	public GameObject cam;
	public GameObject reference;
	private bool rotating = true;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		/*CamRotIntro = Mathf.Lerp(CamRotIntro, 0, Time.deltaTime * smoothTime);
		//cam.
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		cam.transform.rotation = Quaternion.LookRotation(newDir);*/

//		Vector3 desiredRotation = new Vector3(20, 0, 0);

	///	cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, reference.transform.rotation, Time.deltaTime * smoothTime);

/*
		if (rotating)
		{
			Vector3 to = new Vector3(20, 0, 0);
			if (Vector3.Distance(cam.transform.eulerAngles, to) > 0.01f)
			{
				cam.transform.eulerAngles = Vector3.Lerp(cam.transform.rotation.eulerAngles, to, Time.deltaTime*smoothTime);
			}
			else
			{
				cam.transform.eulerAngles = to;
				rotating = false;
			}
		}
*/

	}


	void LevelLoad () {
		Application.LoadLevel(1);
	}

	void OnGUI(){

			// Make the second button.
			if(GUI.Button(new Rect(10,70,80,50), "Back")) {
				//Application.LoadLevel(2);
				Application.LoadLevel(1);
			}

	}
	


}
