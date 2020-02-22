using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Network
{
    public class NetworkConnectionManager : MonoBehaviourPunCallbacks
    {
        public bool ConnectingToMaster = false;
        public bool ConnectingToRoom  = false;
        public string Version = "V1";

        #region Master

        public void ConnectToMaster(string playerName, string gameVersion)
        {
            ConnectingToMaster = true;

            PhotonNetwork.OfflineMode = false;
            PhotonNetwork.NickName = playerName;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            ConnectingToMaster = false;
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            ConnectingToMaster = false;
            ConnectingToRoom = false;
            Debug.Log(cause);
        }
        #endregion

        #region Room
        /// <summary>
        /// Connects To Room with Given Name, if no name is given or the name is null it will connect to a random room
        /// </summary>
        /// <param name="roomName">Room to Connect To</param>
        //PhotonNetwork.CreateRoom("Peter's Game 1"); //Create a specific Room - Error: OnCreateRoomFailed
        //PhotonNetwork.JoinRoom("Peter's Game 1");   //Join a specific Room   - Error: OnJoinRoomFailed  
        //PhotonNetwork.JoinRandomRoom();               //Join a random Room     - Error: OnJoinRandomRoomFailed  
        public void ConnectToRoom(string roomName = null)
        {
            if (!PhotonNetwork.IsConnected) return;
            ConnectingToRoom = true;
            if (roomName != null)
            {
                PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = 20 }, TypedLobby.Default);
            }
            else
            {
                PhotonNetwork.JoinRandomRoom();
            }

        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            ConnectingToRoom = false;
            Debug.Log("Master: " + PhotonNetwork.IsMasterClient+ " | RoomName: " + PhotonNetwork.CurrentRoom.Name +" | Players In Room: " + PhotonNetwork.CurrentRoom.PlayerCount);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            //create a room with name of null
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);
            Debug.LogWarning(message);
            ConnectingToRoom = false;
        }

        #endregion
    }
}