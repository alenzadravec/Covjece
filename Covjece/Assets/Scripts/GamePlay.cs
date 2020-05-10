using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    int numberOnDice;
    bool prokockano;
    GameObject[] playerClones;
    GameObject[] pathNodes;

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
        pathNodes = gameplayData.PathNodes;
        #endregion
      
        StartCoroutine(RedTurn());

    }

    public void OnButtonClick()
    {
        numberOnDice = Random.Range(1, 7);
        Debug.Log(numberOnDice);
        prokockano = true;
    }
    private IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(1f);
        Debug.ClearDeveloperConsole();
    }

    
    private IEnumerator RedTurn()
    {
            Debug.Log("Crveni na redu!!");
            Debug.Log("Prokockaj!");
            yield return new WaitWhile(() => prokockano == false);
            StartCoroutine(WaitingTime());
     

            if (numberOnDice == 6)
            {
                playerClones[4].transform.position = newPlayerFieldRed;
                prokockano = false;
                StartCoroutine(RedTurn());
            }
            else
            {
            playerClones[4].transform.position = pathNodes[0].transform.position;
                prokockano = false;
                GreenTurn();
        }
    }
    private void GreenTurn()
    {
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
