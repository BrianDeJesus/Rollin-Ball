using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text endText;
	public Text Timer;


	private Button restart;
	private Rigidbody rb;
	private int count;
	private bool movin;
	private float finalTime;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		endText.text = "";
		movin = true;
		restart = GameObject.Find ("Play Again Button").GetComponent<Button>();
		restart.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update(){
		if (movin == true) {
			float moveHorizontal = Input.GetAxis ("Horizontal"); // Left right
			float moveVertical = Input.GetAxis ("Vertical"); //Forward backward

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.AddForce (movement * speed);
			Timer.text = Time.timeSinceLevelLoad.ToString ();
			finalTime = Time.timeSinceLevelLoad;
			checkTimesUp ();
			if (rb.position.y < -5) {
				endText.text = "You fell and died!";
				movin = false;
			}
		} else {
			restart.gameObject.SetActive (true);
		}
	}

	// Collisions
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText ();
		} 

	}

	void setCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count == 9) {
			endText.text = "You finished in " + finalTime.ToString() + " seconds!";
			gameOver ();
		}
	}

	void checkTimesUp () {
		if (Time.timeSinceLevelLoad >= 15.0f) {
			endText.text = "Time's up! You took way too long!";
			gameOver ();
		}
	}

	void gameOver() {
		movin = false;
		rb.drag = 100;
	}


}
