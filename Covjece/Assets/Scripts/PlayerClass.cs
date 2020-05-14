using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public bool playerInStartHouse;
    public bool playerOnBoard;
    public bool playerAtFinish;
    public int currentNode;
    public bool clicked = false;
    public GameObject player;
    GamePlay gamePlay;

    private void OnMouseDown()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Kliknuto!!");
                player = gameObject;
                Debug.Log(player);
                clicked = true;
            }
    }  
}
