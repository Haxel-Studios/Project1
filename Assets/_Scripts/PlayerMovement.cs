using UnityEngine;
using System.Collections; //Pre-generated

//Player Controller script - Controls most/all of the events regarding the player

// 08/09/2015 - Wrote movement scripts, including constraining to 3x3 grid and auto-centering
// Next step: Unknown - more design work to be completed first
// - Steve

public class PlayerMovement : MonoBehaviour { 

	//Variable declaration

	public Transform startMarker;			//Start position of movement - always assigned to player
	public Transform endMarker;				//End position
	public float speed;						//Speed - multiplied by movement values
	private float startTime;				//Game time when movement started
	private float journeyLength;			//Distance to travel (total)

	//Initialisation method
	void Start() {
		startTime = Time.time; 														//Record start time
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position); //Calculate travel distance

		speed = 10000000000.0f; //Stupidly high value to fix unusual bug
	}

	//Update method - called every frame (?)
	void Update() {

		if (transform.position == new Vector3 (0.0f, 0.0f, 0.0f)) {
			speed = 0.01f;											//Second half of bug-fixing...
		}

		//Player movement control

		if (Input.GetKey("right")) { //Movements to the right, inc. diagonals
			if(Input.GetKey ("up")){
				endMarker = GameObject.Find("Top Right").transform;

			}else if(Input.GetKey ("down")){
				endMarker = GameObject.Find("Bottom Right").transform;

			}else{
				endMarker = GameObject.Find("Right").transform;

			}
		}

		if (Input.GetKey("left")) { //To the left...
			if(Input.GetKey ("up")){
				endMarker = GameObject.Find("Top Left").transform;
				
			}else if(Input.GetKey ("down")){
				endMarker = GameObject.Find("Bottom Left").transform;
				
			}else{
				endMarker = GameObject.Find("Left").transform;
				
			}
		}

		if (Input.GetKey("up")) { //Upward movements...
			if(Input.GetKey ("right")){
				endMarker = GameObject.Find("Top Right").transform;
				
			}else if(Input.GetKey ("left")){
				endMarker = GameObject.Find("Top Left").transform;
				
			}else{
				endMarker = GameObject.Find("Top").transform;
				
			}
		}

		if (Input.GetKey("down")) { //...and downwards movements.
			if(Input.GetKey ("right")){
				endMarker = GameObject.Find("Bottom Right").transform;
				
			}else if(Input.GetKey ("left")){
				endMarker = GameObject.Find("Bottom Left").transform;
				
			}else{
				endMarker = GameObject.Find("Bottom").transform;
				
			}
		}

		if (!Input.anyKey) {
			endMarker = GameObject.Find("Centre").transform;	//Do nothing if player is doing nothing
		}

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);	//Code for smooth movement (taken from Unity docs)
	}
}



