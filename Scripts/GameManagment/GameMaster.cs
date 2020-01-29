using System.Collections;
using Units.Health;
using UnityEngine;

namespace GameManagment
{
    public class GameMaster : MonoBehaviour
    {
        private float gold;


        #region Properties


        public float Gold
        {
            get
            {
                return gold;
            }
            set
            {
                if (value > 0)
                {
                    gold = value;
                }
            }
        } 

        #endregion


        public void AddGold(float num)
        {
            if (num > 0)
            {
                gold += num;
            }
        }

        public void TakeGold(float num)
        {
            if (num > 0)
            {
                gold -= num;
            }
        }



    }
}
