/*
 * Copyright (c) 2017 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using UnityEngine;

namespace Ball
{

    public class PowerUp : MonoBehaviour
    {
        [Tooltip(
            "Tick true for power ups that are instant use, eg a health addition that has no delay before expiring")]
        [SerializeField]
        private bool expiresImmediately;

        /// It is handy to keep a reference to the player that collected us

        protected IUnit _unit;

        protected enum PowerUpState
        {
            InAttractMode,
            IsCollected,
            IsExpiring
        }

        protected PowerUpState powerUpState;

        protected virtual void Start()
        {
            powerUpState = PowerUpState.InAttractMode;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            PowerUpCollected(other.gameObject);
        }

        protected void PowerUpCollected(GameObject gameObjectCollectingPowerUp)
        {
            _unit = gameObjectCollectingPowerUp.GetComponent<IUnit>();

            if (_unit == null)
            {
                return;
            }

            // We only care if we've not been collected before
            if (powerUpState == PowerUpState.IsCollected || powerUpState == PowerUpState.IsExpiring)
            {
                return;
            }

            powerUpState = PowerUpState.IsCollected;

            // We must have been collected by a player, store handle to player for later use      
            // Payload      
            PowerUpPayload();

            // Now the power up visuals can go away
            Destroy(gameObject);
        }

        protected virtual void PowerUpPayload()
        {
            Debug.Log("Power Up collected, issuing payload for: " + gameObject.name);

            // If we're instant use we also expire self immediately
            if (expiresImmediately)
            {
                PowerUpHasExpired();
            }
        }

        protected void PowerUpHasExpired()
        {
            if (powerUpState == PowerUpState.IsExpiring)
            {
                return;
            }

            powerUpState = PowerUpState.IsExpiring;

            Debug.Log("Power Up has expired, removing after a delay for: " + gameObject.name);
            DestroySelfAfterDelay();
        }

        protected void DestroySelfAfterDelay()
        {
            Destroy(gameObject, 10f);
        }
    }
}