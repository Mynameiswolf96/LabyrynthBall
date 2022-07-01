namespace Ball
{ 
    using UnityEngine;

    public class PowerUpHealth : PowerUp
    {
        [SerializeField] private float _healthBonus = 20;

        protected override void PowerUpPayload() // Пункт 1 контрольного списка
        {
            base.PowerUpPayload();

            // Полезная нагрузка заключается в добавлении здоровья
            _unit.SetHealthAdjustment(_healthBonus);
        }
    }
}