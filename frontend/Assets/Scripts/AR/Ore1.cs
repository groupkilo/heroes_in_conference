using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore1 : MonoBehaviour
{
    public GameObject resource;
    public GameObject obj;
    public GameObject resourceCollected;

    int hitCounter;

	void Start()
	{
        hitCounter = 0;
        resource.SetActive(!NetworkDatabase.NDB.GetAchievementWonByName("Grumpy"));
        obj.SetActive(!NetworkDatabase.NDB.GetAchievementWonByName("Grumpy"));
        resourceCollected.SetActive(NetworkDatabase.NDB.GetAchievementWonByName("Grumpy"));
	}

	void Update()
	{
        if (ARHandler.GetHitIfAny().Equals(resource.name))
        {
            hitCounter++;
        }

		if (hitCounter == 3)
		{
            Destroy(resource);
            resourceCollected.SetActive(true);
            Destroy(obj);
            ARHandler.GetAchievement("Grumpy");
		}
	}
}
