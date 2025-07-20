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

        protected override void OnInit()
        {
        }
    }
}