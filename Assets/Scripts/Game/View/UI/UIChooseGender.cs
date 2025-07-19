// ------------------------------------------------------------
// @file       UIChooseGender.cs
// @brief
// @author     zheliku
// @Modified   2025-07-14 23:03:52
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using Framework.Toolkits.FluentAPI;
using Framework.Toolkits.SingletonKit;
using UnityEngine;

namespace Game
{
    using Framework.Core;

    public class UIChooseGender : MonoSingleton<UIChooseGender>
    {
        public void OnChooseGender(bool isMale)
        {
            this.GetModel<PlayerModel>().IsMale = isMale;

            this.DisableGameObject();
        }
        
        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}