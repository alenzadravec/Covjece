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
    public Node currentNode;

    int routePosition;
    public int startNodeIndex;

    int steps;//Dice amount(rolled)
    int doneSteps;

    [Header("Bool")]
    public bool isOut;
    bool isMoving;
    bool hasTurn;

    [Header("SELECTOR")]
    public GameObject selector;

    private void Start()
    {
        startNodeIndex = commonRoute.RequestPosition(startNode.gameObject.transform);
        CreateFullRoute();
    }
    void CreateFullRoute()
    {
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
  
    public void Prokockaj()
    {
        if (!isMoving)
        {
            steps = Random.RandomRange(1, 7);
            Debug.Log("Broj na kockici: " + steps);
            if (doneSteps + steps < fullRoute.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                Debug.Log("Broj prevelik");
            }
        }
    }
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }

        isMoving = true;

        while (steps > 0)
        {
            routePosition++;

            Vector3 nextPos = fullRoute[routePosition].gameObject.transform.position;

            while (MoveToNextNode(nextPos, 8f)) { yield return null; }

            yield return new WaitForSeconds(.1f);
            steps--;
            doneSteps++;
        }
        isMoving = false;
    }

    bool MoveToNextNode(Vector3 goalPos, float speed)
    {
        return goalPos != (transform.position = Vector3.MoveTowards(transform.position, goalPos, speed * Time.deltaTime));
    }

    public bool ReturnIsOut()
    {
        return isOut;
    }
}
