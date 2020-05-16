using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [System.Serializable]
    public class Entity
    {
        public string playerName;
        public PlayerClass[] players;
        public bool hasTurn;
        public enum PlayerTypes
        {
            HUMAN,
            CPU,
            NO_PLAYER
        }
        public PlayerTypes playerType;
        public bool hasWon;
    }
    public List<Entity> playerList = new List<Entity>();

    public enum States
    {
        WAITING,
        ROLL_DICE,
        SWITCH_PLAYER
    }
    public States state;

    public int activePlayer;
    bool switchingPlayer;

    //INPUT
    //GAMEOBJ ZA BUTTON
    //INT DICEROLLED

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        switch (state)
        {
            case States.ROLL_DICE:
                break;

            case States.WAITING:
                break;

            case States.SWITCH_PLAYER:
                break;
        }
    }
}
