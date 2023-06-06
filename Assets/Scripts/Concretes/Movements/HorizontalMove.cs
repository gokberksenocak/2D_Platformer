using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    public void Mover(float horizontal)
    {
        transform.Translate(_speed * Time.fixedDeltaTime * new Vector2(horizontal, 0f));
    }
}