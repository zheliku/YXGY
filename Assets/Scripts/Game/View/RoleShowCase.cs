// ------------------------------------------------------------
// @file       RoleShowCase.cs
// @brief
// @author     zheliku
// @Modified   2025-07-14 23:12:58
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using System;
using Framework.Toolkits.FluentAPI;
using Framework.Toolkits.ResKit;
using Framework.Toolkits.SingletonKit;
using UnityEngine;

namespace Game
{
    using Framework.Core;

    public class RoleShowCase : AbstractView
    {
        public Transform SelectedCase;

        public void OnChooseGender(Transform selectedCase)
        {
            SelectedCase = selectedCase;
            
            var modelName = selectedCase.Find("Role").GetChild(0).name;

            selectedCase.Find("UI").DisableGameObject();

            this.GetModel<PlayerModel>().IsMale = modelName == "man";

            HideRoles();

            selectedCase.EnableGameObject();

            selectedCase.SetLocalPosition(-2.4f);

            SceneStart.Instance.UIChooseSelfColor.EnableGameObject();
        }

        public void OnChooseBoy(Transform selectedCase)
        {
            SelectedCase = selectedCase;
            
            selectedCase.Find("UI").DisableGameObject();
            
            HideRoles();

            selectedCase.EnableGameObject();
            
            selectedCase.SetLocalPosition(-2.4f);
            
            SceneStart.Instance.UIChooseChildColor.EnableGameObject();
        }

        public void OnChooseGirl(Transform selectedCase)
        {
            SelectedCase = selectedCase;
            
            selectedCase.Find("UI").DisableGameObject();
            
            HideRoles();

            selectedCase.EnableGameObject();
            
            selectedCase.SetLocalPosition(-2.4f);
            
            SceneStart.Instance.UIChooseChildColor.EnableGameObject();
        }

        public void ShowRoles()
        {
            foreach (Transform child in transform)
            {
                child.EnableGameObject();
            }
        }

        public void HideRoles()
        {
            foreach (Transform child in transform)
            {
                child.DisableGameObject();
            }
        }

        public void OnShowBoyOrGirlCase()
        {
            if (this.GetModel<PlayerModel>().IsMale)
            {
                SceneStart.Instance.BoyShowCase.EnableGameObject();
            }
            else
            {
                SceneStart.Instance.GirlShowCase.EnableGameObject();
            }

            // SceneStart.Instance.GenderShowCase.DisableGameObject();
        }

        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}