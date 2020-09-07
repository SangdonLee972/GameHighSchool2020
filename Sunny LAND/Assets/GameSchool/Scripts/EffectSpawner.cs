using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    public GameObject m_EffectPrefab;
    public ItemComponet item;

    public void SpawnEffect()
    {
        GameObject.Instantiate(m_EffectPrefab, transform.position, transform.rotation);
    }

    public void destoryEffect()
    {
        Destroy(gameObject);
    }
}
