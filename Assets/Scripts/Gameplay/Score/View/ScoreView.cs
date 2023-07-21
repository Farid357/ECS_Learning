using TMPro;
using UnityEngine;

namespace Game
{
    public class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private TMP_Text _text;
        
        public void Visualize(in ScoreComponent score)
        {
            _text.text = score.Count.ToString();
        }
    }
}