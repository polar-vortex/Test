namespace TestProject{
	
	using UnityEngine;
	using System.Collections;

	public abstract class Cannon : MonoBehaviour {
		//public ObjectPool ammo;
		public float ammoSize;
		public float energyCost;

		protected float stopWatch;
		protected GameObject bulletSpawned;
		
		protected void Start () {
			stopWatch=0;
		}
		
		protected void Update () {
			stopWatch+=Time.deltaTime;
		}
		
		public abstract GameObject Fire(float accuracy=1);
		
		public abstract GameObject FireFrequently(float rate,float accuracy=1);
	}
}