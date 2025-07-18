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

    public class OnTriggerStay2DEventTrigger : MonoBehaviour
    {
        public readonly EasyEvent<Collider2D> OnTriggerStay2DEvent = new EasyEvent<Collider2D>();

        private void OnTriggerStay2D(Collider2D collider)
        {
            OnTriggerStay2DEvent.Trigger(collider);
        }
    }

    public static class OnTriggerStay2DEventTriggerExtension
    {
        public static IUnRegister OnTriggerStay2DEvent<T>(this T self, Action<Collider2D> onTriggerStay2D, int priority = 0)
            where T : Component
        {
            return self.GetOrAddComponent<OnTriggerStay2DEventTrigger>().OnTriggerStay2DEvent
                       .Register(onTriggerStay2D, priority);
        }

        public static IUnRegister OnTriggerStay2DEvent(this GameObject self, Action<Collider2D> onTriggerStay2D, int priority = 0)
        {
            return self.GetOrAddComponent<OnTriggerStay2DEventTrigger>().OnTriggerStay2DEvent
                       .Register(onTriggerStay2D, priority);
        }
    }
}