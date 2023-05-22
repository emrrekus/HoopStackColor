using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject _concerningStand;
    public GameObject _concerningCircleSocket;
    public bool moveThereIs;
    public string Color;
    public GameManager _gameManager;

    private GameObject movePosition, comingStand;

    private bool Selected, Change, socketOn, socketMoveBack;

    public void Move(string process, GameObject Stand = null, GameObject Socket = null, GameObject toGoObject = null)
    {
        switch (process)
        {
            case "Selected":
                movePosition = toGoObject;
                Selected = true;
                break;
            case "Change":
                comingStand = Stand;
                _concerningCircleSocket = Socket;
                movePosition = toGoObject;
                Change = true;
                break;
           case "socketMoveBack":
               socketMoveBack = true;
                break;
        }
    }


    void Update()
    {
        if (Selected)
        {
            transform.position = Vector3.Lerp(transform.position, movePosition.transform.position, .2f);
            if (Vector3.Distance(transform.position, movePosition.transform.position) < .10)
            {
                Selected = false;
            }
        }

        if (Change)
        {
            transform.position = Vector3.Lerp(transform.position, movePosition.transform.position, .2f);
            if (Vector3.Distance(transform.position, movePosition.transform.position) < .10)
            {
                Change = false;
                socketOn = true;
            }
        }
        if (socketOn)
        {
            transform.position = Vector3.Lerp(transform.position, _concerningCircleSocket.transform.position, .2f);
            if (Vector3.Distance(transform.position, _concerningCircleSocket.transform.position) < .10)
            {
                transform.position = _concerningCircleSocket.transform.position;
                socketOn = false;

                _concerningStand = comingStand;

                if (_concerningStand.GetComponent<Stand>()._Circle.Count > 1)
                {
                    _concerningStand.GetComponent<Stand>()._Circle[^2].GetComponent<Circle>().moveThereIs = false;
                }

                _gameManager.moveThereIs = false;
            }
        }
        if (socketMoveBack)
        {
            transform.position = Vector3.Lerp(transform.position, _concerningCircleSocket.transform.position, .2f);
            if (Vector3.Distance(transform.position, _concerningCircleSocket.transform.position) < .10)
            {
                transform.position = _concerningCircleSocket.transform.position;
                socketMoveBack = false;

               
                _gameManager.moveThereIs = false;
            }
        }
        
    }
}