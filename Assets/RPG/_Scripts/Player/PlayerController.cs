using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private Mover _mover;
        private Fighter _fighter;
        private CombatTarget _combatTarget;
        private Health _health;

        private void Start()
        {
            _mover = GetComponent<Mover>();
            _fighter = GetComponent<Fighter>();
            _combatTarget = GetComponent<CombatTarget>();
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            if (_health.IsDead())
            {
                return;
            }

            if (InteractWithCombat())
            {
                return;
            }
            
            if(InteractWithMovement())
            {
                return;
            }

            print("Nothing to do");
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit)
            {
                if ((Input.GetMouseButton(0)))
                {
                    _mover.MoveTo(hit.point);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
               CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                //_combatTarget target = hit.transform;

                if (target == null)
                {
                    continue;
                }

                if(!GetComponent<Fighter>().CanAttack(target.gameObject))
                {
                    continue;
                }

                if(Input.GetMouseButton(0))
                {
                    _fighter.Attack(target.gameObject);
                }
                return true;
            }
            return false;
        }

    #region Main Methods

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        #endregion

    }
}
