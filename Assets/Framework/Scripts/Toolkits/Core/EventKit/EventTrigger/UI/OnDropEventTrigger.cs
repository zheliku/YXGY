﻿/****************************************************************************
 * Copyright (c) 2016 - 2023 liangxiegame UNDER MIT License
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
    using UnityEngine.EventSystems;

    public class OnDropEventTrigger : MonoBehaviour, IDropHandler
    {
        public readonly EasyEvent<PointerEventData> OnDropEvent = new EasyEvent<PointerEventData>();

        public void OnDrop(PointerEventData eventData)
        {
            OnDropEvent.Trigger(eventData);
        }
    }

    public static class OnDropEventTriggerExtension
    {
        public static IUnRegister OnDropEvent<T>(this T self, Action<PointerEventData> onDrop, int priority = 0)
            where T : Component
        {
            return self.GetOrAddComponent<OnDropEventTrigger>().OnDropEvent.Register(onDrop, priority);
        }

        public static IUnRegister OnDropEvent(this GameObject self, Action<PointerEventData> onDrop, int priority = 0)
        {
            return self.GetOrAddComponent<OnDropEventTrigger>().OnDropEvent.Register(onDrop, priority);
        }
    }
}