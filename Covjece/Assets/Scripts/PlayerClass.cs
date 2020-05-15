using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public bool playerInStartHouse;
    public bool playerOnBoard;
    public bool playerAtFinish;
    public Vector3 currentNode;
    public bool clicked = false;
    public GameObject player;
    GamePlay gamePlay;

    [Header("Routes")]
    public Route commonRoute;
    public Route finalRoute;

    public List<Node> fullRoute = new List<Node>();
    [Header("Nodes")]
    public Node startNode;
    public Node baseNode;
    public Node goalNode;

    int routePosition;
    int startNodeIndex;

    [Header("Bool")]
    public bool isOut;
    bool isMoving;
    bool hasTurn;

    [Header("SELECTOR")]
    public GameObject selector;
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
    private void Start()
    {
        startNodeIndex = commonRoute.RequestPosition(startNode.gameObject.transform);
    }
    void CreateFullRoute()
    {
        for (int i = 0; i < commonRoute.childNodeList.Count; i++)
        {
            int tempPos = startNodeIndex + i;
            tempPos %= commonRoute.childNodeList.Count;

            fullRoute.Add(commonRoute.childNodeList[tempPos].GetComponent<Node>());
        }

        for (int i = 0; i < finalRoute.childNodeList.Count; i++)
        {
            fullRoute.Add(finalRoute.childNodeList[i].GetComponent<Node>());
        }
    }
}
