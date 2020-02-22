using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StayupolKnights;

namespace Network
{
    public class NetworkRoomPipeline : MonoBehaviourPunCallbacks
    {
        [SerializeField] string m_fallBackLevel = "Menu";
        public FirstPersonPlayer PlayerPrefab;

        [HideInInspector]
        public FirstPersonPlayer LocalPlayer;
        public Transform PlayerSpawn;

        private void Start()
        {
            if (!PhotonNetwork.IsConnected)
            {
                LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(m_fallBackLevel));
                return;
            }
            FirstPersonPlayer.RefreshInstance(ref LocalPlayer, PlayerPrefab, PlayerSpawn);

        }

        void Update()
        {

        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            FirstPersonPlayer.RefreshInstance(ref LocalPlayer, PlayerPrefab, PlayerSpawn);
        }

    }
}