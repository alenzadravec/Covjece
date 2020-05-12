using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject currentlyClickedPlayer;
    public bool clicked = false;
    private void OnMouseDown()
    { 
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Kliknuto!!");
                clicked = true;
                currentlyClickedPlayer = gameObject;
                Debug.Log(currentlyClickedPlayer);
            }
    }
}