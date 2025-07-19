// ------------------------------------------------------------
// @file       Player.cs
// @brief
// @author     zheliku
// @Modified   2025-07-14 21:30:34
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using System;
using Framework.Toolkits.AudioKit;
using Framework.Toolkits.SingletonKit;
using UnityEngine;

namespace Game
{
    using Framework.Core;

    public class Player : MonoSingleton<Player>
    {
        [HierarchyPath("OVRInteractionComprehensive/Locomotor/PlayerController/PlayerModel")]
        public Transform PlayerModel; // 玩家角色的 Transform

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            // this.GetModel<PlayerModel>().PlayerColor.Register((oldValue, newValue) =>
            // {
            //     PlayerModel.GetComponent<MeshRenderer>().material.color = newValue;
            // }).UnRegisterWhenGameObjectDestroyed(this);
            
            // AudioKit.PlayMusic("BgMusic");
        }

        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}