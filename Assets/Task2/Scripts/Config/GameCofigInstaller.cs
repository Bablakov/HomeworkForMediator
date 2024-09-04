using Zenject;
using UnityEngine;
using Task2.Config;

namespace Assets.Task2.Scripts.Config
{
    [CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "Configs/GameConfigInstaller")]
    public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
    {
        [SerializeField] private PlayerConfig _playerConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig);
        }
    }
}
