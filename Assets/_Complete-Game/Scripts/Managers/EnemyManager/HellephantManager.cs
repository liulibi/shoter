using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class HellephantManager : EnemyManager
    {
        [SerializeField] private float minimumTimeToBorn;

        public override void Spawn()
        {
            base.Spawn();

            spawnTime -= 0.05f;
            if (spawnTime < minimumTimeToBorn)
            {
                spawnTime = minimumTimeToBorn;
            }
        }
    }
}