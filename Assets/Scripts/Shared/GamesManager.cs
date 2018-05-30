using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesManager{

    public event System.Action<Player> OnLocalPlayerJoined;
    private GameObject gamesObject;

    private static GamesManager m_Instance;
    public static GamesManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GamesManager();
                m_Instance.gamesObject = new GameObject("GamesManager");
                m_Instance.gamesObject.AddComponent<InputController>();
                m_Instance.gamesObject.AddComponent<Timer>();
                m_Instance.gamesObject.AddComponent<Respawner>();
            }
            return m_Instance;
        }
    }

    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
            {
                m_InputController = 
                    gamesObject.GetComponent<InputController>();
            }
            return m_InputController;
        }
    }

    private Player m_LocalPlayer;
    public Player LocalPlayer
    {
        get
        {
            return m_LocalPlayer;
        }
        set
        {
            m_LocalPlayer = value;
            if(OnLocalPlayerJoined != null)
            {
                OnLocalPlayerJoined(m_LocalPlayer);
            }
        }
    }

    private Timer m_Timer;
    public Timer Timer
    {
        get
        {
            if (m_Timer == null)
            {
                m_Timer =
                    gamesObject.GetComponent<Timer>();
            }
            return m_Timer;
        }
    }

    private Respawner m_Respawner;
    public Respawner Respawner
    {
        get
        {
            if (m_Respawner == null)
            {
                m_Respawner =
                    gamesObject.GetComponent<Respawner>();
            }
            return m_Respawner;
        }
    }
}
