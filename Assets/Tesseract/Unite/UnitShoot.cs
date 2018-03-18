namespace TestProject{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UnitShoot : MonoBehaviour {
        [SerializeField]private GameObject shootTrajectory;
		[SerializeField]private GameObject sparkPrefab;
        [SerializeField]private float trajectoryLasts;
		[SerializeField]private Transform hitPoint;
        private float stopWatch;
        private bool counting;

		[SerializeField]private float shootRate;
		private float shootStopWatch;

		[SerializeField]private float force;

		private RaycastHit hit;
		private GameObject objectHit;
    	
    	// Update is called once per frame
    	void Update () {
            if (Input.GetMouseButtonDown(0)) {
                Shoot();
            }
			if (Input.GetMouseButton(0)) {
				AutoShoot();
			}

            if (counting) {
                stopWatch += Time.deltaTime;
                if (stopWatch >= trajectoryLasts) {
                    stopWatch = 0;
                    counting = false;
                }
            }
			shootTrajectory.SetActive(counting);
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
				objectHit = hit.collider.gameObject;
				hitPoint.position = hit.point;
			} else {
				objectHit = null;
				hitPoint.position = transform.TransformPoint(Vector3.forward * 20);
			}
        }

        public void Shoot(){
            stopWatch = 0;
            counting = true;
			if (objectHit) {
				GameObject.Instantiate(sparkPrefab, hitPoint.position, transform.rotation);
				if (objectHit.GetComponent<Rigidbody>()) {
					objectHit.GetComponent<Rigidbody>().AddExplosionForce(force, hit.point, 10);
				}
			}
        }

		public void AutoShoot(){
			shootStopWatch += Time.deltaTime;
			if (shootStopWatch >= shootRate) {
				Shoot();
				shootStopWatch = 0;
			}
		}
    }

}
