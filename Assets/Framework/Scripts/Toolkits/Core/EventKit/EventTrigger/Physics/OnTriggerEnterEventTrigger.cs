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

    public class OnTriggerEnterEventTrigger : MonoBehaviour
    {
        public readonly EasyEvent<Collider> OnTriggerEnterEvent = new EasyEvent<Collider>();

        private void OnTriggerEnter(Collider collider)
        {
            OnTriggerEnterEvent.Trigger(collider);
        }
    }

    public static class OnTriggerEnterEventTriggerExtension
    {
        public static IUnRegister OnTriggerEnterEvent<T>(this T self, Action<Collider> onTriggerEnter, int priority = 0)
            where T : Component
        {
            return self.GetOrAddComponent<OnTriggerEnterEventTrigger>().OnTriggerEnterEvent
                       .Register(onTriggerEnter, priority);
        }

        public static IUnRegister OnTriggerEnterEvent(this GameObject self, Action<Collider> onTriggerEnter, int priority = 0)
        {
            return self.GetOrAddComponent<OnTriggerEnterEventTrigger>().OnTriggerEnterEvent
                       .Register(onTriggerEnter, priority);
        }
    }
}