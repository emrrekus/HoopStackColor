using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject selectedObject;
    private GameObject selectedPlatform;
    private Circle _Circle;
    public bool moveThereIs;
    public int targetStandCount;
    private int completedStandCount;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                if (hit.collider != null && hit.collider.CompareTag("Stand"))
                {
                    if (selectedObject != null && selectedPlatform != hit.collider.gameObject)
                    {
                        Stand _Stand = hit.collider.GetComponent<Stand>();

                        if (_Stand._Circle.Count != 4 && _Stand._Circle.Count != 0)
                        {
                            if (_Circle.Color == _Stand._Circle[^1].GetComponent<Circle>().Color)
                            {
                                selectedPlatform.GetComponent<Stand>().SocketChange(selectedObject);
                                _Circle.Move("Change", hit.collider.gameObject, _Stand.AvaibleSocketGive(),
                                    _Stand.movePosition);

                                _Stand.emptySocket++;
                                _Stand._Circle.Add(selectedObject);

                                selectedObject = null;
                                selectedPlatform = null;
                            }
                            else
                            {
                                _Circle.Move("socketMoveBack");
                                selectedObject = null;
                                selectedPlatform = null;
                            }
                        }
                        else if (_Stand._Circle.Count == 0)
                        {
                            selectedPlatform.GetComponent<Stand>().SocketChange(selectedObject);
                            _Circle.Move("Change", hit.collider.gameObject, _Stand.AvaibleSocketGive(),
                                _Stand.movePosition);

                            _Stand.emptySocket++;
                            _Stand._Circle.Add(selectedObject);

                            selectedObject = null;
                            selectedPlatform = null;
                        }
                        else
                        {
                            _Circle.Move("socketMoveBack");
                            selectedObject = null;
                            selectedPlatform = null;
                        }
                    }
                    else if (selectedPlatform == hit.collider.gameObject)
                    {
                        _Circle.Move("socketMoveBack");
                        selectedObject = null;
                        selectedPlatform = null;
                    }

                    else
                    {
                        Stand _Stand = hit.collider.GetComponent<Stand>();
                        selectedObject = _Stand.TopCircleGive();
                        _Circle = selectedObject.GetComponent<Circle>();
                        moveThereIs = true;

                        if (_Circle.moveThereIs)
                        {
                            _Circle.Move("Selected", null, null,
                                _Circle._concerningStand.GetComponent<Stand>().movePosition);

                            selectedPlatform = _Circle._concerningStand;
                        }
                    }
                }
            }
        }
    }
}