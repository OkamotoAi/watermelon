using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameoverUI;
    private int score;
    [SerializeField] AudioClip[] clips;
    protected AudioSource source;

    private int nowCircleNum = 1;
    private int nextCircleNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        source = GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int s){
        this.score += s;
        scoreText.text = "Score: " + this.score.ToString();
        source.PlayOneShot(clips[0]);
    }

    public void gameOver(){
        Time.timeScale = 0;
        gameoverUI.SetActive(true);
    }

// Nextに表示する次の球を選ぶ
    public void selectNextBall(){
        float max;
        if(9 <= Mathf.Log10(score)){
            max = 9;
        }else if(score < 20){
            max = 2.5f;
        }else{
            max = Mathf.Log(2,score) + 1;
            
        }

        nowCircleNum = nextCircleNum;
        nextCircleNum = (int)UnityEngine.Random.Range(1,max);
        Debug.Log("max:"+max+" now"+nowCircleNum+" next"+nextCircleNum);
    }

    public GameObject instantiateCircle(int circleNum, Vector3 pos){
            return Instantiate((GameObject)Resources.Load ("Prefab/Circle"+circleNum),
                    pos, Quaternion.identity);
    }

    public int getNowCircleNum(){
        return this.nowCircleNum;
    }

    public int getNextCircleNum(){
        return this.nextCircleNum;
    }
}
