﻿// ------------------------------------------------------------
// @file       UIKit.cs
// @brief
// @author     zheliku
// @Modified   2024-12-14 11:12:49
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.UIKit
{
    using System;
    using UnityEngine;
    using UnityEngine.ResourceManagement.AsyncOperations;

    public class UIKit
    {
        public static AsyncOperationHandle<GameObject> LoadPanelAsync<T>(Action<T> callback = null, UILevel level = UILevel.Common) where T : IPanel
        {
            return LoadPanelAsync<T>(typeof(T).Name, callback, level); 
        }

        public static AsyncOperationHandle<GameObject> LoadPanelAsync<T>(string panelName, Action<T> callback = null, UILevel level = UILevel.Common) where T : IPanel
        {
            return UIMgr.Instance.LoadPanelAsync<T>(panelName, callback, level);
        }
        
        public static T LoadPanel<T>(UILevel level = UILevel.Common) where T : IPanel
        {
            return LoadPanel<T>(typeof(T).Name, level);
        }
        
        public static T LoadPanel<T>(string panelName, UILevel level = UILevel.Common) where T : IPanel
        {
            var handle = LoadPanelAsync<T>(panelName, null, level);
            return handle.WaitForCompletion().GetComponent<T>();
        }
        
        public static T GetPanel<T>(string panelName) where T : IPanel
        {
            return UIMgr.Instance.GetPanel<T>(panelName);
        }
        
        public static T GetPanel<T>() where T : IPanel
        {
            return UIMgr.Instance.GetPanel<T>(typeof(T).Name);
        }

        public static void UnloadPanel<T>(Action callback = null) where T : IPanel
        {
            UnloadPanel(typeof(T).Name, callback);
        }

        public static void UnloadPanel(string panelName, Action callback = null)
        {
             UIMgr.Instance.UnloadPanel(panelName, callback);
        }

        public static AsyncOperationHandle<GameObject> ShowPanelAsync<T>(Action<T> callback = null, UILevel level = UILevel.Common) where T : IPanel
        {
            return ShowPanelAsync<T>(typeof(T).Name, callback, level);
        }

        public static AsyncOperationHandle<GameObject> ShowPanelAsync<T>(string panelName, Action<T> callback = null, UILevel level = UILevel.Common) where T : IPanel
        {
            return UIMgr.Instance.ShowPanelAsync<T>(panelName, callback, level);
        }
        
        public static T ShowPanel<T>(UILevel level = UILevel.Common) where T : IPanel
        {
            return ShowPanel<T>(typeof(T).Name, level); // 仅在 _panels 中存在时才返回值，否则返回 null
        }
        
        public static T ShowPanel<T>(string panelName, UILevel level = UILevel.Common) where T : IPanel
        {
            var handle = ShowPanelAsync<T>(panelName, null, level);
            return handle.WaitForCompletion().GetComponent<T>();
        }
        
        public static void HidePanel<T>(Action<T> callback = null) where T : IPanel
        {
            HidePanel<T>(typeof(T).Name, callback);
        }

        public static void HidePanel<T>(string panelName, Action<T> callback = null) where T : IPanel
        {
            UIMgr.Instance.HidePanel<T>(panelName, callback);
        }

        public static void HideAllPanel(Action<IPanel> callback = null)
        {
            UIMgr.Instance.HideAllPanel(callback);
        }

        public static void UnloadAllPanel(Action callback = null)
        {
            UIMgr.Instance.UnloadAllPanel(callback);
        }

        public static bool IsPanelShown<T>(string panelName) where T : IPanel
        {
            var panel = GetPanel<T>(panelName);
            return panel != null && panel.State == PanelState.Shown;
        }
        
        public static bool IsPanelShown<T>() where T : IPanel
        {
            return IsPanelShown<T>(typeof(T).Name);
        }
        
        public static void TogglePanelAsync<T>(string panelName, Action<T, bool> callback = null, UILevel level = UILevel.Common) where T : IPanel
        {
            if (IsPanelShown<T>(panelName))
            {
                HidePanel<T>(panelName, panel =>
                {
                    callback?.Invoke(panel, false);
                });
            }
            else
            {
                ShowPanelAsync<T>(panelName, panel =>
                {
                    callback?.Invoke(panel, true);
                }, level);
            }
        }
        
        public static void TogglePanelAsync<T>(Action<T, bool> callback = null, UILevel level = UILevel.Common) where T : IPanel
        {
            TogglePanelAsync<T>(typeof(T).Name, callback, level);
        }
        
        public static void TogglePanel<T>(string panelName, UILevel level = UILevel.Common) where T : IPanel
        {
            if (IsPanelShown<T>(panelName))
            {
                HidePanel<T>(panelName);
            }
            else
            {
                ShowPanel<T>(panelName, level);
            }
        }
        
        public static void TogglePanel<T>(UILevel level = UILevel.Common) where T : IPanel
        {
            TogglePanel<T>(typeof(T).Name, level);
        }
    }
}