using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    int numberOnDice;

    bool prokockano;
    bool playerOnStart;
    bool diceSix;
    bool playerOnBoard;
    bool morePlayersOnBoard;
    bool allPlayersInHouse;

    public Player player;
    GameObject[] playerClones;
    GameObject[] pathNodes;
    public Vector3[] playerClonesStartingPosition;


    Vector3 newPlayerFieldRed = new Vector3(0.397f, -0.945f, 1.923f);
    Vector3 newPlayerFieldGreen = new Vector3(-0.63f, -0.26f, 3.28f);
    Vector3 newPlayerFieldBlue = new Vector3(0.725f, 0.726f, 3.848f);
    Vector3 newPlayerFieldPurple = new Vector3(1.84f, 0.08f, 2.45f);

    private void Start()
    {
        prokockano = false;

        #region Referenciranje iz druge skripte
        GameObject GameplayDataInScene = GameObject.Find("GameplayData");
        GameplayData gameplayData = GameplayDataInScene.GetComponent<GameplayData>();


        playerClones = gameplayData.PlayerClone;
        playerClonesStartingPosition = gameplayData.charStartPos;
        pathNodes = gameplayData.PathNodes;
        #endregion

        allPlayersInHouse = true;
        for (int i = 4; i < 8; i++)
        {
            playerClones[i].GetComponent<CapsuleCollider>().enabled = false;
        }

        StartCoroutine(RedTurn());

    }

    public void OnButtonClick()
    {
        numberOnDice = Random.Range(1, 7);
        numberOnDice = 6; ////////////////////////////
        Debug.Log(numberOnDice);
        prokockano = true;
    }
    private IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(1f);
    }

    private int DistanceNode(int currentNode, int numberOnDice)
    {
        return (currentNode + numberOnDice - 1);
    }

    private void RoundCheck(string colorTurn)
    {
        if (numberOnDice == 6) { diceSix = true; }
        if (colorTurn == "Red")
        {
            for (int i = 4; i < 8; i++)
            {
                if (playerClones[i].transform.position == newPlayerFieldRed)
                {
                    playerOnStart = true;
                }else playerOnStart = false;
                int playerCounter = 0;
                if (playerClones[i].transform.position != playerClonesStartingPosition[i])
                {
                    playerCounter++;
                    playerOnBoard = true;
                }
                if (playerCounter > 1)
                {
                    morePlayersOnBoard = true;
                }
                if (playerCounter == 4)
                {
                    allPlayersInHouse = true;
                } else allPlayersInHouse = false;

            }
        }
        else if (colorTurn == "Blue")
        {
            {
                for (int i = 0; i < 4; i++)
                {
                    if (playerClones[i].transform.position == newPlayerFieldBlue)
                    {
                        playerOnStart = true;
                    }
                    int playerCounter = 0;
                    if (playerClones[i].transform.position != playerClonesStartingPosition[i])
                    {
                        playerCounter++;
                        playerOnBoard = true;
                    }
                    if (playerCounter > 1)
                    {
                        morePlayersOnBoard = true;
                    }
                }
            }
        }
        else if (colorTurn == "Green")
        {
            {
                for (int i = 12; i < 16; i++)
                {
                    if (playerClones[i].transform.position == newPlayerFieldGreen)
                    {
                        playerOnStart = true;
                    }
                    int playerCounter = 0;
                    if (playerClones[i].transform.position != playerClonesStartingPosition[i])
                    {
                        playerCounter++;
                        playerOnBoard = true;
                    }
                    if (playerCounter > 1)
                    {
                        morePlayersOnBoard = true;
                    }
                }
            }
        }
        else if (colorTurn == "Purple")
        {
            {
                for (int i = 8; i < 12; i++)
                {
                    if (playerClones[i].transform.position == newPlayerFieldPurple)
                    {
                        playerOnStart = true;
                    }
                    int playerCounter = 0;
                    if (playerClones[i].transform.position != playerClonesStartingPosition[i])
                    {
                        playerCounter++;
                        playerOnBoard = true;
                    }
                    if (playerCounter > 1)
                    {
                        morePlayersOnBoard = true;
                    }
                }
            }
        }

    }

    private IEnumerator WaitForPlayerSelection()
    {
        yield return new WaitWhile(() => player.clicked == false);
        player.clicked = false;
    }

    private IEnumerator RedTurn()
    {
        Debug.Log("Crveni na redu!!");
        RoundCheck("Red");
        Debug.Log("Prokockaj!");

        yield return new WaitWhile(() => prokockano == false);
        StartCoroutine(WaitingTime());
        int currentNode = 0;
        int startingNode = 0;
        //StartCoroutine(WaitForPlayerSelection());
        
        if (diceSix)
        {
            if (!playerOnStart)
            {
                for (int i = 4; i < 8; i++)
                {
                    if (playerClones[i].transform.position != newPlayerFieldRed)
                    {
                        //ako mu pozicija nije početno polje (za kretanje), možemo ga pomaknuti
                        playerClones[i].GetComponent<CapsuleCollider>().enabled = true;
                        if (playerClones[i].transform.position == playerClonesStartingPosition[i])
                        {
                            //ako se nalazi u kučici prilikom klika ide na početno polje
                            playerClones[i].transform.position = newPlayerFieldRed;
                        }
                        else 
                        {
                            //idi za 6 polja naprijed 
                        }
                    }

                }
            }
            if (playerOnStart)
            {
                for (int i = 4; i < 8; i++)
                {
                    if (playerClones[i].transform.position == playerClonesStartingPosition[i])
                    {
                        //ako je igrač u kučici ne možemo ga selektirati jer je netko na startu
                        playerClones[i].GetComponent<CapsuleCollider>().enabled = false;
                    }
                    //ostale možemo selektirati, idi 6 polja naprijed
                    else playerClones[i].GetComponent<CapsuleCollider>().enabled = true;
                }
            }

            prokockano = false;
            StartCoroutine(RedTurn());
        }

        else if (!diceSix)
        {
            if (!playerOnBoard & !playerOnStart) { GreenTurn(); }
            if (playerOnStart & !morePlayersOnBoard)
            {
                for (int i = 4; i < 8; i++)
                {
                    if (playerClones[i].transform.position != newPlayerFieldRed)
                    {
                        playerClones[i].GetComponent<CapsuleCollider>().enabled = false;
                    }
                    else
                    {
                        Debug.Log("I am  on a start position: ", playerClones[i]);
                        StartCoroutine(WaitForPlayerSelection());
                        if (diceSix) { StartCoroutine(RedTurn()); }
                        //Pritisni i idem za toliko polja unaprijed, ako je 6 bacam ponovno
                    }
                }
            }

            currentNode += DistanceNode(currentNode, numberOnDice);
            playerClones[4].transform.position = pathNodes[currentNode].transform.position;
            prokockano = false;
            GreenTurn();
        }
    }
        private void GreenTurn()
        {
            RoundCheck("Green");
            Debug.Log("Zeleni na redu!!");
            StartCoroutine(WaitingTime());
            OnButtonClick();
            StartCoroutine(WaitingTime());
            Debug.Log("Bacio!!");

            if (numberOnDice == 6)
            {
                playerClones[12].transform.position = newPlayerFieldGreen;
                prokockano = false;
                GreenTurn();
            }
            else
            {
                prokockano = false;
                BlueTurn();

            }
        }
        private void BlueTurn()
        {
            RoundCheck("Blue");
            Debug.Log("Plavi na redu!!");
            StartCoroutine(WaitingTime());
            OnButtonClick();
            StartCoroutine(WaitingTime());
            Debug.Log("Bacio!!");

            if (numberOnDice == 6)
            {
                playerClones[0].transform.position = newPlayerFieldBlue;
                prokockano = false;
                BlueTurn();
            }
            else
            {
                prokockano = false;
                PurpleTurn();
            }

        }
        private void PurpleTurn()
        {
            RoundCheck("Purple");
            Debug.Log("Ljubicasti na redu!!");
            StartCoroutine(WaitingTime());
            OnButtonClick();
            StartCoroutine(WaitingTime());
            Debug.Log("Bacio!!");

            if (numberOnDice == 6)
            {
                playerClones[8].transform.position = newPlayerFieldPurple;
                prokockano = false;
                PurpleTurn();
            }
            else
            {
                prokockano = false;
                StartCoroutine(RedTurn());
            }
        }
    } 
