using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        SpinButton.HandlePulled += StartRotating; 
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
            if (transform.position.y <= -3.5f)
            {
                transform.position = new Vector3(transform.position.x, 1.75f, 0f);
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, 0f);
                yield return new WaitForSeconds(timeInterval);
            }
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
                transform.position = new Vector3(transform.position.x, 1.75f, 0f);
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, 0f);
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
        SpinButton.HandlePulled -= StartRotating;
    }
}
