// ------------------------------------------------------------
// @file       UIChoosePos.cs
// @brief
// @author     zheliku
// @Modified   2025-07-20 21:43:19
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using Framework.Toolkits.FluentAPI;

namespace Game
{
    using Framework.Core;

    public class UIChoosePos : AbstractView
    {
        public void OnChoosePos(int posIndex)
        {
            this.GetModel<PlayerModel>().ChildPosIndex = posIndex;

            this.DisableGameObject();

            SceneStart.Instance.UIChooseScene.EnableGameObject();
        }
        
        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}