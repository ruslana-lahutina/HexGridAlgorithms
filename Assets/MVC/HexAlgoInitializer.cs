﻿using Assets.HexGridAlgorithms;
using UnityEngine;
using Assets.MVC.Controllers;

namespace Assets.MVC
{
    public class HexAlgoInitializer : MonoBehaviour
    {
        
        HexAlgoController _hexAlgoController;

        void Start()
        {
            TerrainTextures.LoadTextures();

            _hexAlgoController = new HexAlgoController();
        }

    }
}
