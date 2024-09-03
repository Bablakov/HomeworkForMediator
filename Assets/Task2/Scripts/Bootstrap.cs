using UnityEngine;

namespace Task2
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Panel _panel;
        [SerializeField] private PanelSpecification _panelSpecification;

        private Player _player;
        private PlayerMediator _playerMediator;
        private PlayerSpecificationMediator _playerSpecificationMediator;

        private void Awake()
        {
            Health health = new Health(10);
            Level level = new Level();

            _player = new Player(health, level);
            _playerMediator = new(_player, _panel);
            _playerSpecificationMediator = new PlayerSpecificationMediator(_panelSpecification, health, level);
        }
    }
}