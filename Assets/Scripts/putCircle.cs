using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class putCircle : MonoBehaviour
{

    private Vector2 nowPos, pos;
    public GameObject circle;
    public gameManager gm;
    [SerializeField] AudioClip[] clips;
    protected AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        source = GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            nowPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            pos = new Vector2(nowPos.x, this.transform.position.y);
            
            if(pos.x < Camera.main.ViewportToWorldPoint(Vector2.zero).x) {
                // 左端を超えない
                pos = new Vector2(Camera.main.ViewportToWorldPoint(Vector2.zero).x, pos.y);
            }else if(Camera.main.ViewportToWorldPoint(Vector2.one).x < pos.x) {
                // 右端を超えない
                pos = new Vector2(Camera.main.ViewportToWorldPoint(Vector2.one).x, pos.y);
            }

            this.transform.position = pos;
        }

        


        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            circle = (GameObject)Resources.Load ("Prefab/Circle"+gm.selectNextBall());
            Instantiate(circle, this.transform.position - new Vector3(0,1,0), Quaternion.identity);
            source.PlayOneShot(clips[0]);
            Thread.Sleep(500);
        }

        

    }
}
