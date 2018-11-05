using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

/*
	This class is a wrapper around PhotonNetwork and everything Photon.

	The reasoning is that to modulize the references so PhotonNetwork doesn't scatter
	everywhere throughout the code. If this were to be replaced by another networking
	modules it could be done easily by editing this class.
*/

namespace xyz.sharkle.CarSpawner {
	public class PhotonManager : MonoBehaviourPunCallbacks {

		List<string> MasterServerList;

		void Awake () {
			MasterServerList = new List<string>(PhotonNetwork.BestRegionSummaryInPreferences.Split(';')[2].Split(','));
		}

		// Returns a list of server code you could potentially connect.
		public List<string> GetListOfMasterServer () {
			return MasterServerList;
		}

		// Get the Default preferred master server that is cloestest to the client.
		public string GetPreferredMasterServer () {
			return PhotonNetwork.BestRegionSummaryInPreferences.Split(';')[0];
		}

		public void ConnectToMaster (string ServerCode, string PlayerName) {
			PhotonNetwork.NickName = PlayerName;
			PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = ServerCode;
			PhotonNetwork.ConnectUsingSettings();
		}

		public override void OnConnectedToMaster() {
			Debug.Log("Connected to: " +  PhotonNetwork.CloudRegion);
		}

	}
}
