using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class PlayerController : MonoBehaviour {
	public float speed ;
	private Rigidbody rb;
	private int Count ;
	public Text CubesCount , WinGame ;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		Count = 0;
		setTextCount ();
		WinGame.text = ""; // default 
	}

	void FixedUpdate(){ 
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
		
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);  
			Count++;
			setTextCount ();
		}
	}

	void setTextCount(){
		CubesCount.text = "Cubes Count : " + Count.ToString();
		if (Count == 11)
			WinGame.text = "Congratulation , u Collect all Cubes :D";
	}
}