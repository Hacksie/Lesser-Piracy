using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign.UI
{
    public class ReadyPresenter : AbstractPresenter
    {
        [SerializeField] private UnityEngine.UI.Text countdownText = null;

        public int Count { get; set; }
        

        public override void Repaint()
        {
            if(Count == 0)
            {
                countdownText.text = "Tallyho!";
            }
            else 
            {
            countdownText.text = Count.ToString();
            }
        }
    }
}