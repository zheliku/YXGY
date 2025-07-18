﻿/****************************************************************************
 * Copyright (c) 2016 - 2022 liangxiegame UNDER MIT License
 *
 * https://qframework.cn
 * https://github.com/liangxiegame/QFramework
 * https://gitee.com/liangxiegame/QFramework
 ****************************************************************************/

namespace Framework.Toolkits.EventKit
{
    using System;
    using FluentAPI;
    using Framework.Core;
    using UnityEngine;

    public class OnCollisionStayEventTrigger : MonoBehaviour
    {
        public readonly EasyEvent<Collision> OnCollisionStayEvent = new EasyEvent<Collision>();

        private void OnCollisionStay(Collision col)
        {
            OnCollisionStayEvent.Trigger(col);
        }
    }

    public static class OnCollisionStayEventTriggerExtension
    {
        public static IUnRegister OnCollisionStayEvent<T>(this T self, Action<Collision> onCollisionStay, int priority = 0)
            where T : Component
        {
            return self.GetOrAddComponent<OnCollisionStayEventTrigger>().OnCollisionStayEvent
                       .Register(onCollisionStay, priority);
        }

        public static IUnRegister OnCollisionStayEvent(this GameObject self, Action<Collision> onCollisionStay, int priority = 0)
        {
            return self.GetOrAddComponent<OnCollisionStayEventTrigger>().OnCollisionStayEvent
                       .Register(onCollisionStay, priority);
        }
    }
}