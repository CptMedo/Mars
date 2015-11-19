using UnityEngine;
using System.Collections;

public class ScannerManager : MonoBehaviour {

	bool scan = false;
	public float speedRay = 0f;
	public float speedCollider = 0f;
	public GameObject scannerRay;
	public GameObject scannerCollider;
	public GameObject scannerImages;

	float size = 0f;
	public float sizeTime = 2f;
	Vector3 euler;

	AudioSource sound;

	// Use this for initialization
	void Start () {

		sound = GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		euler = scannerRay.transform.localEulerAngles;
		euler.z -= speedRay;
		scannerRay.transform.localEulerAngles = euler;

		euler = scannerCollider.transform.localEulerAngles;
		euler.z -= speedCollider;
		scannerCollider.transform.localEulerAngles = euler;

		if (scan)	{	
			size = Mathf.Lerp(size,1f,sizeTime*Time.deltaTime);
		}else {
			size = Mathf.Lerp(size,0f,sizeTime*Time.deltaTime);

		}
		//respiration
		//scannerSystem.transform.localScale = new Vector3(Mathf.PingPong(Time.time*sizeTime, 0.2f)+0.8f, Mathf.PingPong(Time.time*sizeTime, 0.2f)+0.8f, scannerSystem.transform.localScale.z);

		scannerImages.transform.localScale = new Vector3(size, size, scannerImages.transform.localScale.z);

	}

	public void StopScan() {

		scan = false;
		Debug.Log("Scan stopped");
		speedCollider = 0f;
		sound.Stop();

	}


    public void StartScan()
    {

        Debug.Log("Scan started");
        scan = true;
        speedCollider = 2f;
        speedRay = 2f;

        //initialise les rotation à 0
        euler = scannerRay.transform.localEulerAngles;
        euler.z = 0;
        scannerRay.transform.localEulerAngles = euler;

        euler = scannerCollider.transform.localEulerAngles;
        euler.z = 0;
        scannerCollider.transform.localEulerAngles = euler;

        sound.Play();
        Invoke("StopScan", 3f);


    }

    void OnGUI() {


	}




}
