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

        [SerializeField]
        [Tooltip("The animation of explosion")]
        GameObject m_ExplosionBullet = null;

        public void Fire()
        {
               // Instanciar un nuevo proyectil
                GameObject newBullet = Instantiate(m_ProjectilePrefab, m_StartPoint.position, m_StartPoint.rotation);

                // Aplicar fuerza al proyectil
                Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.AddForce(m_StartPoint.forward * m_LaunchSpeed, ForceMode.Impulse);
                }

                // Instanciar la explosión en la misma posicigón y rotación que el proyectil
                GameObject explosion = Instantiate(m_ExplosionBullet, m_StartPoint.position, m_StartPoint.rotation);

                
                // Destruir la explosion
                Destroy(explosion, 1);

                // Destruir el proyectil después de un cierto tiempo
                Destroy(newBullet, 2);
    
        }

        void ApplyForce(Rigidbody rigidBody)
        {
            Vector3 force = m_StartPoint.forward * m_LaunchSpeed;
            rigidBody.AddForce(force);
        }

    }
}
