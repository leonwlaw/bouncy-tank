using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

	public TextMesh Output;

	float movePower = 150.0f;
	float sidePower = 25.0f;
	float rotatemovePower = 60.0f;
	float jetLaunchPower = 50.0f;

	Vector3 gravity = new Vector3(0, -98.1f, 0);

	Vector3 velocity = Vector3.zero;
	Vector3 jumpVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		string outputText = "";
		CharacterController controller = GetComponent<CharacterController>();

		if (Input.GetKey(KeyCode.W)) {
			velocity += movePower * transform.forward;
			outputText += "VROOOOOOOM" + '\n';
		}
		if (Input.GetKey(KeyCode.S)) {
			velocity -= movePower * transform.forward;
			outputText += "YOU'RE GOING THE WRONG WAY" + '\n';
		}

		if (Input.GetKey(KeyCode.Q)) {
			velocity -= sidePower * transform.right;
			outputText += "YOU'RE NOT A CRAB" + '\n';
		}
		if (Input.GetKey(KeyCode.E)) {
			velocity += sidePower * transform.right;
			outputText += "YOU'RE NOT A CRAB" + '\n';
		}

		if (Input.GetKey(KeyCode.A)) {
			transform.Rotate(-rotatemovePower * transform.up * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(rotatemovePower * transform.up * Time.deltaTime);
		}

		if (!controller.isGrounded) {
			jumpVelocity += gravity * Time.deltaTime;
			outputText += "*BOING*" + '\n';
		} else {
			jumpVelocity = Vector3.zero;
		}

		if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
			jumpVelocity += new Vector3(0, jetLaunchPower, 0);
		}

		controller.SimpleMove(velocity * Time.deltaTime);
		controller.Move(jumpVelocity * Time.deltaTime);

		// SimpleMove must be called last again so that gravity is
		// properly applied.
		controller.SimpleMove(Vector3.zero);

		velocity *= (1 - 3 * Time.deltaTime);

		Output.text = outputText;
	}
}
