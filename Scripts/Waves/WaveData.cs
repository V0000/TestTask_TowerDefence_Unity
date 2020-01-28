using System.Collections.Generic;
using UnityEngine;

namespace Waves
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Object/WaveData")]
    public class WaveData : ScriptableObject
    {
        public List<Enemy> enemyList = new List<Enemy>();
    }
}

