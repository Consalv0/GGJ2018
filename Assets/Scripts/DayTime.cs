using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour {
	public Gradient skyColor;
	public Gradient lightColor;
	public Light sun, moon;
	public float yEuler;
	public float daySpeed;

	[Range(0, 24)]
	public float dayTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		dayTime += Time.unscaledDeltaTime / daySpeed;
		if (dayTime >= 24) dayTime = 0;
		sun.transform.localRotation = Quaternion.Euler(
			dayTime / 24 * 360, yEuler, 0);
		moon.transform.localRotation = Quaternion.Euler(
			dayTime / 24 * 360 - 200, yEuler + 30, 0);

		if (sun) {
			RenderSettings.ambientLight = skyColor.Evaluate(dayTime / 24);
			RenderSettings.fogColor = skyColor.Evaluate(dayTime / 24);
			Camera.main.backgroundColor = skyColor.Evaluate(dayTime / 24);
			RenderSettings.ambientSkyColor = lightColor.Evaluate(dayTime / 24);
			sun.color = lightColor.Evaluate(dayTime / 24);
			sun.intensity = Mathf.Pow(lightColor.Evaluate(dayTime / 24).grayscale, 2);
		}

		if (moon) {
			RenderSettings.ambientLight = skyColor.Evaluate(dayTime / 24);
			RenderSettings.fogColor = skyColor.Evaluate(dayTime / 24);
			Camera.main.backgroundColor = skyColor.Evaluate(dayTime / 24);
			RenderSettings.ambientSkyColor = lightColor.Evaluate(dayTime / 24);
			moon.color = lightColor.Evaluate(dayTime / 24);
			moon.intensity = 1 - Mathf.Pow(lightColor.Evaluate(dayTime / 24).grayscale, 2);
		}
	}
}
