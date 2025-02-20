using UnityEngine;

namespace Assets
{
    public class GooberSpawnerTEST : MonoBehaviour
    {
        public GameObject gooberPrefab;

        private int shpeeeeed = 0;

        private void FixedUpdate()
        {
            shpeeeeed++;
            if (shpeeeeed == 25)
            {
                shpeeeeed = 0;
                Instantiate(gooberPrefab).transform.position = transform.position;

            }
        }
    }
}
