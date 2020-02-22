using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CanvasInputRelay : MonoBehaviourPunCallbacks
{
    //[SerializeField] Button m_masterButton;
    //[SerializeField] Button m_RoomButton;
    //[SerializeField] GameObject m_masterText;
    //[SerializeField] GameObject m_RoomText;
    //[SerializeField] InputField m_input;
    //[SerializeField] Text m_status;

    [SerializeField] Network.NetworkConnectionManager m_networkManager;

    [SerializeField] string m_sceneName = "Scene01";
    [SerializeField] TextMeshProUGUI m_head = null;
    [SerializeField] Button m_submit = null;
    [SerializeField] TextMeshProUGUI m_submitText = null;
    [SerializeField] TMP_InputField m_inputField = null;
    [SerializeField] TextMeshProUGUI m_inputPlaceHolder = null;
    [SerializeField] TextMeshProUGUI m_inputText = null;
    [SerializeField] TextMeshProUGUI m_statusText = null;


    private void Update()
    {
        //m_masterButton.gameObject.SetActive(!PhotonNetwork.IsConnected && !m_networkManager.ConnectingToMaster);
        //m_masterText.gameObject.SetActive(!PhotonNetwork.IsConnected && !m_networkManager.ConnectingToMaster);
        //m_RoomButton.gameObject.SetActive(PhotonNetwork.IsConnected && !m_networkManager.ConnectingToMaster && !m_networkManager.ConnectingToRoom);
        //m_RoomText.gameObject.SetActive(PhotonNetwork.IsConnected && !m_networkManager.ConnectingToMaster && !m_networkManager.ConnectingToRoom);

        m_submit.interactable = (!PhotonNetwork.IsConnected || !(m_networkManager.ConnectingToMaster || m_networkManager.ConnectingToRoom));
        m_submitText.text = (m_submit.interactable) ? (PhotonNetwork.IsConnected) ? "Join Room" : "Join Master" : "";

        if (!m_submit.interactable) m_inputField.text = "";
        m_inputField.interactable = (m_submit.interactable);
        m_inputPlaceHolder.text = (m_inputField.interactable) ? (PhotonNetwork.IsConnected) ? "Room Name" : "UserName" : "";

        m_statusText.text = "Status";
        m_statusText.text += (PhotonNetwork.IsConnected) ? (PhotonNetwork.InRoom) ? ": Connected to " + PhotonNetwork.CurrentRoom.Name + "" : ": Connected" : ": Disconnected";
        if (m_networkManager.ConnectingToMaster) m_statusText.text += ": Connecting To Master";
        if (m_networkManager.ConnectingToRoom) m_statusText.text += ": Connecting To Room";

        //m_status.text = "";
        //m_status.text += (PhotonNetwork.IsConnected) ? (PhotonNetwork.InRoom) ? "Connected to " + PhotonNetwork.CurrentRoom.Name + "\n" : "Connected!\n" : "Disconected\n";
        //if (m_networkManager.ConnectingToMaster) m_status.text += "Connecting To Master";
        //if (m_networkManager.ConnectingToRoom) m_status.text += "Connecting To Room";
        //}
    }

    public void Submit()
    {
        if(!PhotonNetwork.IsConnected)
        {
            m_networkManager.ConnectToMaster(m_inputText.text, m_networkManager.Version);
        }
        else
        {
            m_networkManager.ConnectToRoom(m_sceneName);
        }
    }

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene(m_sceneName);
    }


}
