using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
   public GameObject movePosition;
   public GameObject [] Sockets;
   public int emptySocket;
   public List<GameObject> _Circle = new List<GameObject>();
   [SerializeField] private GameManager _gameManager;

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

}
