﻿using UnityEngine;
using System.Collections;

namespace Buildings
{
	public class BarracksSpawnController : SpawnController 
	{
		public TypesOfUnits typesOfUnits;
		public int level = 1;
		public bool isWarriorDefault = true;   
		//private int maxLevel;

		protected override void Start () {

			base.Start();
			// maxLevel = typesOfUnits.minionWarriors.Length;
			spawnTime = selectedUnit.trainingTime;
			StartCoroutine(SpawnPerTime(spawnTime));
		}
		
		
		override protected UnitData GetUnitForBuild()
		{
			UnitData levelData;
			if (isWarriorDefault)
			{
				levelData = typesOfUnits.minionWarriors[level-1]; //level start with 1, but array with 0
			 }

			else
			{
				levelData = typesOfUnits.minionArchers[level-1];
			}
			return levelData;
		}
	}
}
