using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectPrefab;

    public abstract bool CanPickupFor(GameObject owner);
    public virtual void ApllyItemEffect(GameObject owner)
    {
        //поставить OnAwake у партикла
        Instantiate(_effectPrefab, owner.transform.position, Quaternion.identity, null);  
    }
}

