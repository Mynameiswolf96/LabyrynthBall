class PowerUpHealth : PowerUp
{
    public int healthBonus = 20;

    protected override void PowerUpPayload()  // Пункт 1 контрольного списка
    {
        base.PowerUpPayload();

        // Полезная нагрузка заключается в добавлении здоровья
        _health.SetHealthAdjustment(healthBonus);      
    }
}