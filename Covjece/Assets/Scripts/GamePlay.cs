using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    int numberOnDice;
    int round = 0;
    bool prokockano;
    bool diceSix;

    bool playerInStartHouse;
    public bool playerOnStart;
    bool playerOnBoard;
    bool playerAtFinish;

    GameObject[] playerClones;
    GameObject[] pathNodes;
    public Vector3[] playerClonesStartingPosition;
    PlayerClass playerClass;
    GameObject player;
    //public Vector3[] ostaliIgraci;
    //public int[] ostaliIgraci;


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
        StartCoroutine(RedTurn());
    }

    public void OnButtonClick()
    {
        numberOnDice = Random.Range(1, 7);
        //numberOnDice = 6;
        Debug.Log(numberOnDice);
        prokockano = true;
    }
    private IEnumerator WaitingTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private int DistanceNode(int currentNode, int numberOnDice)
    {

        return (currentNode + numberOnDice - 1);
    }

    private void RoundCheck(string colorTurn)
    {
        if (numberOnDice == 6) { diceSix = true; } else { diceSix = false; }
        if (colorTurn == "Red")
        {
            for (int i = 4; i < 8; i++)
            {
                if (playerClones[i].GetComponent<PlayerClass>().transform.position == newPlayerFieldRed)
                { //ako je na startnoj poziciji
                    playerClones[i].GetComponent<PlayerClass>().playerInStartHouse = false;
                    playerOnStart = true;
                    playerClones[i].GetComponent<PlayerClass>().playerOnBoard = false;
                    playerClones[i].GetComponent<PlayerClass>().playerAtFinish = false;
                }
                if (playerClones[i].GetComponent<PlayerClass>().transform.position == playerClonesStartingPosition[i])
                { //ako je u kučici
                    playerClones[i].GetComponent<PlayerClass>().playerInStartHouse = true;
                    playerClones[i].GetComponent<PlayerClass>().playerOnBoard = false;
                    playerClones[i].GetComponent<PlayerClass>().playerAtFinish = false;
                }
                //if(){} ako je na finishu
                else if (playerClones[i].GetComponent<PlayerClass>().transform.position != newPlayerFieldRed & playerClones[i].GetComponent<PlayerClass>().transform.position != playerClonesStartingPosition[i])
                {//DODATI I AKO NIJE NA FINISHU, AKO NIJE NIGDJE DRUGDJE ONDA JE NA PLOČI
                    playerClones[i].GetComponent<PlayerClass>().playerInStartHouse = false;
                    playerClones[i].GetComponent<PlayerClass>().playerOnBoard = true;
                    playerClones[i].GetComponent<PlayerClass>().playerAtFinish = false;
                }
            }
        }
        else if (colorTurn == "Blue")
        {
            for (int i = 0; i < 4; i++)
            {
                if (playerClones[i].transform.position == newPlayerFieldRed)
                {
                    playerInStartHouse = false;
                    playerOnStart = true;
                    playerOnBoard = false;
                    playerAtFinish = false;
                }
                if (playerClones[i].transform.position == playerClonesStartingPosition[i])
                {
                    playerInStartHouse = true;
                    playerOnStart = false;
                    playerOnBoard = false;
                    playerAtFinish = false;
                }
            }
        }
        else if (colorTurn == "Green")
        {
            for (int i = 12; i < 16; i++)
            {
                if (playerClones[i].transform.position == newPlayerFieldRed)
                {
                    playerInStartHouse = false;
                    playerOnStart = true;
                    playerOnBoard = false;
                    playerAtFinish = false;
                }
                if (playerClones[i].transform.position == playerClonesStartingPosition[i])
                {
                    playerInStartHouse = true;
                    playerOnStart = false;
                    playerOnBoard = false;
                    playerAtFinish = false;
                }
            }
        }
        else if (colorTurn == "Purple")
        {
            for (int i = 8; i < 12; i++)
            {
                if (playerClones[i].transform.position == newPlayerFieldRed)
                {
                    playerInStartHouse = false;
                    playerOnStart = true;
                    playerOnBoard = false;
                    playerAtFinish = false;
                }
                if (playerClones[i].transform.position == playerClonesStartingPosition[i])
                {
                    playerInStartHouse = true;
                    playerOnStart = false;
                    playerOnBoard = false;
                    playerAtFinish = false;
                }
            }
        }

    }

    private IEnumerator RedTurn()
    {
        Debug.Log("Crveni na redu!!");
        Debug.Log("Prokockaj!");
        yield return new WaitWhile(() => prokockano == false);

        RoundCheck("Red");
        StartCoroutine(WaitingTime(1));
        for (int i = 4; i < 8; i++)
        {
            if (diceSix)
            {
                //ako dobije 6 i nema igrača na startnom polju može pomaknuti bilo kojeg igrača
                if (playerOnStart != true)
                {
                    Debug.Log("Izaberi igrača!");
                    yield return new WaitForSeconds(3f);

                    if (playerClones[i].GetComponent<PlayerClass>().playerInStartHouse == true & playerClones[i].GetComponent<PlayerClass>().clicked)
                    {
                        //ako je u kučici,ako kliknemo na njega i ako nitko nije na startnoj poziciji

                        playerClones[i].transform.position = newPlayerFieldRed;
                        playerClones[i].GetComponent<PlayerClass>().currentNode = -1;
                        //ako je kliknut i na startu node mu je -1
                        playerClones[i].GetComponent<PlayerClass>().playerInStartHouse = false;
                        playerOnStart = true;
                        playerClones[i].GetComponent<PlayerClass>().clicked = false;
                        //ako su tijekom toga u kučici stavi na startnu poziciju i postavi da je mjesto zauzeto
                    }
                }
                else if (playerOnStart)
                {
                    Debug.Log("Izaberi igrača!");
                    yield return new WaitForSeconds(3f);

                    if (playerClones[i].GetComponent<PlayerClass>().clicked)
                    {
                        playerClones[i].transform.position = pathNodes[5].transform.position;
                        Debug.Log("Idem 6 polja naprijed!");
                        playerOnStart = false;
                        playerOnBoard = true;
                    }
                }
                prokockano = false;
                yield return new WaitForSeconds(1f);
                StartCoroutine(RedTurn());
            }
            else
            {
                if (playerOnStart || playerClones[i].GetComponent<PlayerClass>().playerOnBoard)
                {
                    Debug.Log("Nije 6");
                    Debug.Log("Izaberi igrača!");
                    yield return new WaitForSeconds(3f);

                    if (playerClones[i].GetComponent<PlayerClass>().clicked)
                    {
                        playerClones[i].GetComponent<PlayerClass>().currentNode += numberOnDice;
                        Debug.Log(playerClones[i].GetComponent<PlayerClass>().currentNode);
                        playerClones[i].transform.position = pathNodes[playerClones[i].GetComponent<PlayerClass>().currentNode].transform.position;
                    }
                    prokockano = false;
                    GreenTurn();
                }
                else if (!playerOnStart & playerClones[i].GetComponent<PlayerClass>().playerOnBoard == false)
                {
                    GreenTurn();
                }
            }
        }
    }
    private void GreenTurn()
    {
        //RoundCheck("Green");
        //Debug.Log("Zeleni na redu!!");
        //OnButtonClick();
        //Debug.Log("Bacio!!");
        //RoundCheck("Green");

        //if (diceSix)
        //{
        //    for (int i = 12; i < 15; i++)
        //    {
        //        //ako dobije 6 i nema igrača na startnom polju može pomaknuti bilo kojeg igrača
        //        if (playerOnStart != true)
        //        {
        //            if (playerClones[i].GetComponent<PlayerClass>().playerInStartHouse == true)
        //            {
        //                //ako je u kučici,ako kliknemo na njega i ako nitko nije na startnoj poziciji

        //                playerClones[i].transform.position = newPlayerFieldGreen;
        //                playerClones[i].GetComponent<PlayerClass>().currentNode = 9;
        //                //ako je kliknut i na startu node mu je 9
        //                playerClones[i].GetComponent<PlayerClass>().playerInStartHouse = false;
        //                playerOnStart = true;
        //                //ako su tijekom toga u kučici stavi na startnu poziciju i postavi da je mjesto zauzeto
        //            }
        //        }
        //        else if (playerOnStart)
        //        {
        //            if (playerClones[i].GetComponent<PlayerClass>().clicked)
        //            {
        //                playerClones[i].transform.position = pathNodes[14].transform.position;
        //                playerOnStart = false;
        //                playerOnBoard = true;
        //            }
        //        }
        //    }
        //    prokockano = false;
        //    GreenTurn();
        //}
        //else
        //{
        //    for (int i = 12; i < 15; i++)
        //    {
        //        if (playerOnStart || playerClones[i].GetComponent<PlayerClass>().playerOnBoard)
        //        {
        //            playerClones[i].GetComponent<PlayerClass>().currentNode += numberOnDice;
        //            Debug.Log(playerClones[i].GetComponent<PlayerClass>().currentNode);
        //            playerClones[i].transform.position = pathNodes[playerClones[i].GetComponent<PlayerClass>().currentNode].transform.position;
        //        }
        //        else if (!playerOnStart & playerClones[i].GetComponent<PlayerClass>().playerOnBoard==false)
        //        {
        //            BlueTurn();
        //        }
        //    }
            prokockano = false;
            BlueTurn();
        //}
    }
    
            
            //if (numberOnDice == 6)
            //{
            //playerClones[12].transform.position = newPlayerFieldGreen;
            //prokockano = false;
            //GreenTurn();
            //}
            //else
            //{
            //prokockano = false;
            //BlueTurn();
    //    }
    //}
    private void BlueTurn()
    {
        RoundCheck("Blue");
        Debug.Log("Plavi na redu!!");
        StartCoroutine(WaitingTime(1));
        OnButtonClick();
        StartCoroutine(WaitingTime(1));
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
        StartCoroutine(WaitingTime(1));
        OnButtonClick();
        StartCoroutine(WaitingTime(1));
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
