using UnityEngine;

namespace _Dev.Game.Scripts.Components
{
    public class MoverComponent : MonoBehaviour
    {
        [SerializeField] private float m_speed;
        
        private Transform _target;
        
        public void SetMoveTarget(Transform target)
        {
            _target = target;
        }
        
        private void Update()
        {
            if (_target == null) return;

            Move();
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, m_speed * Time.deltaTime);
        }
    }
}