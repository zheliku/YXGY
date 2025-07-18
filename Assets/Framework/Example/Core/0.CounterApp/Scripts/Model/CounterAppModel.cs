﻿// ------------------------------------------------------------
// @file       CounterAppModel.cs
// @brief
// @author     zheliku
// @Modified   2024-10-09 00:10:06
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Core.Example._0.CounterApp.Scripts.Model
{
    using Core.Model;
    using Sirenix.OdinInspector;
    using Utility;

    public class CounterAppModel : AbstractModel, ICounterAppModel
    {
        [ShowInInspector]
        public BindableProperty<int> Count { get; set; } = new BindableProperty<int>();

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();

            // 设置初始值（不触发事件）
            Count.SetValueWithoutEvent(storage.LoadInt(nameof(Count)));

            // 当数据变更时 存储数据
            Count.Register((oldValue, newCount) =>
            {
                storage.SaveInt(nameof(Count), newCount);
            });
        }
    }
}