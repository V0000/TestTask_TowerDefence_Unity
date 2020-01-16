using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Scriptable Object/New Wave")] 
public class Waves : ScriptableObject {

	public WaveSettings[] wave;
}

[System.Serializable]
public class WaveSettings {


}