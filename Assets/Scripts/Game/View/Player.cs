// ------------------------------------------------------------
// @file       Player.cs
// @brief
// @author     zheliku
// @Modified   2025-07-14 21:30:34
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using System;
using Framework.Toolkits.AudioKit;
using Framework.Toolkits.FluentAPI;
using Framework.Toolkits.SingletonKit;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Game
{
    using Framework.Core;
    
    public enum PlayerViewType
    {
        FirstPerson, // 第一人称视角
        ThirdPerson, // 第三人称视角
        FreeView,    // 自由视角
    }

    public class Player : MonoSingleton<Player>
    {
        [HierarchyPath("OVRInteractionComprehensive/Locomotor/PlayerController")]
        public Transform PlayerController; // 玩家角色的 Transform

        [HierarchyPath("TrackingSpace")]
        public Transform TrackingSpace;
        
        public Transform SelfModel; // 玩家角色的 Transform

        public Transform ChildModel;
        
        private PlayerViewType _viewType = PlayerViewType.FirstPerson;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            // this.GetModel<PlayerModel>().PlayerColor.Register((oldValue, newValue) =>
            // {
            //     PlayerModel.GetComponent<MeshRenderer>().material.color = newValue;
            // }).UnRegisterWhenGameObjectDestroyed(this);
            
            // AudioKit.PlayMusic("BgMusic");
        }

        protected override void Update()
        {
            base.Update();

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                if (_viewType == PlayerViewType.FirstPerson)
                    SwitchView(PlayerViewType.ThirdPerson);
                else if (_viewType == PlayerViewType.ThirdPerson)
                    SwitchView(PlayerViewType.FirstPerson);
            }
        }

        private void SwitchView(PlayerViewType type)
        {
            if (_viewType == type) return;

            _viewType = type;

            switch (type)
            {
                case PlayerViewType.FirstPerson:
                    SelfModel.SetParent(PlayerController);
                    SelfModel.SetLocalPositionIdentity()
                        .SetLocalRotationIdentity();
                    SelfModel.DisableGameObject();
                    TrackingSpace.SetLocalPositionIdentity();
                    break;
                case PlayerViewType.ThirdPerson:
                    TrackingSpace.SetLocalPosition(-2, 3, 1);
                    SelfModel.parent = null;
                    SelfModel.EnableGameObject();
                    break;
                case PlayerViewType.FreeView:
                    // 自由视角逻辑
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}