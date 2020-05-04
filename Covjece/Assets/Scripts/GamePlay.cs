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

    void Start()
    {
        redPlayersOnStartingPosition = true;
        redPlayersTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (redPlayersOnStartingPosition & redPlayersTurn)
        {
            Debug.Log("Prokockaj!");
        }
    }

    public void OnButtonClick()
    {
        numberOnDice = Random.Range(1, 6);
        Debug.Log(numberOnDice);
    }

    //private bool FirstDiceRoll(bool position, bool turn)
    //{
    //    return position;
    //}
}
