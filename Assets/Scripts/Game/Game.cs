namespace Game
{
    using Framework.Core;

    public class Game : AbstractArchitecture<Game>
    {
        protected override void Init()
        {
            RegisterModel(new PlayerModel());
        }
    }
}