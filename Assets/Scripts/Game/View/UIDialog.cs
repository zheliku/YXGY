// ------------------------------------------------------------
// @file       UIDialog.cs
// @brief
// @author     zheliku
// @Modified   2025-07-18 23:33:48
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using Framework.Toolkits.FluentAPI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.Events;

namespace Game
{
    using Framework.Core;

    public class UIDialog : AbstractView
    {
        [HierarchyPath("Text_Dialog")]
        public TextMeshProUGUI DialogText;
        
        public List<string> DialogLines = new List<string>();

        public UnityEvent OnDialogFinish;
        
        private int _currentIndex = 0;
        
        private void Awake()
        {
            DialogText.text = DialogLines[0];
        }

        public void OnBtnClicked()
        {
            _currentIndex++;
            
            if (_currentIndex < DialogLines.Count)
            {
                DialogText.text = DialogLines[_currentIndex];
            }
            else
            {
                OnDialogFinish?.Invoke();
                this.DisableGameObject();
                _currentIndex = 0; // Reset index for next use
            }
        }
        
        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}