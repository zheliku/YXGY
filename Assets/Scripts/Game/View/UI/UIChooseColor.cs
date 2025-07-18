// ------------------------------------------------------------
// @file       UIChooseColor.cs
// @brief
// @author     zheliku
// @Modified   2025-07-14 22:57:34
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using Framework.Toolkits.FluentAPI;
using Framework.Toolkits.SingletonKit;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    using Framework.Core;

    public class UIChooseColor : MonoSingleton<UIChooseColor>
    {
        public void OnChooseColor(Button selectedButton)
        {
            var selectedColor = selectedButton.GetComponent<Image>().color;
            this.GetModel<PlayerModel>().PlayerColor.Value = selectedColor;

            foreach (Transform child in SceneStart.Instance.GenderShowCase.transform)
            {
                if (child.gameObject.activeInHierarchy)
                {
                    child.Find("Role").GetChild(0).GetComponent<MeshRenderer>().material.color = selectedColor;
                    break;
                }
            }
            
            SceneStart.Instance.UIDialog.EnableGameObject();

            this.DisableGameObject();
        }
        
        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}