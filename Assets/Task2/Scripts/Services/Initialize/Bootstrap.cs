using UnityEngine;

namespace Task2
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private InteractionPanel _panel;
        [SerializeField] private DefeatPanel _panelRestart;
        [SerializeField] private SpecificationPanel _panelSpecification;

        private Player _player;
        private InteractionPlayerMediator _playerMediator;
        private DefeatMediator _restartMediator;
        private SpecificationPlayerMediator _playerSpecificationMediator;

        private void Awake()
        {
            Health health = new Health(10f);
            Level level = new Level();

            _player = new Player(health, level);
            _playerMediator = new InteractionPlayerMediator(_player, _panel);
            _restartMediator = new DefeatMediator(health, _panelRestart);
            _playerSpecificationMediator = new SpecificationPlayerMediator(_panelSpecification, health, level);
        }
    }
}