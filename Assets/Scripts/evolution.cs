using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evolution : MonoBehaviour
{
    private string largerPath;
    public GameObject larger;
    public gameManager gm;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        string name = this.gameObject.name;
        num = name[6] - '0';
        num += 1;
        largerPath = "Prefab/Circle"+ num;
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != this.gameObject.name)
        {
            return;
        }
        
        if(collision.gameObject.transform.position.x > this.gameObject.transform.position.x ){

            GameObject.Destroy(this.gameObject);
            return;
        }

        if(collision.gameObject.transform.position.x == this.gameObject.transform.position.x &&
                collision.gameObject.transform.position.y > this.gameObject.transform.position.y){
            
            GameObject.Destroy(this.gameObject);
            return;
        }

        // より左下なオブジェクトをけす
        // 作成する
        larger = (GameObject)Resources.Load (largerPath);
        Instantiate(larger, this.transform.position, Quaternion.identity);
        
        GameObject.Destroy(this.gameObject);

        gm.addScore(num);

    }
}
