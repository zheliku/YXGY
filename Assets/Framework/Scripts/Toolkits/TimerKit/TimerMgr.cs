﻿// ------------------------------------------------------------
// @file       AudioTimer.cs
// @brief
// @author     zheliku
// @Modified   2024-11-14 14:11:30
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.TimerKit
{
    using System;
    using System.Collections.Generic;
    using PoolKit;
    using SingletonKit;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [MonoSingletonPath("Framework/TimerKit/TimerMgr")]
    public class TimerMgr : MonoSingleton<TimerMgr>
    {
        #region 字段

        [ShowInInspector]
        private readonly List<Timer> _timers = new List<Timer>();

        [ShowInInspector]
        public float ScaleTime
        {
            get => Time.time;
        }

        [ShowInInspector]
        public float UnScaledTime
        {
            get => Time.unscaledTime;
        }

        private readonly object _lock = new object();

        #endregion

        [ShowInInspector]
        public SingletonObjectPool<Timer> TimerPool { get => SingletonObjectPool<Timer>.Instance; }

        [ShowInInspector]
        public Dictionary<int, float> TimeDict { get; } = new Dictionary<int, float>();

        #region 公共方法

        public Timer CreateTimer(Action<Timer> onTick, float duration, int repeat = 1,
            TimerType timerType = TimerType.Scaled)
        {
            lock (_lock)
            {
                var timer = Timer.Spawn(onTick, duration, repeat, timerType);
                _timers.Add(timer);
                return timer;
            }
        }

        #endregion

        #region Unity 事件

        protected override void Update()
        {
            base.Update();
            
            lock (_lock)
            {
                _timers.RemoveAll(timer =>
                {
                    if (!timer.Enabled)
                    {
                        if (!timer.IsInPool) timer.RecycleToCache();
                        return true;
                    }

                    if (!timer.Paused && timer.TargetTime <= timer.CurrentTime)
                    {
                        timer.Tick();
                        if (!timer.TryRepeat())
                        {
                            if (!timer.IsInPool) timer.RecycleToCache();
                            return true;
                        }
                    }

                    return false;
                });
            }
        }

        #endregion
    }
}