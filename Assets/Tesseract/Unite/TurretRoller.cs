namespace TestProject{

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class TurretRoller : MonoBehaviour {
		public Transform selfTransform;

		[SerializeField]private float rotateTime=1f;
		[SerializeField]private Vector2 yAxleLimit;

		[SerializeField]private Transform xAxle;
		[SerializeField]private Transform yAxle;
		private Vector2 targetAngles;
		public Vector3 targetPoint;

		private bool correctAttack;
		private Vector3 modifier;
		private Vector2 vAngular;
		private float stopWatch=0.0f;
		private int turn=0;

		private RaycastHit hit;
		
		void Update () {
			Vector3 relativeTargetPosition = selfTransform.InverseTransformPoint(targetPoint);

			targetAngles.x = Mathf.Atan(relativeTargetPosition.y / relativeTargetPosition.z) * Mathf.Rad2Deg;
			targetAngles.y = Mathf.Atan(relativeTargetPosition.x / relativeTargetPosition.z) * Mathf.Rad2Deg;
			print(targetAngles.y);

			targetAngles.x = relativeTargetPosition.z > 0 ? targetAngles.x : 180 + targetAngles.x;
			targetAngles.y = relativeTargetPosition.z > 0 ? targetAngles.y : 180 + targetAngles.y;

			//xAxle.localEulerAngles = new Vector3(xAxle.localEulerAngles.x, 90, 0);
			yAxle.localEulerAngles = new Vector3(0, 180, yAxle.localEulerAngles.z);

			Mathf.SmoothDampAngle(0, targetAngles.x, ref vAngular.y, rotateTime);
			Mathf.SmoothDampAngle(0, targetAngles.y, ref vAngular.x, rotateTime);
			Rotate(vAngular.x, vAngular.y);

			if (yAxle.localEulerAngles.z < 180 && yAxle.localEulerAngles.z > yAxleLimit.x) {
				yAxle.localEulerAngles = new Vector3(0, 180, yAxleLimit.x);
			}
			if (yAxle.localEulerAngles.z > 180 && yAxle.localEulerAngles.z < yAxleLimit.y) {
				yAxle.localEulerAngles = new Vector3(0, 180, yAxleLimit.y);
			}
		}

		public void Rotate(float xValue, float yValue){
			xAxle.Rotate (Vector3.right * xValue * Time.deltaTime);
			yAxle.Rotate (Vector3.forward * yValue * Time.deltaTime);
		}
	}
}