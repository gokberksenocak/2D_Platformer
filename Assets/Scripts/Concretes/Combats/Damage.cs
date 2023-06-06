using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Concretes.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private int _damageValue;
        public int DamageValue => _damageValue;
    }
}