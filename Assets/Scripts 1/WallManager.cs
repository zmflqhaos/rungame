using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float cooltime;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for(int i=0; i<4; i++)
        {
            Instantiate(prefab);
            yield return new WaitForSeconds(cooltime);
        }
    }
}
