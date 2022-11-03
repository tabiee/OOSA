using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD2257
{
    public class Generator : MonoBehaviour
    {
        public GameObject cubelet;
        private int loop = 0;
        public int limit = 20;
        public int spawnSpeed = 40;
        public Transform spawnPoint;
        void SpawnLimit()
        {
            Instantiate(cubelet, spawnPoint.position, spawnPoint.rotation);
            limit--;
        }

        void Update()
        {
            if (loop < spawnSpeed)
            {
                loop++;
            }
            else if (loop == spawnSpeed & limit > 0)
            {
                loop = 0;
                SpawnLimit();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                limit += 5;
            }
        }
    }
}
