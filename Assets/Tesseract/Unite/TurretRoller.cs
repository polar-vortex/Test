namespace TestProject{

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class TurretRoller : MonoBehaviour {
		public Transform selfTransform;
		[SerializeField]private Transform pointer;

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

		[SerializeField]private float iota=2;
		
		void Update () {

			pointer.LookAt(targetPoint);
			//pointer.localEulerAngles = -pointer.localEulerAngles;
			targetAngles.x = -pointer.localEulerAngles.y;
			targetAngles.y = -pointer.localEulerAngles.x;

			Mathf.SmoothDampAngle(xAxle.localEulerAngles.x, targetAngles.x, ref vAngular.x, rotateTime);
			Mathf.SmoothDampAngle(yAxle.localEulerAngles.x, targetAngles.y, ref vAngular.y, rotateTime);
			//print(xAxle.localEulerAngles.x + " " + targetAngles.x+" "+vAngular.x);

			if (targetAngles.x > 90 && targetAngles.x < 270) {
				vAngular.x = -vAngular.x;
			}

			if (Mathf.Abs(xAxle.localEulerAngles.x-targetAngles.x) <= iota) {
				vAngular.x = 0;
			}
			if (Mathf.Abs(yAxle.localEulerAngles.x-targetAngles.y) <= iota) {
				vAngular.y = 0;
			}

			Rotate(vAngular.x, vAngular.y);

			if (yAxle.localEulerAngles.x < 180 && yAxle.localEulerAngles.x > yAxleLimit.x) {
				yAxle.localEulerAngles = new Vector3(yAxleLimit.x, 0, 0);
			}
			if (yAxle.localEulerAngles.x > 180 && yAxle.localEulerAngles.x < yAxleLimit.y) {
				yAxle.localEulerAngles = new Vector3(yAxleLimit.y, 0, 0);
			}
		}

		public void Rotate(float xValue, float yValue){
			xAxle.Rotate (Vector3.right * xValue * Time.deltaTime);
			yAxle.Rotate (Vector3.right * yValue * Time.deltaTime);
		}
	}

}