using UnityEngine;

namespace RPG.Combat
{
    public class PatrolPath : MonoBehaviour
    {
        private const float _wayPointGizmoRadius = 0.3f;

        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Gizmos.DrawSphere(GetWayPoint(i), _wayPointGizmoRadius);
                Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(j));
            }   
        }

        internal int GetNextIndex(int i)
        {
            if (i + 1 == transform.childCount)
            {
                return 0;
            }
            return i + 1;
        }

        internal Vector3 GetWayPoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}