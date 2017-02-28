using UnityEngine;
using System.Collections;

public class portalScript : MonoBehaviour {
	public Camera rayCamera;
	public GameObject portalIn;
	public GameObject portalOut;

	// Use this for initialization
	void Start () {
		portalIn.SetActive (false);
		portalOut.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Vector3 forward = rayCamera.transform.TransformDirection (Vector3.forward) * 100; //set the ray forward from the camera
			Debug.DrawRay (transform.position, forward, Color.green);

			Ray ray = new Ray (transform.position, forward);
		
			if (Physics.Raycast (ray, out hit)) {
				if (hit.rigidbody != null) {
					portalIn.transform.position = hit.point;
					portalIn.SetActive (true);
					print (hit.point);
				}
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			RaycastHit hit;
			Vector3 forward = rayCamera.transform.TransformDirection (Vector3.forward) * 100; //set the ray forward from the camera
			Debug.DrawRay (transform.position, forward, Color.green);

			Ray ray = new Ray (transform.position, forward);

			if (Physics.Raycast (ray, out hit)) {
				if (hit.rigidbody != null) {
					portalOut.transform.position = hit.point;
					portalOut.SetActive (true);
					print (hit.point);
				}
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "pIn" && portalOut.activeSelf) {
			print (col.gameObject.name);
			transform.position = portalOut.transform.position + portalOut.transform.forward;
		} else if (col.gameObject.name == "pOut") {
			
		}
	}

}
