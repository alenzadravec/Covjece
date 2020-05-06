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

    public GameplayData gameplayData;


    void Start()
    {
        redPlayersOnStartingPosition = true;
        redPlayersTurn = true;
        prokockano = false;
        StartCoroutine(LateStart(0.1f));
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
            
        }

        yield return 0;
    }
}
