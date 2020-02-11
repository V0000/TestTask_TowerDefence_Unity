using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UI
{
    public class TimerOnScreen : MonoBehaviour
    {
        private Text timerText;
        private bool isRunning = false;
        


        void Start()
        {
            isRunning = false;
            timerText = GetComponent<Text>();
            timerText.text = "";
            Run(10);
        }

        public void Run(int seconds)
        {
            if (!isRunning)
            {
                isRunning = true;
                StartCoroutine(Timer(seconds));
            }
        }

        private IEnumerator Timer(int seconds)
        {
            timerText.text = seconds.ToString();
            yield return new WaitForSeconds(1); //tick 1 second

            if(seconds > 1)
            {
                StartCoroutine(Timer(--seconds));
            }
            else
            {
                timerText.text = "GO!";
                yield return new WaitForSeconds(2);
                timerText.text = "";
                isRunning = false;
            }
        }
    }
}