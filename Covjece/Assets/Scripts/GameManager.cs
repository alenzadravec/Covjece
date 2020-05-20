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
        if (playerList[activePlayer].playerType == Entity.PlayerTypes.CPU)
        {
            switch (state)
            {
                case States.ROLL_DICE:
                    {
                        StartCoroutine(RollDiceDelay());
                        state = States.WAITING;
                    }
                    break;

                case States.WAITING:
                    break;

                case States.SWITCH_PLAYER:
                    break;
            }
        }
    }
    void RollDice()
    {
        //int diceNumber = Random.Range(1, 7);
        int diceNumber = 6;

        if (diceNumber == 6)
        {
            Debug.Log("Kockica: " + diceNumber);
            //provjera da li je startna pozicija prazna
            CheckStartNode(diceNumber);
        }
        else if (diceNumber < 6)
        {
            Debug.Log("Kockica: " + diceNumber);
            //da li treba koga izbaciti
        }
    }
    IEnumerator RollDiceDelay()
    {
        yield return new WaitForSeconds(2f);
        RollDice();
    }

    void CheckStartNode(int diceNumber)

    {
        //je li itko na startu
        bool startNodeFull = false;

        Debug.Log(startNodeFull);

        for (int i = 0; i < playerList[activePlayer].players.Length; i++)
        {
            if (playerList[activePlayer].players[i].currentNode == playerList[activePlayer].players[i].startNode)
            {
                startNodeFull = true;
                break;
            }
        }
        if (startNodeFull)
        {
            //pomakni igrača

            Debug.Log("START node pun");
        }
        else
        {
            for (int i = 0; i < playerList[activePlayer].players.Length; i++)
            {
                if (!playerList[activePlayer].players[i].ReturnIsOut())
                {
                    //ako je jedan u bazi ide van
                    playerList[activePlayer].players[i].LeaveBase();
                    state = States.WAITING;
                    return;
                }
            }
            ////
        }
    }

    void MovePlayer(int diceNumber)
    {
        List<PlayerClass> movablePlayers = new List<PlayerClass>();
        List<PlayerClass> moveKickPlayers = new List<PlayerClass>();

        //napuniti liste
        for (int i = 0; i < playerList[activePlayer].players.Length; i++)
        {
            if (playerList[activePlayer].players[i].ReturnIsOut())
            {
                //provjeri moguć izbačaj
                if (playerList[activePlayer].players[i].CheckPossibleKick(playerList[activePlayer].players[i].stoneId, diceNumber))
                {
                    moveKickPlayers.Add(playerList[activePlayer].players[i]);
                    continue;
                }
                //provjeri moguć novi položaj
                if (playerList[activePlayer].players[i].CheckPossibleMove(diceNumber))
                {
                    movablePlayers.Add(playerList[activePlayer].players[i]);
                }
            }
        }
        //ako je moguće ruši
        if (moveKickPlayers.Count > 0)
        {
            int num = Random.Range(0, moveKickPlayers.Count);
            moveKickPlayers[num].StartTheMove(diceNumber);
            state = States.WAITING;
            return;
        }
        //ako je moguće pomakni se
        if (movablePlayers.Count > 0)
        {
            int num = Random.Range(0, moveKickPlayers.Count);
            moveKickPlayers[num].StartTheMove(diceNumber);
            state = States.WAITING;
            return;
        }
        //ništa nije moguće
        //promjena igrača
        Debug.Log("Promjenilo igrača!");
    }
}
