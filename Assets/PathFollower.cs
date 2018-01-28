using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {
	public PathPoint target;
	public float speed = 5F;
	public float groundDist = 1F;
	public float frontDist = 100F;
	RaycastHit hit;
	Vector3 leftEye;
	Vector3 rightEye;
	Vector3 moveDir;
	Vector3 newMoveDir;

	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate () {
		if (target == null) {
			moveDir = Vector3.zero;
			return;
		}

		moveDir = target.gameObject.transform.position - transform.position;
		moveDir.y = 0;
		leftEye = Quaternion.Euler(0, 30, 0) * moveDir;
		rightEye = Quaternion.Euler(0, -30, 0) * moveDir;
		int hits = 0;
		newMoveDir = Vector3.zero;
		if (Physics.Raycast(transform.position, leftEye, out hit, frontDist)) {
			hits++;
			newMoveDir += Vector3.Reflect(moveDir, hit.normal);
		}
		if (Physics.Raycast(transform.position, rightEye, out hit, frontDist)) {
			hits++;
			newMoveDir += Vector3.Reflect(moveDir, hit.normal);
		}
		moveDir += newMoveDir;

		if (moveDir.magnitude <= target.collisionRadius) {
			target = target.next;
		}

		transform.position += moveDir.normalized * speed * Time.fixedDeltaTime;
		if (Physics.Raycast(transform.position, Vector3.down, out hit, 100)) {
			transform.position = hit.point + Vector3.up * groundDist;
		} else {
			transform.position += Physics.gravity * Time.fixedDeltaTime;
		}
	}

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.black;
		Gizmos.DrawRay(transform.position, moveDir);
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position, leftEye);
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, rightEye);
		Gizmos.color = Color.black;
		Gizmos.DrawLine(transform.position + Vector3.down * groundDist, transform.position);
		Gizmos.DrawLine(transform.position + Vector3.down * groundDist, transform.position);
	}
}
