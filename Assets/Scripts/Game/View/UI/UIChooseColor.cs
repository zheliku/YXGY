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

    public class UIChooseColor : AbstractView
    {
        private Color _selfColor;
        private Color _childColor;

        public void OnSelectSelfColor(Button selectedButton)
        {
            _selfColor = selectedButton.GetComponent<Image>().color;

            var showCase = SceneStart.Instance.GenderShowCase.SelectedCase;

            showCase.Find("Role").GetChild(0).GetComponent<MeshRenderer>().material.color = _selfColor;
        }

        public void OnSelectChildColor(Button selectedButton)
        {
            _childColor = selectedButton.GetComponent<Image>().color;

            var showCase = this.GetModel<PlayerModel>().IsMale
                ? SceneStart.Instance.BoyShowCase.SelectedCase
                : SceneStart.Instance.GirlShowCase.SelectedCase;

            showCase.Find("Role").GetChild(0).GetComponent<MeshRenderer>().material.color = _childColor;
        }

        public void OnChooseSelfColor(Button selectedButton)
        {
            this.GetModel<PlayerModel>().SelfColor = _selfColor;

            SceneStart.Instance.UIDialog.EnableGameObject();
            SceneStart.Instance.GenderShowCase.DisableGameObject();

            this.DisableGameObject();

            var selectedCase = SceneStart.Instance.GenderShowCase.SelectedCase;
            var selectedRole = selectedCase.Find("Role");
            
            Player.Instance.SelfModel = selectedRole;
            selectedRole.SetParent(Player.Instance.PlayerController);
            selectedRole.Name("Self");
            selectedRole.DisableGameObject();

            selectedRole.SetLocalPositionIdentity();
            selectedRole.SetLocalRotationIdentity();
        }

        public void OnChooseChildColor(Button selectedButton)
        {
            this.GetModel<PlayerModel>().ChildColor = _childColor;

            this.DisableGameObject();
            
            var showCase = this.GetModel<PlayerModel>().IsMale
                ? SceneStart.Instance.BoyShowCase
                : SceneStart.Instance.GirlShowCase;
            var selectedRole = showCase.SelectedCase.Find("Role");
            
            Player.Instance.ChildModel = selectedRole;
            selectedRole.SetParent(Player.Instance.PlayerController);
            selectedRole.Name("Child");
            selectedRole.DisableGameObject();
            
            showCase.DisableGameObject();
            
            SceneStart.Instance.UIChoosePos.EnableGameObject();
        }

        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}