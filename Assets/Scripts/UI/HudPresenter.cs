using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace HackedDesign.UI
{
    public class HudPresenter : AbstractPresenter
    {
        [SerializeField] private UnityEngine.UI.Text projectilesText = null;
        [SerializeField] private UnityEngine.UI.Text speedText = null;
        [SerializeField] private UnityEngine.UI.Text trueStateLabel = null;
        [SerializeField] private UnityEngine.UI.Text falseStateLabel = null;
        [SerializeField] private Ship playerShip = null;
        [SerializeField] private List<UnityEngine.UI.Text> leaderboard;
        

        public override void Repaint()
        {
            projectilesText.text = playerShip.CurrentChests.ToString();
            speedText.text = playerShip.CurrentSpeed.ToString();
            trueStateLabel.gameObject.SetActive(playerShip.CurrentLaunchState);
            falseStateLabel.gameObject.SetActive(!playerShip.CurrentLaunchState);

            var ships = new List<Ship>(GameManager.Instance.Ships).OrderByDescending(s => s.transform.position.z).ToList();

            for(int i = 0; i < leaderboard.Count; i++)
            {
                leaderboard[i].text = i.ToString() + ". " + ships[i].name;
            }

        }
    }
}