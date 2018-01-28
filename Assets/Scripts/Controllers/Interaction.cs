using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction {
	bool Enabled { get; set; }
	void Interact(GameObject inter);
}


public class Interaction : MonoBehaviour {
	public string interactionButton = "Fire1";
	public bool canInteract = true;
	public float reach = 100;

	RaycastHit hit;

	void TryInteraction() {
		if (canInteract)
		if (Physics.Raycast(transform.position, transform.forward, out hit, reach)) {
				Debug.Log(hit.transform.gameObject);
			if (hit.transform.GetComponent(typeof(IInteraction)) != null) {
				((IInteraction) hit.transform.GetComponent(typeof(IInteraction))).Interact(this.gameObject);
			}
		}
	}

	private void Update() {
		if (Input.GetButtonDown(interactionButton)) {
			TryInteraction();
		}
	}
}
