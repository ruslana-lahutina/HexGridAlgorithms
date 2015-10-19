﻿using Assets.HexGridAlgorithms.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenButton : MonoBehaviour
{
    public GameObject FirstCanvas;
    public GameObject SecondCanvas;

    public GameObject Map;

    public GameObject TempGO;

	void Start ()
    {
        var input = gameObject.GetComponent<Button>();
        if (input != null) input.onClick.AddListener(ChangeCanvas);
    }

    void ChangeCanvas()
    {
        if (Map.transform.parent == FirstCanvas.transform)
        {
            Map.transform.parent = SecondCanvas.transform;
            TempGO.SetActive(false);
        }
        else
        {
            Map.transform.parent = FirstCanvas.transform;
            TempGO.SetActive(true);
        }
        Map.GetComponent<ActionsOnlyInCanvas>().InitComponents();
    }
}
