using Task2.PlayersComponent;
using Task2.Mediators;
using Task2.UI.Panels;
using Task2.Config;
using UnityEngine;
using Zenject;

namespace Task2.Zenject
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private SpecificationPanel _specificationPanel;
        [SerializeField] private InteractionPanel _interactionPanel;
        [SerializeField] private DefeatPanel _defeatPanel;

        public override void InstallBindings()
        {
            BindPlayer();
            BindMonoBehaviourComponent();
            BindMediators();
        }

        private void BindPlayer()
        {
            Container.BindInterfacesAndSelfTo<Level>().AsSingle();
            Container.BindInterfacesAndSelfTo<Health>().AsSingle();
            Container.BindInterfacesAndSelfTo<Player>().AsSingle();
        }

        private void BindMonoBehaviourComponent()
        {
            Container.BindInterfacesAndSelfTo<SpecificationPanel>().FromInstance(_specificationPanel);
            Container.BindInterfacesAndSelfTo<InteractionPanel>().FromInstance(_interactionPanel);
            Container.BindInterfacesAndSelfTo<DefeatPanel>().FromInstance(_defeatPanel);
        }

        private void BindMediators()
        {
            Container.BindInterfacesAndSelfTo<SpecificationPlayerMediator>().AsSingle();
            Container.BindInterfacesAndSelfTo<InteractionPlayerMediator>().AsSingle();
            Container.BindInterfacesAndSelfTo<DefeatMediator>().AsSingle();
        }
    }
}