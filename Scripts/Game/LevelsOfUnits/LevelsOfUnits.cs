using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Scriptable Object/New Level")] 
public class LevelsOfUnits : ScriptableObject {

	public LevelSettings[] level;
}

[System.Serializable]
public class LevelSettings {


}