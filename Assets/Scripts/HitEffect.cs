using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField]
    GameObject hitPrefab;

    [SerializeField]
    private int prefabCount = 10;

    private List<GameObject> hitPool = new List<GameObject>();

    private Player player;

    private void Awake()
    {
        for (int i = 0; i < prefabCount; i++)
        {
            GameObject prefab = Instantiate(hitPrefab, transform);
            prefab.SetActive(false);

            hitPool.Add(prefab);
        }

        player = transform.GetComponentInParent<Player>();
        player.OnHit += Player_OnHit;
    }

    private void Player_OnHit(object sender, System.EventArgs e)
    {
        var hit = GetPrefab();

        hit.transform.position = new Vector3(2, 0, 0);
        hit.SetActive(true);
    }

    private GameObject GetPrefab()
    {

        GameObject prefab = hitPool.Find((p) => p.active == false);

        if (prefab == null)
        {
            return hitPool.First();
        }

        return prefab;
    }
}
