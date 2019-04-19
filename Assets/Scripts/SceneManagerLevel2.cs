﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameEye2D.Behaviour;

public class SceneManagerLevel2 : MonoBehaviour{
    public GameObject dustCloud;

    public GameObject explosions;
    public GameObject firstBarrier;
    public GameObject secondBarrier;

    public GameObject explosions2;
    public GameObject dustCloud2;
    public GameObject bombSmoke;
    public GameObject bombFire;
        public GameObject bombExplode;
    public GameObject rightDoor;

        public GameObject bomb; 
        GameObject Pit;
        public GameObject bottomBarrier;
    Shake m_CameraShake;

    public bool canWin2=false;

    private void Awake()
    {
        m_CameraShake = Camera.main.GetComponent<Shake>();
    }
    public void setWinLevel2()
    {
        canWin2 = true;
    }

    public bool getWinLevel2()
    {
        return canWin2;
    }

    void FirstBarrierExplosion(){
        //print("got here");
        m_CameraShake.ShakeCamera(2f);
        FindObjectOfType<AudioManager>().Play("Lvl1SecondCrack");
        FindObjectOfType<AudioManager>().Play("cannon");
        firstBarrier.SetActive(false);
        explosions.SetActive(true);
        dustCloud.SetActive(true);

    }
        void SecondBarrierExplosion(){
        //print("got here");
        m_CameraShake.ShakeCamera(2f);
        FindObjectOfType<AudioManager>().Play("Lvl1SecondCrack");
        FindObjectOfType<AudioManager>().Play("cannon");
        secondBarrier.SetActive(false);
        explosions2.SetActive(true);
        dustCloud2.SetActive(true);
        canWin2 = true;
        rightDoor.SetActive(true);

    }

    void BombTorch()
    {
        bombSmoke.SetActive(true);
        FindObjectOfType<AudioManager>().Play("smoke");
        bombFire.SetActive(true);
        Invoke("ExplodingRubble", 3);
    }

    void ExplodingRubble()
    {
        m_CameraShake.ShakeCamera(2f);
        FindObjectOfType<AudioManager>().Play("cannon");
        bombExplode.SetActive(true);
        bottomBarrier.SetActive(false);
        bomb.SetActive(false);
    }






}
