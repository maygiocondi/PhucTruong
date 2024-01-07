using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class PoolingSupply<T> : MonoBehaviour where T : Component
{
    [SerializeField] protected T prefab;

    protected List<T> pool = new List<T>();

    public virtual T GetSupply(Vector3 pos, Quaternion rot)
    {
        var supply = pool.FirstOrDefault(t => !t.gameObject.activeInHierarchy);
        if (supply == null)
        {
            supply = Instantiate(prefab, pos, rot);
            pool.Add(supply);
        }
        supply.gameObject.SetActive(true);
        supply.transform.position = pos;
        

        return supply;
    }
}
