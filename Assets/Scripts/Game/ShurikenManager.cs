using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShurikenManager : MonoBehaviour
{
    [SerializeField] private int startNumberOfShurikens; 
    private int maxNumberOfShurikens;
    private int currentNumberOfShurikens;
    private int NumberOfSpawningShurikens;

    [SerializeField] private Transform[] positionForSpawnShuriken;

    private List<Shuriken> shurikens;
    [SerializeField] private Shuriken[] shurikenPrefabs;
    [SerializeField] private CoinManager CoinManager;

    private List<Transform> jumpedOverShurikenTransforms = new();

    void Awake()
    {
        shurikens = transform.GetComponentsInChildren<Shuriken>().ToList();
        foreach (Shuriken shuriken in shurikens)
        {
            shuriken.ShurikenManager = this;
            shuriken.gameObject.SetActive(false);
        }
    }

    public void StartWork()
    {
        maxNumberOfShurikens = startNumberOfShurikens;
        currentNumberOfShurikens = 0;
        NumberOfSpawningShurikens = 0;

        jumpedOverShurikenTransforms.Clear();

        if (shurikens != null)
        {
            foreach (Shuriken shuriken in shurikens)
            {
                shuriken.gameObject.SetActive(false);
            }

            SpawnShurikens();
        }

        Ninja.NinjaIsGrounded += OnninjaIsGrounded;
    }

    public void IncreaseMaxNumberOfShurikens(int additionalNumber)
    {
        maxNumberOfShurikens += additionalNumber;

        SpawnShurikens();
    }

    public void StopWork()
    {
        Ninja.NinjaIsGrounded -= OnninjaIsGrounded;
    }

    private void SpawnShurikens()
    {
        if (currentNumberOfShurikens >= maxNumberOfShurikens) return;

        NumberOfSpawningShurikens = maxNumberOfShurikens - currentNumberOfShurikens;

        for (int i = 0; i < NumberOfSpawningShurikens; i++)
        {
            SpawnShuriken(positionForSpawnShuriken[Random.Range(0, 2)].position);
            currentNumberOfShurikens++;
        }
    }


    public void AddPositionForSpawnCoin(Transform transform)
    {
        jumpedOverShurikenTransforms.Add(transform);
    }

    private void OnninjaIsGrounded()
    {
        for(int i = 0; i < jumpedOverShurikenTransforms.Count; i++)
        {
            CoinManager.SpawnCoin(jumpedOverShurikenTransforms[i].position);
            jumpedOverShurikenTransforms[i].gameObject.SetActive(false);
            currentNumberOfShurikens--;
        }


        jumpedOverShurikenTransforms.Clear();

        SpawnShurikens();
    }

    public void SpawnShuriken(Vector2 spawnPosition)
    {
        for (int i = 0; i < shurikens.Count; i++)
        {
            if (!shurikens[i].gameObject.activeSelf)
            {

                shurikens[i].transform.position = spawnPosition;
                shurikens[i].gameObject.SetActive(true);
                break;
            }

            if (i == shurikens.Count - 1)
            {
                Shuriken additionalShuriken = Instantiate(shurikenPrefabs[Random.Range(0, shurikenPrefabs.Length)], this.transform);
                additionalShuriken.ShurikenManager = this;
                additionalShuriken.transform.position = spawnPosition;
                additionalShuriken.gameObject.SetActive(false);
                shurikens.Add(additionalShuriken);
            }
        }
    }
}
