using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StayupolKnights;
using Photon.Pun;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] bool m_runningGame = false;
    [SerializeField] float m_playTime = 3.0f;
    [SerializeField] float m_fireTime = 3.0f;

    public List<FirstPersonPlayer> players = new List<FirstPersonPlayer>();

    public bool m_playing = false;
    private float m_gameTicker = 0.0f;

    void Start()
    {
        if (!PhotonNetwork.IsMasterClient) Destroy(this);
    }
    
    void Update()
    {
        if(m_runningGame)
        {
            m_gameTicker += Time.deltaTime;

            if(m_playing && m_gameTicker >= m_playTime)
            {
                m_gameTicker = 0;
                m_playing = !m_playing;
                foreach (FirstPersonPlayer player in players)
                {
                    player.FreezePlayer(true);
                }

            }
            else if(!m_playing && m_gameTicker >= m_fireTime)
            {
                m_gameTicker = 0;
                m_playing = !m_playing;
                foreach (FirstPersonPlayer player in players)
                {
                    player.FreezePlayer(false);
                }

            }

        }
    }
}
