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

    private GameObject movePosition, concerningStand;

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
                
                break;
            case "socketOn":
                
                break;
            case "socketMoveBack":
                
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
    }
}