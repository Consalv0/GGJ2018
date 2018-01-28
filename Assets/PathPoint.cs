using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour {
	public PathPoint next;
	public PathPoint behind;

	public float collisionRadius = 0.1F;
}
