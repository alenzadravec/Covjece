using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //private IEnumerator WaitForClick
    //{
    //    yield return new WaitWhile
    //}
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Kliknuto!!");

        }
    }
}
