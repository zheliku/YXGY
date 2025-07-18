using Framework.Core;
using UnityEngine;

namespace Game
{
    using Framework.Core.Model;

    public class PlayerModel : AbstractModel
    {
        public BindableProperty<Color> PlayerColor { get; set; } = new(Color.white);
        
        public bool IsMale { get; set; } = true;
        
        public string SelectedRole { get; set; }

        protected override void OnInit()
        {
        }
    }
}