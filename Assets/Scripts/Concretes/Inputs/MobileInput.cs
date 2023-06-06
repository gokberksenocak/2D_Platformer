using Project.Abstracts.Inputs;
using UnityEngine;

namespace Project.Concretes.Inputs
{
    public class MobileInput : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool IsJumpPressed => Input.GetButtonDown("Jump");//mobil input degiller ama interface alistirmasi icin ikinci bir sinif olusturdum
    }
}