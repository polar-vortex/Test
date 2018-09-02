namespace TestProject{

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.AI;

	[RequireComponent(typeof(NavMeshAgent))]

	public class Navigator : MonoBehaviour {
		[SerializeField]private Transform destination;
		[SerializeField]private NavMeshAgent navigation;
		[SerializeField]private Transform car;

		public float maxDistance;

		void Start(){
			navigation = GetComponent<NavMeshAgent>();
		}

		void Update () {
			navigation.destination = destination.position;
			navigation.isStopped = Vector3.Distance(transform.position, car.position) > maxDistance;
		}
	}

}