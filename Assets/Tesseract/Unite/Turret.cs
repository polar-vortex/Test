namespace TestProject{

	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;

	public class Turret : MonoBehaviour {

		[SerializeField]private TurretRoller targeting;
		[SerializeField]private Transform self;

		public float range=400;
		public float fireRate=2;
		[SerializeField]private LineRenderer line;

		private RaycastHit sensor;
		private RaycastHit hit2;
		//[SerializeField]private GameObject hitObject;
		//[SerializeField]private Cannon[] weapons;

		private float stopWatch=0.0f;

		public void Update () {
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out sensor, range);
			targeting.targetPoint = sensor.point;
			Physics.Raycast(line.transform.position, line.transform.forward, out hit2);
			line.SetPosition(1, hit2.point.z*Vector3.forward);
		}
		
		/*public void Fire(){
			foreach (Cannon c in weapons){
				GameObject bullet=c.FireFrequently (fireRate + Random.value,accuracy);
			}
		}*/
	}
}