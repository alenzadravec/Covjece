using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    int numberOnDice;

    bool redPlayersOnStartingPosition;
    bool redPlayersTurn;

    bool bluePlayersOnStartingPosition;
    bool bluePlayersTurn;

    bool greenPlayersOnStartingPosition;
    bool greenPlayersTurn;

    bool purplePlayersOnStartingPosition;
    bool purplePlayersTurn;

    bool prokockano;
    GameObject[] playerClones;

    Vector3 newPlayerFieldRed = new Vector3(0.397f,-0.945f,1.923f);
    private void Start()
    {
        redPlayersOnStartingPosition = true;
        redPlayersTurn = true;
        prokockano = false;
        StartCoroutine(LateStart(0.1f));

        #region Referenciranje iz druge skripte
        GameObject GameplayDataInScene = GameObject.Find("GameplayData");
        GameplayData gameplayData = GameplayDataInScene.GetComponent<GameplayData>();
        playerClones = gameplayData.PlayerClone;
        #endregion

    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(MainFlowRoutine());
    }

    private void Update()
    {
        
    }

    public void OnButtonClick()
    {
        numberOnDice = Random.Range(1, 7);
        Debug.Log(numberOnDice);
        prokockano = true;
    }

    private IEnumerator MainFlowRoutine()
    {
        if (redPlayersOnStartingPosition & redPlayersTurn)
        {
            Debug.Log("Prokockaj!");
            yield return new WaitWhile(()=>prokockano==false);
        }
        numberOnDice = 6;
        if (numberOnDice == 6)
        {
            playerClones[5].transform.position = newPlayerFieldRed;
        }

        yield return 0;
    }
}
