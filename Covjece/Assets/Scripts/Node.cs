using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public GameObject currentlyClickedNode;
    bool ableToClick = false;
    bool clicked = false;
    private IEnumerator WaitForClick()
    {
        yield return new WaitWhile(() => clicked==false);
        clicked = false; 
    }
private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Kliknuto!!");
            clicked = true;
            currentlyClickedNode = gameObject;
        }
    }
}
