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
        private Color _selectedColor;

        public void OnSelectColor(Button selectedButton)
        {
            _selectedColor = selectedButton.GetComponent<Image>().color;

            foreach (Transform child in SceneStart.Instance.GenderShowCase.transform)
            {
                if (child.gameObject.activeInHierarchy)
                {
                    child.Find("Role").GetChild(0).GetComponent<MeshRenderer>().material.color = _selectedColor;
                    break;
                }
            }
        }

        public void OnChooseColor(Button selectedButton)
        {
            this.GetModel<PlayerModel>().PlayerColor.Value = _selectedColor;
            
            SceneStart.Instance.UIDialog.EnableGameObject();
            SceneStart.Instance.GenderShowCase.DisableGameObject();
            
            this.DisableGameObject();

            var selectedCase = SceneStart.Instance.GenderShowCase.SelectedCase;
            var selectedRole = selectedCase.Find("Role");
            
            selectedRole.SetParent(Player.Instance.PlayerModel);

            selectedRole.SetLocalPosition(new Vector3(0, -Player.Instance.PlayerModel.parent.localPosition.y, 0));
            selectedRole.SetLocalRotation(Quaternion.Euler(0, 180, 0));
        }

        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}