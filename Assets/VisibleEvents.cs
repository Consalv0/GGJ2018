using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleEvents : MonoBehaviour {
	public ActivatedEvent onBecameVisible;
	public ActivatedEvent onBecameInvisible;

	public void Awake() {
		foreach (var action in onBecameVisible.actions) {
			action.Initialize();
		}
		foreach (var action in onBecameInvisible.actions) {
			action.Initialize();
		}
	}

	void OnBecameVisible() {
		onBecameVisible.Invoke();
	}

	void OnBecameInvisible() {
		onBecameInvisible.Invoke();
	}
}
