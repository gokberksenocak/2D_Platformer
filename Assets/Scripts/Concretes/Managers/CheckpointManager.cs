using Project.Concretes.Combats;
using Project.Concretes.Controllers;
using System.Linq;
using UnityEngine;

namespace Project.Concretes.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        [SerializeField] private CheckpointController[] _checkpointControllers;
        private Health _health;
        private void Awake()
        {
            _checkpointControllers = GetComponentsInChildren<CheckpointController>();
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        }
        private void OnEnable()
        {
            _health.OnHealtChanged += BackToCheckpointPosition;
        }

        private void OnDisable()
        {
            _health.OnHealtChanged -= BackToCheckpointPosition;
        }
        private void BackToCheckpointPosition()
        {
            if (!_checkpointControllers.LastOrDefault(x => x.IsPassed)) _health.transform.position = _health.GetComponent<PlayerController>().FirstPos;
            else _health.transform.position = _checkpointControllers.LastOrDefault(x => x.IsPassed).transform.position;
        }
    }
}