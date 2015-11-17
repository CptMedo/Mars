using UnityEngine;
using System.Collections;

public class CharacterChange : MonoBehaviour {


	public GameObject GuiHuman;
	public GameObject GuiRobot;
	public GameObject Human;
	public GameObject Robot;

	// Use this for initialization
	void Start () {
		//HumanSelection ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void HumanSelection () {
		GuiHuman.SetActive (true);
		GuiRobot.SetActive(false);

		Human.GetComponent<SpriteRenderer> ().enabled = true;
		Robot.GetComponent<SpriteRenderer> ().enabled = false;
	
	}

	void RobotSelection () {

		GuiHuman.SetActive (false);
		GuiRobot.SetActive (true);

		Human.GetComponent<SpriteRenderer> ().enabled = false;
		Robot.GetComponent<SpriteRenderer> ().enabled = true;
		
	}
}

