﻿using UnityEngine;
using UnityEngine.UI;

namespace Logic.UI
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private Button closeButton;

        private void Awake() => OnAwake();

        private protected void OnAwake()
        {
            if(closeButton) closeButton.onClick.AddListener(() => Destroy(gameObject));
        }
    }
}