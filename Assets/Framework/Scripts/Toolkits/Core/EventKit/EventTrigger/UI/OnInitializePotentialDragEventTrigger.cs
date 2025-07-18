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

    public class OnInitializePotentialDragEventTrigger : MonoBehaviour, IInitializePotentialDragHandler
    {
        public readonly EasyEvent<PointerEventData> OnInitializePotentialDragEvent = new EasyEvent<PointerEventData>();


        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            OnInitializePotentialDragEvent.Trigger(eventData);
        }
    }

    public static class OnInitializePotentialDragEventTriggerExtension
    {
        public static IUnRegister OnInitializePotentialDragEvent<T>(this T self, Action<PointerEventData> onInitializePotentialDrag, int priority = 0)
            where T : Component
        {
            return self.GetOrAddComponent<OnInitializePotentialDragEventTrigger>().OnInitializePotentialDragEvent.Register(onInitializePotentialDrag, priority);
        }

        public static IUnRegister OnInitializePotentialDragEvent(this GameObject self, Action<PointerEventData> onInitializePotentialDrag, int priority = 0)
        {
            return self.GetOrAddComponent<OnInitializePotentialDragEventTrigger>().OnInitializePotentialDragEvent.Register(onInitializePotentialDrag, priority);
        }
    }
}