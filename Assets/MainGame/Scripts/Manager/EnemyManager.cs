using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<WolfStateManager> wolfs = new List<WolfStateManager>();
    private List<CatStateManager> cats = new List<CatStateManager>();
    private List<RabbitStateManager> rabbits = new List<RabbitStateManager>();

    public static EnemyManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddToWolfs(WolfStateManager addWolf)
    {
        if (!wolfs.Contains(addWolf))
            wolfs.Add(addWolf);
    }

    public void RemoveWolf(WolfStateManager removeWolf)
    {
        wolfs.Remove(removeWolf);
    }

    public void AddToCats(CatStateManager addCat)
    {
        if (!cats.Contains(addCat))
            cats.Add(addCat);
    }

    public void RemoveCat(CatStateManager removeCat)
    {
        cats.Remove(removeCat);
    }

    public void AddToRabbits(RabbitStateManager rabbit)
    {
        if (!rabbits.Contains(rabbit))
            rabbits.Add(rabbit);
    }

    public void RemoveRabbit(RabbitStateManager rabbit)
    {
        rabbits.Remove(rabbit);
    }

    public List<WolfStateManager> GetWolfs()
    {
        return wolfs;
    }

    public List<CatStateManager> GetCats()
    {
        return cats;
    }

    public List<RabbitStateManager> GetRabbits()
    {
        return rabbits;
    }
}
