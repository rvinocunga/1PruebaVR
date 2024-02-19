using UnityEngine;

namespace Unity.VRTemplate
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The projectile that's created")]
        GameObject m_ProjectilePrefab = null;

        [SerializeField]
        [Tooltip("The point that the project is created")]
        Transform m_StartPoint = null;

        [SerializeField]
        [Tooltip("The speed at which the projectile is launched")]
        float m_LaunchSpeed = 0.5f;
/*
        public void Fire()
        {
            GameObject newBullet = Instantiate(m_ProjectilePrefab, m_StartPoint.position, m_StartPoint.rotation, null);

            if (newBullet.TryGetComponent(out Rigidbody rigidBody))
                ApplyForce(rigidBody);
        }
        */
        public void Fire()
        {
            GameObject newBullet = Instantiate(m_ProjectilePrefab, m_StartPoint.position, m_StartPoint.rotation, null);

            newBullet.GetComponent<Rigidbody>().AddForce(m_StartPoint.forward* m_LaunchSpeed);

            Destroy(newBullet, 2);
        }

        void ApplyForce(Rigidbody rigidBody)
        {
            Vector3 force = m_StartPoint.forward * m_LaunchSpeed;
            rigidBody.AddForce(force);
        }
    }
}
