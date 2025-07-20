// ------------------------------------------------------------
// @file       Scene2.cs
// @brief
// @author     zheliku
// @Modified   2025-07-20 22:50:15
// @Copyright  Copyright (c) 2025, zheliku
// ------------------------------------------------------------

using System.Collections.Generic;
using Framework.Toolkits.SingletonKit;
using UnityEngine;

namespace Game
{
    using Framework.Core;

    public class Scene2 : MonoSingleton<Scene2>
    {
        public List<Transform> ChildPrePos;
        
        [HierarchyPath("/SelfPrePos")]
        public Transform SelfPrePos;
        
        protected override IArchitecture _Architecture { get => Game.Architecture; }
    }
}