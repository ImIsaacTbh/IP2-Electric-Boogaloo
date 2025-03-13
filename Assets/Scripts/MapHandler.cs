using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets
{
    public class MapHandler : MonoBehaviour
    {
        public static MapHandler instance = null;
        public List<Collider> _checkpointList = new List<Collider>();
        public Vector3 _startPoint;
        public Collider _endPoint;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
    }
}