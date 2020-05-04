using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;
    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private int prizeValue;
    private bool resultsChecked = false;


 
    public void govno()
    {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = 0;
            resultsChecked = false;
        }
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            CheckResults();
        }
    }
    public void CheckResults()
    {
        if (rows[0].stoppedSlot == "Diamond"
            && rows[1].stoppedSlot == "Diamond"
            && rows[2].stoppedSlot == "Diamond")

        { prizeValue = 200; }

        else if (rows[0].stoppedSlot == "Crown"
            && rows[1].stoppedSlot == "Crown"
            && rows[2].stoppedSlot == "Crown")

        { prizeValue = 400; }

        else if (rows[0].stoppedSlot == "Melon"
            && rows[1].stoppedSlot == "Melon"
            && rows[2].stoppedSlot == "Melon")

        { prizeValue = 600; }

        else if (rows[0].stoppedSlot == "Bar"
            && rows[1].stoppedSlot == "Bar"
            && rows[2].stoppedSlot == "Bar")

        { prizeValue = 800; }

        else if (rows[0].stoppedSlot == "Seven"
            && rows[1].stoppedSlot == "Seven"
            && rows[2].stoppedSlot == "Seven")

        { prizeValue = 1500; }

        else if (rows[0].stoppedSlot == "Cherry"
            && rows[1].stoppedSlot == "Cherry"
            && rows[2].stoppedSlot == "Cherry")

        { prizeValue = 3000; }

        else if (rows[0].stoppedSlot == "Lemon"
            && rows[1].stoppedSlot == "Lemon"
            && rows[2].stoppedSlot == "Lemon")

        { prizeValue = 5000; }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Diamond")
                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Diamond")
                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Diamond"))
        {
            prizeValue = 100;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Crown")
                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Crown")
                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Crown"))
        {
            prizeValue = 300;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Melon")
                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Melon")
                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Melon"))
        {
            prizeValue = 500;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Bar")
                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Bar")
                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Bar"))
        {
            prizeValue = 700;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Seven")
                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Seven")
                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Seven"))
        {
            prizeValue = 1000;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Cherry")
                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Cherry")
                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Cherry"))
        {
            prizeValue = 2000;
        }

        else if ((rows[0].stoppedSlot == rows[1].stoppedSlot) && (rows[0].stoppedSlot == "Lemon")
                || (rows[0].stoppedSlot == rows[2].stoppedSlot) && (rows[0].stoppedSlot == "Lemon")
                || (rows[1].stoppedSlot == rows[2].stoppedSlot) && (rows[1].stoppedSlot == "Lemon"))
        {
            prizeValue = 4000;
        }

        resultsChecked = true;
    }


public void onClick()
    {
        rowStopped = true;
        StartRotating();
        govno();
    }
 
    private void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }
    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y >= -3.5f)
            {
                transform.position = new Vector2(transform.position.x, 1.75f);
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
                yield return new WaitForSeconds(timeInterval);
            }
            else { break ; }
        }
        randomValue = Random.Range(60, 100);
        switch (randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;

            case 2:
                randomValue += 1;
                break;

        }

        for (int i = 0; i < randomValue; i++)
        {
            if (transform.position.y <= -3.5f)
            {
                transform.position = new Vector2(transform.position.x, 1.75f);
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
            }
            if (i > Mathf.RoundToInt(randomValue * 0.25f))
                timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
                timeInterval = 0.2f;

            yield return new WaitForSeconds(timeInterval);
        }
        if (transform.position.y == -3.5f)
            stoppedSlot = "Diamond";
        if (transform.position.y == -3.5f)
            stoppedSlot = "Crown";
        if (transform.position.y == -3.5f)
            stoppedSlot = "Melon";
        if (transform.position.y == -3.5f)
            stoppedSlot = "Bar";
        if (transform.position.y == -3.5f)
            stoppedSlot = "Seven";
        if (transform.position.y == -3.5f)
            stoppedSlot = "Cherry";
        if (transform.position.y == -3.5f)
            stoppedSlot = "Lemon";

        rowStopped = true;
    }

    public void OnDestroy()
    {
        StopAllCoroutines();
    }
}
