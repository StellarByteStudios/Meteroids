using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExplosionFragments : MonoBehaviour
{
    [SerializeField]
    GameObject[] fragments;
    public float decayTime = 1f;

    public void spawnFragments()
    {
        int fragmentcount = UnityEngine.Random.Range(3, 6);

        for (int i = 0; i < fragmentcount; i++)
        {
            Quaternion orientation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
            Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            int fragmentType = UnityEngine.Random.Range(0, fragments.Length);

            GameObject fragment = Instantiate(fragments[fragmentType], pos, orientation);
            Destroy(fragment, decayTime);
        }
    }
}
