using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour {
	public Gradient skyColor;
	public Gradient lightColor;
	public float yEuler;
	public float dayDuration;

	[Range(0, 24)]
	public float dayTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		dayTime += Time.unscaledDeltaTime / dayDuration;
		if (dayTime >= 24) dayTime = 0;
		transform.localRotation = Quaternion.Euler(
			dayTime / 24 * 360 - 0, yEuler, 0);

		if (GetComponent<Light>()) {
			RenderSettings.ambientLight = skyColor.Evaluate(dayTime / 24);
			RenderSettings.fogColor = skyColor.Evaluate(dayTime / 24);
			RenderSettings.ambientSkyColor = lightColor.Evaluate(dayTime / 24);
			Camera.main.backgroundColor = lightColor.Evaluate(dayTime / 24);
			GetComponent<Light>().color = lightColor.Evaluate(dayTime / 24);
		}
	}
}
