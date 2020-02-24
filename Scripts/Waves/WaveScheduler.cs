using System;
using System.Collections.Generic;
using UnityEngine;

namespace Waves
{
    [CreateAssetMenu(fileName = "WaveScheduler", menuName = "Scriptable Object/WaveScheduler")]
    public class WaveScheduler : ScriptableObject
    {
        public List<Wave> scheduler = new List<Wave>();

        public List<Enemy> GetListOfEnemies()
        {
            List<Enemy> listOfEnemies = new List<Enemy>();
            foreach (Wave wave in scheduler)
            {
                listOfEnemies.Add(new Enemy(null, 0, wave.timeBeforeThisWaveInSeconds));

                foreach (Enemy enemy in wave.waveData.enemyList)
                {
                    for (int i = 0; i < enemy.countOfUnits; i++)
                    {
                        listOfEnemies.Add(enemy);
                    }
                }

            }
            Debug.Log(String.Format("In wave schedule:{0} enemies total",listOfEnemies.Count));            
            return listOfEnemies;


        }
    }
}

