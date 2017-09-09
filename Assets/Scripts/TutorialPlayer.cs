using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPlayer : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text endText;


	private Rigidbody rb;
	private int count;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		endText.text = "";
		//Timer.text = 0.ToString ();
	}

	// Update is called once per frame

	void FixedUpdate(){
		
		float moveHorizontal = Input.GetAxis ("Horizontal"); // Left right
		float moveVertical = Input.GetAxis ("Vertical"); //Forward backward

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			setCountText ();
		}
	}

	void setCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count == 12) {
			endText.text = "You Win";

		}
	}
}
