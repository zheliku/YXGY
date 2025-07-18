// ------------------------------------------------------------
// @file       UIChooseColor.cs
// @brief
// @author     zheliku
// @Modified   2025-07-14 21:19:42
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using Framework.Toolkits.ResKit;
using Framework.Toolkits.SingletonKit;
using UnityEngine;

namespace Game
{
    using Framework.Core;

    public class UIChooseScene : MonoSingleton<UIChooseScene>
    {
        public void OnStartGame(int gameIndex)
        {
            ResKit.LoadSceneAsync($"Scene {gameIndex}", () =>
            {
                
            });
        }

        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}