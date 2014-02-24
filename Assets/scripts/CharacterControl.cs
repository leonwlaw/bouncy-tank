using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	float movePower = 950.0f;
	float rotatemovePower = 45.0f;
	float jetLaunchPower = 10000.0f;
	float jetPower = 10.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			rigidbody.AddForce(movePower * transform.forward * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S)) {
			rigidbody.AddForce(-movePower * transform.forward * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Rotate(-rotatemovePower * transform.up * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(rotatemovePower * transform.up * Time.deltaTime);
		}

		if (Input.GetKeyDown(KeyCode.Space) && GetComponent<CharacterController>().isGrounded) {
			rigidbody.AddForce(jetLaunchPower * transform.up * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.Space)) {
			rigidbody.AddForce(jetPower * transform.up * Time.deltaTime);
		}
	}
}
