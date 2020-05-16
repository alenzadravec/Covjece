using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{

    [Header("Routes")]
    public Route commonRoute;
    public Route finalRoute;

    public List<Node> fullRoute = new List<Node>();
    [Header("Nodes")]
    public Node startNode;
    public Node baseNode;
    public Node goalNode;

    int routePosition;
    public int startNodeIndex;

    [Header("Bool")]
    public bool isOut;
    bool isMoving;
    bool hasTurn;

    [Header("SELECTOR")]
    public GameObject selector;

    private void Start()
    {
        startNodeIndex = commonRoute.RequestPosition(startNode.gameObject.transform);
        Debug.Log(startNodeIndex);
        CreateFullRoute();
    }
    void CreateFullRoute()
    {
        Debug.Log(startNodeIndex);
        for (int i = 0; i < commonRoute.childNodeList.Count; i++)
        {
            int tempPos;
            tempPos= startNodeIndex + i;
            tempPos %= commonRoute.childNodeList.Count;

            fullRoute.Add(commonRoute.childNodeList[tempPos].GetComponent<Node>());
        }

        for (int i = 0; i < finalRoute.childNodeList.Count; i++)
        {
            fullRoute.Add(finalRoute.childNodeList[i].GetComponent<Node>());
        }
    }
}
