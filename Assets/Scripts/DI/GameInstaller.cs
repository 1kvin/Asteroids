using GameLogic.Input;
using Zenject;

namespace DI
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerInput>().To<PlayerKeyboardAndMouseInput>().AsSingle();
        }
    }
}
