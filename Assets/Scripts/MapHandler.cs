using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace Assets
{
    public class MapHandler : MonoBehaviour
    {
        public static MapHandler instance = null;
        public List<Collider> _checkpointList = new List<Collider>();
        public List<GameObject> _switches = new List<GameObject>();
        public Vector3 _startPoint;
        public Collider _endPoint;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public void SwitchTrack(int whichOne)
        {
            try
            {
                var s1 = _switches[0];
                var s2 = _switches[1];
                
                s1.SetActive(!s1.activeSelf);
                s2.SetActive(!s2.activeSelf);
            }
            catch (NullReferenceException lmao)
            {
                Debug.LogError(lmao);
            }
        }
    }
}