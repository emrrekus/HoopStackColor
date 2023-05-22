using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public GameObject movePosition;
    public GameObject[] Sockets;
    public int emptySocket;
    public List<GameObject> _Circle = new List<GameObject>();
    [SerializeField] private GameManager _gameManager;

    private int circleColorCount;

    public GameObject TopCircleGive()
    {
        return _Circle[^1];
    }

    public GameObject AvaibleSocketGive()
    {
        return Sockets[emptySocket];
    }

    public void SocketChange(GameObject RemoveObject)
    {
        _Circle.Remove(RemoveObject);

        if (_Circle.Count != 0)
        {
            emptySocket--;
            _Circle[^1].GetComponent<Circle>().moveThereIs = true;
        }
        else
        {
            emptySocket = 0;
        }
    }

    public void CircleControl()
    {
        if (_Circle.Count == 4)
        {
            string Color = _Circle[0].GetComponent<Circle>().Color;
            foreach (var item in _Circle)
            {
                if (Color == item.GetComponent<Circle>().Color)
                    circleColorCount++;
            }

            if (circleColorCount == 4)
            {
                _gameManager.StandComplate();
                ComplateStand();
            }
            else
            {
               
                circleColorCount = 0;
            }
        }
    }

    void ComplateStand()
    {
        foreach (var item in _Circle)
        {
            item.GetComponent<Circle>().moveThereIs = false;

            Color32 color = item.GetComponent<MeshRenderer>().material.GetColor("_Color");
            color.a = 150;
            item.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
            gameObject.tag = "ComplateStand";
;
        }
    }
}