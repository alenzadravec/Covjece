using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    int numberOnDice;
    bool prokockano;
    bool diceSix;

    bool playerInStartHouse;
    bool playerOnStart;
    bool playerOnBoard;
    bool playerAtFinish;

    GameObject[] playerClones;
    GameObject[] pathNodes;
    public Vector3[] playerClonesStartingPosition;
    PlayerClass playerClass;
    GameObject player;
    //public Vector3[] ostaliIgraci;
    //public int[] ostaliIgraci;


    Vector3 newPlayerFieldRed = new Vector3(0.397f,-0.945f,1.923f);
    Vector3 newPlayerFieldGreen = new Vector3(-0.63f,-0.26f,3.28f);
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
        numberOnDice = 6;
        Debug.Log(numberOnDice);
        prokockano = true;
    }
    private IEnumerator WaitingTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private int DistanceNode(int currentNode, int numberOnDice)
    {

        return (currentNode + numberOnDice-1);
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
                    playerClones[i].GetComponent<PlayerClass>().playerInStartHouse = false;
                    playerClones[i].GetComponent<PlayerClass>().playerOnStart = true;
                    playerClones[i].GetComponent<PlayerClass>().playerOnBoard = false;
                    playerClones[i].GetComponent<PlayerClass>().playerAtFinish = false;
                }
                if (playerClones[i].transform.position == playerClonesStartingPosition[i])
                {
                    playerClones[i].GetComponent<PlayerClass>().playerInStartHouse = true;
                    playerClones[i].GetComponent<PlayerClass>().playerOnStart = false;
                    playerClones[i].GetComponent<PlayerClass>().playerOnBoard = false;
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
           

        if (diceSix)
        {
            for (int i = 4; i < 8; i++)
            {
                //ako dobije 6 i nema igrača na startnom polju može pomaknuti bilo kojeg igrača
                if (playerClones[i].GetComponent<PlayerClass>().playerOnStart != true)
                {
                    playerClones[i].GetComponent<CapsuleCollider>().enabled = true;
                    Debug.Log("Izaberi igrača!");

                    yield return new WaitForSeconds(3f);

                    if (playerClones[i].GetComponent<PlayerClass>().playerInStartHouse == true & playerClones[i].GetComponent<PlayerClass>().clicked)
                    {
                        yield return new WaitForSeconds(1);
                        playerClones[i].transform.position = newPlayerFieldRed;
                        playerClones[i].GetComponent<PlayerClass>().clicked = false;
                        yield return new WaitForSeconds(1);
                        //ako su tijekom toga u kučici stavi na startnu poziciju

                    }
                    else if (playerClones[i].GetComponent<PlayerClass>().playerInStartHouse == true & playerClones[i].GetComponent<PlayerClass>().clicked)
                    {
                        //currentNode += DistanceNode(currentNode, numberOnDice);
                        //playerClones[i].transform.position = pathNodes[currentNode].transform.position; //idi 6 polja naprijed
                    }
                }
            }
            prokockano = false;
            StartCoroutine(RedTurn());
        }
        //    else
        //    {
        //        currentNode += DistanceNode(currentNode,numberOnDice);
        //        playerClones[4].transform.position = pathNodes[currentNode].transform.position;
        //        prokockano = false;
        //        GreenTurn();
        //}
    }
    private void GreenTurn()
    {
            RoundCheck("Green");
            Debug.Log("Zeleni na redu!!");
            StartCoroutine(WaitingTime(1));
            OnButtonClick();
            StartCoroutine(WaitingTime(1));  
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
