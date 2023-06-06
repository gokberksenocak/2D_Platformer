using Project.Abstracts.Inputs;
using UnityEngine;

namespace Project.Concretes.Inputs
{
    public class PcInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool IsJumpPressed => Input.GetButtonDown("Jump");

       
    }
}