using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackedDesign
{
    public class EndTrigger : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            // End game
            if(other.CompareTag("Player"))   
            {
                if(other.gameObject == GameManager.Instance.Player.gameObject)
                {
                    GameManager.Instance.SetGameWin();
                }
                else 
                {
                    GameManager.Instance.SetGameLose();
                }
            }
        }
    }
}