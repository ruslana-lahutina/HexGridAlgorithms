﻿using System;
using UnityEngine;
using Assets.HexGridAlgorithms;

namespace Assets.Scripts
{
    class MouseActionsCatcher : MonoBehaviour
    {
        public Camera PlayerCamera;

        public Transform CurrentHex { get; private set; }

        public delegate void HexEvent(HexEventArgs e);
        public event HexEvent HexSelected;
        public event HexEvent HexHitted;
        public event EventHandler NoHexHitted;
        public event EventHandler NoHexSelected;

        private void Update()
        {
            if (GetComponent<ActionsOnlyInCanvas>() == null ||
                GetComponent<ActionsOnlyInCanvas>().IsMousePosInsideCanvas)
            {
                var ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    CurrentHex = hit.transform;

                    if (Input.GetMouseButton(0))
                        if (HexSelected != null) HexSelected(new HexEventArgs(CurrentHex.GetComponent<HexData>().HexPosition));

                    if (HexHitted != null) HexHitted(new HexEventArgs(CurrentHex.GetComponent<HexData>().HexPosition));

                }
                else if (CurrentHex)
                {
                    CurrentHex = null;
                    if (NoHexHitted != null) NoHexHitted(this, EventArgs.Empty);
                }
                else if (Input.GetMouseButton(0))
                {
                    if (NoHexSelected != null) NoHexSelected(this, EventArgs.Empty);
                }
            }
        }
    }
}
