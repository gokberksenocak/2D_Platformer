using UnityEngine;

namespace Project.Concretes.Movements
{
    public class Flip : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public void FlipToCharacter(float horizontal)
        {
            if (Mathf.Sign(horizontal) > 0) _spriteRenderer.flipX = false;
            else _spriteRenderer.flipX = true;
        }
    }
}