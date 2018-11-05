using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xyz.sharkle.CarSpawner {

	public class GameManager : MonoBehaviour {

		// References.
		// [HideInInspector]
		
		
		PhotonManager photonManager;

		// Reference setting... 
		void Awake () {
			photonManager = gameObject.AddComponent<PhotonManager>();
		}

		// Game Initialization...
		void Start () {
			photonManager.ConnectToMaster("us", "Player#1");
		}
		
		// Update is called once per frame
		// void Update () {
			
		// }
	}
}
