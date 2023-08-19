using System.Collections.Generic;
using UnityEngine;

public class BasePooler<T> : MonoBehaviour where T : MonoBehaviour
{
    public T m_prefab_basic;
    public List<T> m_prefab_variants;
    public int m_variant_dupe_amount;
    public int m_size;

    private List<T> m_freeList;
    private List<T> m_usedList;

    public void Awake() {
        m_freeList = new List<T>(m_prefab_variants.Count * m_variant_dupe_amount);
        m_usedList = new List<T>(m_prefab_variants.Count * m_variant_dupe_amount);

        
        //Instantiate the objects and disables them

        //Old basic ver
        //CreateObject(m_size);

        //New variants ver
        CreateObjectVariants(m_variant_dupe_amount);
    }

    public T GetObject()
    {
        var numFree = m_freeList.Count;
        if(numFree == 0)
        {
            //Old basic ver
            //CreateObject(m_size);
            //numFree = m_size;

            //New variants ver
            CreateObjectVariants(1);
            numFree = m_prefab_variants.Count;
        }

        var pooledObject = m_freeList[numFree - 1];
        m_freeList.RemoveAt(numFree - 1);
        m_usedList.Add(pooledObject);

        return pooledObject;
    }

    public void ReturnObject(T pooledObject)
    {
        if(m_usedList.Contains(pooledObject) == true)
        {
            m_usedList.Remove(pooledObject);
            m_freeList.Add(pooledObject);

            var pooledObjectTransform = pooledObject.transform;
            pooledObjectTransform.SetParent(transform);

            pooledObjectTransform.localPosition = Vector3.zero;
            pooledObjectTransform.localRotation = Quaternion.identity;
            pooledObject.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Returned object is not on the list, name of object: " + pooledObject.name);
        }
    }

    private void CreateObject(int numOfObjects)
    {
        for(int i = 0; i < numOfObjects; i++)
        {
            var pooledObject = Instantiate(m_prefab_basic, transform);
            pooledObject.gameObject.SetActive(false);
            m_freeList.Add(pooledObject);
        }
    }

    private void CreateObjectVariants(int variantDuplicateAmount)
    {
        for(int i = 0; i < variantDuplicateAmount; i++)
        {
            for(int j = 0; j < m_prefab_variants.Count; j++)
            {
                int randomIndex = Random.Range(0, m_prefab_variants.Count);
                var pooledObject = Instantiate(m_prefab_variants[randomIndex], transform);
                pooledObject.gameObject.SetActive(false);
                m_freeList.Add(pooledObject);
            }
        }
    }

    public List<T> GetAllUsedObjects()
    {
        return m_usedList;
    }
}
