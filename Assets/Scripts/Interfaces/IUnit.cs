using UnityEngine;
namespace Ball
{
    public interface IUnit
    {
        public void Hit(float damage);
        public void SetHealthAdjustment(float heal);
        //public void Hit(float damage);
    }
}