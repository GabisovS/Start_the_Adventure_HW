using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _deathParticle;
    [SerializeField] private int _force;

    public void Launch(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
    }

    public void DestroyEffect()
    {
        ParticleSystem deathEffect = Instantiate(_deathParticle, transform.position, Quaternion.identity);
        deathEffect.Play();
    }
}
