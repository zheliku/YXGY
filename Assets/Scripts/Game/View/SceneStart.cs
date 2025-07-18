using System;
using Framework.Core;
using Framework.Toolkits.SingletonKit;

namespace Game
{
    public class SceneStart : MonoSingleton<SceneStart>
    {
        [HierarchyPath("/RoleShowCase (Gender)")]
        public RoleShowCase GenderShowCase;
        
        [HierarchyPath("/RoleShowCase (Boys)")]
        public RoleShowCase BoyShowCase;
        
        [HierarchyPath("/RoleShowCase (Girls)")]
        public RoleShowCase GirlShowCase;
        
        [HierarchyPath("/UIDialog")]
        public UIDialog UIDialog;

        private void Awake()
        {
            this.BindHierarchyComponent();
        }
    }
}