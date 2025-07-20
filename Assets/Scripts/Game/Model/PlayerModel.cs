using Framework.Core;
using UnityEngine;

namespace Game
{
    using Framework.Core.Model;

    public class PlayerModel : AbstractModel
    {
        public Color SelfColor { get; set; } = Color.white;

        public Color ChildColor { get; set; } = Color.white;

        public bool IsMale { get; set; } = true;

        public string SelectedRole { get; set; }
        public int ChildPosIndex { get; set; } // 0: Close, 1: Middle, 2: Far

        protected override void OnInit()
        {
        }
    }
}