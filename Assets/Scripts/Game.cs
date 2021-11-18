using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject ballPrefab;
    List<GameObject> ballList;

    void Start()
    {
        ballList = new List<GameObject>();
        NewGame();
    }
    public void NewGame() {
        foreach(GameObject g in ballList) {
            Destroy(g);
		}
        ballList.Add(Object.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity));
    }
}
