﻿// ------------------------------------------------------------
// @file       DynamicGrid.cs
// @brief
// @author     zheliku
// @Modified   2024-11-01 13:11:13
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.GridKit
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [HideReferenceObjectPicker]
    public partial class DynamicGrid<TValue> : IEnumerable<KeyValuePair<Vector2Int, TValue>>
    {
        [ShowInInspector]
        [DictionaryDrawerSettings(KeyLabel = "Row, Column", ValueLabel = "Value")]
        private readonly Dictionary<Index, TValue> _grid = null;

        public DynamicGrid()
        {
            _grid = new Dictionary<Index, TValue>();
        }

        public void ForEach(Action<int, int, TValue> each)
        {
            foreach (var kvp in _grid)
            {
                each(kvp.Key.Row, kvp.Key.Column, kvp.Value);
            }
        }

        public void ForEach(Action<TValue> each)
        {
            foreach (var kvp in _grid)
            {
                each(kvp.Value);
            }
        }

        public int Count
        {
            get => _grid.Count;
        }

        public TValue this[int row, int column]
        {
            get
            {
                var key = new Index(row, column);
                return _grid.GetValueOrDefault(key);
            }
            set
            {
                var key = new Index(row, column);
                _grid[key] = value;
            }
        }

        public TValue this[Vector2Int index]
        {
            get
            {
                var key = new Index(index.x, index.y);
                return _grid.GetValueOrDefault(key);
            }
            set
            {
                var key = new Index(index.x, index.y);
                _grid[key] = value;
            }
        }

        public void Clear(Action<TValue> cleanupItem = null)
        {
            _grid.Clear();
        }

        public IEnumerator<KeyValuePair<Vector2Int, TValue>> GetEnumerator()
        {
            foreach (var kvp in _grid)
            {
                yield return new KeyValuePair<Vector2Int, TValue>(
                    new Vector2Int(kvp.Key.Row, kvp.Key.Column), kvp.Value
                );
            }
        }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }

    public partial class DynamicGrid<TValue>
    {
        private readonly struct Index : IEquatable<Index>
        {
            [ShowInInspector] [LabelWidth(30)]
            [HorizontalGroup("Index")]
            public readonly int Row;

            [ShowInInspector] [LabelWidth(30)] [LabelText("Col")]
            [HorizontalGroup("Index")]
            public readonly int Column;

            public Index(int row, int column)
            {
                Row    = row;
                Column = column;
            }

            public bool Equals(Index other)
            {
                return Row == other.Row && Column == other.Column;
            }

            public override bool Equals(object obj)
            {
                return obj is Index other && Equals(other);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Row, Column);
            }
        }
    }
}