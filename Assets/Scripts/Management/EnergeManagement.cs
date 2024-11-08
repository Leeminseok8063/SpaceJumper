using Assets.Scripts.Data;
using System;
using UnityEngine;

namespace Assets.Scripts.Adapters
{
    public class EnergeManagement : MonoBehaviour
    {
        private float maxEnerge;
        private float currentEnerge;
        private float energeRecoverVal;
        private float energeDrainVal;

        public float CurrentEnerge { get { return currentEnerge; } }
        public bool CanUseEnerge
        {
            get 
            {
                if (currentEnerge >= energeDrainVal * Time.deltaTime)
                    return true;
                else return false;
            }
        }
        
        MovementAdapter movement;
        PlayerData playerData;
        
        private void Start()
        {
            playerData = PlayerCore.Instance.PlayerData;
            movement = PlayerCore.Instance.MovementAdapter;
         
            maxEnerge = playerData.energe;
            currentEnerge = maxEnerge;
            energeRecoverVal = playerData.energeRecover;
            energeDrainVal = playerData.energeDrain;
        }

        private void Update()
        {
            if(movement.isBoost) UseEnerge(energeDrainVal * Time.deltaTime);     
            else RecoverEnerge(energeRecoverVal * Time.deltaTime);
        }

        public void UseEnerge(float val)
        {
            currentEnerge = MathF.Max(currentEnerge - val, 0f);        
        }

        public void RecoverEnerge(float val)
        {
            currentEnerge = Mathf.Min(currentEnerge + val, maxEnerge);
        }
    }
}
