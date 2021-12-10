using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Jumlah musuh
    public int jumlahEnemy;
    //Jumlah musuh sekarang
    public int jumlahEnemyCount;

    //test object munculin kalau menang
    public GameObject winObject;

    void Start()
    {
        PlayerPrefs.SetInt("JumlahEnemy", jumlahEnemy);   
    }

    // Update is called once per frame
    void Update()
    {
        jumlahEnemyCount = PlayerPrefs.GetInt("JumlahEnemy");

        //Do something here when win
        if (jumlahEnemyCount == 0)
        {
            winObject.SetActive(true);
        }
    }

    void winCondition()
    {   
        //Do something here when win
        if (jumlahEnemyCount == 0)
        {
            winObject.SetActive(true);
        }
        
    }
}
