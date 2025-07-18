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

    public class OnBeginDragEventTrigger : MonoBehaviour, IBeginDragHandler
    {
        public readonly EasyEvent<PointerEventData> OnBeginDragEvent = new EasyEvent<PointerEventData>();

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnBeginDragEvent.Trigger(eventData);
        }
    }

    public static class OnBeginDragEventTriggerExtension
    {
        public static IUnRegister OnBeginDragEvent<T>(this T self, Action<PointerEventData> onBeganDrag, int priority = 0)
            where T : Component
        {
            return self.GetOrAddComponent<OnBeginDragEventTrigger>().OnBeginDragEvent.Register(onBeganDrag, priority);
        }

        public static IUnRegister OnBeginDragEvent(this GameObject self, Action<PointerEventData> onBeganDrag, int priority = 0)
        {
            return self.GetOrAddComponent<OnBeginDragEventTrigger>().OnBeginDragEvent.Register(onBeganDrag, priority);
        }
    }
}