// ------------------------------------------------------------
// @file       UIChooseColor.cs
// @brief
// @author     zheliku
// @Modified   2025-07-14 21:19:42
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using Framework.Toolkits.FluentAPI;
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
                var childPoseIndex = this.GetModel<PlayerModel>().ChildPosIndex;
                var childPrePose = Scene2.Instance.ChildPrePos[childPoseIndex];
                Player.Instance.ChildModel?.SetParent(childPrePose);
                Player.Instance.ChildModel?.SetLocalPositionIdentity()
                    .SetLocalRotationIdentity()
                    .EnableGameObject();

                Player.Instance.SetPosition(Scene2.Instance.SelfPrePos.GetPosition());
                Player.Instance.SetRotation(Scene2.Instance.SelfPrePos.GetRotation());
            });
        }

        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}