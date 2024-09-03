namespace Task2
{
    public class Player
    {
        private Health _health;
        private Level _level;

        public Player(Health health, Level level)
        {
            _health = health;
            _level = level;
        }
    
        public void Damage(int damage) => _health.Damage(damage);

        public void Heal(int heal) => _health.Heal(heal);

        public void RaiseLevel() => _level.RaiseLevel();
    }
}