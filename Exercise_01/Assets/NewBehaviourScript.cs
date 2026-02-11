using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //变量
    public int heath = 5;
    public float speed = 5.5f;
    public bool isJump;//默认是false
    public string name = "Michael";
    public GameObject player;
    public Transform playermovement;

    void Awake()//无论script是否启动，都在开始的时候运行
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello Michael!");
        Debug.Log(name);
        Debug.Log(player);
    }

    // Update is called once per frame 每秒执行多少帧的次数
    void Update()
    {
        
    }
}