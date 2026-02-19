using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timeText;

    [SerializeField] VoidEventChannel_SO levelStartEventChannel;
    [SerializeField] VoidEventChannel_SO levelStopEventChannel;

    bool stop = true;

    float clearTime = 0;

    private void OnEnable()
    {
        levelStartEventChannel.AddListener(TimerStart);
        levelStopEventChannel.AddListener(TimerStop);
    }
    private void OnDisable()
    {
        levelStartEventChannel.RemoveListener(TimerStart);
        levelStopEventChannel.RemoveListener(TimerStop);
    }


    private void FixedUpdate()
    {
        //人物可以移动时计时器开始计时
        if (stop) return;

        //在UI上显示事件
        clearTime += Time.fixedDeltaTime;
        timeText.text = System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
    }

    void TimerStart()
    {
        stop = false;
    }
    void TimerStop()
    {
        stop = true;
    }
}
