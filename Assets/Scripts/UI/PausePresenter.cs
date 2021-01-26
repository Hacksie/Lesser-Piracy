using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign.UI
{
    public class PausePresenter : AbstractPresenter
    {
        

        public override void Repaint()
        {
           
        }

        public void ResumeEvent()
        {
            GameManager.Instance.SetPlaying();
        }

        public void CloseEvent()
        {
            GameManager.Instance.SetMainMenu();
        }        
    }
}