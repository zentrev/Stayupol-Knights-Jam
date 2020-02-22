using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Network
{
    public class NetworkRoomPipeline : MonoBehaviourPunCallbacks
    {
        [SerializeField] string m_fallBackLevel = "Menu";
        public Agent.NetworkedAgentMotor PlayerPrefab;

        [HideInInspector]
        public Agent.NetworkedAgentMotor LocalPlayer;
        public Transform PlayerSpawn;

        private void Start()
        {
            if (!PhotonNetwork.IsConnected)
            {
                GameManager.Instance.LoadLevel(m_fallBackLevel, GameManager.eSet.MENU);
                return;
            }
            Agent.NetworkedAgentMotor.RefreshInstance(ref LocalPlayer, PlayerPrefab, PlayerSpawn);

        }

        void Update()
        {

        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            Agent.NetworkedAgentMotor.RefreshInstance(ref LocalPlayer, PlayerPrefab, PlayerSpawn);
        }

    }
}