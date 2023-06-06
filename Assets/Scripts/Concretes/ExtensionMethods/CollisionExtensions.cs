using Project.Concretes.Controllers;
using UnityEngine;

namespace Project.Concretes.ExtensionMethods
{
    public static class CollisionExtensions
    {
        public static bool HasItEnemy(this Collision2D collision)
        {
            return collision.collider.GetComponent<EnemyController>() != null;
        }

        public static bool HasHitLeftOrRightSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.x > .6f || collision.contacts[0].normal.x < -.6f;
        }

        public static bool HasHitTopSide(this Collision2D collision)
        {
            return collision.contacts[0].normal.y > 0.6f;
        }
    }
}