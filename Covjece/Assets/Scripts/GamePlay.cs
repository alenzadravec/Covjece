using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    int numberOnDice;

    bool redPlayersOnStartingPosition;
    bool bluePlayersOnStartingPosition=true;
    bool greenPlayersOnStartingPosition=true;
    bool purplePlayersOnStartingPosition=true;

    bool redPlayersTurn;
    bool greenPlayersTurn;
    bool bluePlayersTurn;
    bool purplePlayersTurn;

    bool prokockano;
    GameObject[] playerClones;

    Vector3 newPlayerFieldRed = new Vector3(0.397f,-0.945f,1.923f);
    Vector3 newPlayerFieldGreen = new Vector3(0,0,0);
    Vector3 newPlayerFieldBlue = new Vector3(0, 0, 0);
    Vector3 newPlayerFieldPurple = new Vector3(0, 0, 0);

    private void Start()
    {
        redPlayersOnStartingPosition = true;
        redPlayersTurn = true;
        greenPlayersTurn = false;
        bluePlayersTurn = false;
        purplePlayersTurn = false;
        prokockano = false;

        #region Referenciranje iz druge skripte
        GameObject GameplayDataInScene = GameObject.Find("GameplayData");
        GameplayData gameplayData = GameplayDataInScene.GetComponent<GameplayData>();
        playerClones = gameplayData.PlayerClone;
        #endregion

    }

    public void OnButtonClick()
    {
        numberOnDice = Random.Range(1, 7);
        Debug.Log(numberOnDice);
        prokockano = true;
    }

    private IEnumerator RedTurn()
    {
            Debug.Log("Crveni na redu!!");
            if (redPlayersOnStartingPosition)
            {
                Debug.Log("Prokockaj!");
                yield return new WaitWhile(() => prokockano == false);
            }

            if (numberOnDice == 6)
            {
                playerClones[4].transform.position = newPlayerFieldRed;
                prokockano = false;
            }
            else
            {
                prokockano = false;
                redPlayersTurn = false;
                bluePlayersTurn = false;
                purplePlayersTurn = false;
                greenPlayersTurn = true;
                
            yield break;
        }
    }
    private IEnumerator GreenTurn()
    {
            Debug.Log("Zeleni na redu!!");
            if (greenPlayersOnStartingPosition)
            {
                Debug.Log("Prokockaj!");
                yield return new WaitWhile(() => prokockano == false);
            }

            if (numberOnDice == 6)
            {
                playerClones[12].transform.position = newPlayerFieldGreen;
            prokockano = false;
        }
            else
            {
            prokockano = false;
            redPlayersTurn = false;
            greenPlayersTurn = false;
            purplePlayersTurn = false;
            bluePlayersTurn = true;
            yield break;
        }
        }
    private IEnumerator BlueTurn()
    {
        Debug.Log("Plavi na redu!!");
        if (bluePlayersOnStartingPosition)
        {
            Debug.Log("Prokockaj!");
            yield return new WaitWhile(() => prokockano == false);
        }

        if (numberOnDice == 6)
        {
            playerClones[0].transform.position = newPlayerFieldBlue;
            prokockano = false;
        }
        else
        {
            prokockano = false;
            redPlayersTurn = false;
            bluePlayersTurn = false;
            greenPlayersTurn = false;
            purplePlayersTurn = true;
            yield break;
        }

    }
    private IEnumerator PurpleTurn()
    {
        Debug.Log("Ljubicasti na redu!!");
        if (purplePlayersOnStartingPosition)
        {
            Debug.Log("Prokockaj!");
            yield return new WaitWhile(() => prokockano == false);
        }

        if (numberOnDice == 6)
        {
            playerClones[8].transform.position = newPlayerFieldPurple;
            prokockano = false;
        }
        else
        {
            prokockano = false;
            greenPlayersTurn = false;
            bluePlayersTurn = false;
            purplePlayersTurn = false;
            redPlayersTurn = true;
            yield break;
        }
    }

    private void Update()
    {
        if (redPlayersTurn)
        {
            StopCoroutine(GreenTurn());
            StopCoroutine(BlueTurn());
            StopCoroutine(PurpleTurn());
            StartCoroutine(RedTurn());
            
        }
        else if (greenPlayersTurn)
        {
            StopCoroutine(RedTurn());
            StopCoroutine(BlueTurn());
            StopCoroutine(PurpleTurn());
            StartCoroutine(GreenTurn());
            
        }
        else if (bluePlayersTurn)
        {
            StopCoroutine(GreenTurn());
            StopCoroutine(RedTurn());
            StopCoroutine(PurpleTurn());
            StartCoroutine(BlueTurn());
            
        }
        else if(purplePlayersTurn)
        {
            StopCoroutine(GreenTurn());
            StopCoroutine(BlueTurn());
            StopCoroutine(RedTurn());
            StartCoroutine(PurpleTurn());
        }
    }
}
