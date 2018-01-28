using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEvent : MonoBehaviour, IInteraction {
	public bool switcher;
	public ActivatedEvent onEvent, offEvent;

	public void Switch() {
		switcher = !switcher;
		if (switcher) {
			onEvent.Invoke();
		} else {
			offEvent.Invoke();
		}
	}

	public void Interact(GameObject inter) {
		Switch();
	}
	public bool Enabled {
		get { return enabled; }
		set { enabled = value; }
	}

	// Use this for initialization
	void Start () {
		foreach (var action in onEvent.actions) {
			action.Initialize();
		}

		foreach (var action in offEvent.actions) {
			action.Initialize();
		}
	}
}
