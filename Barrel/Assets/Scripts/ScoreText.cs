using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NamespaceGameManager;
using UnityEngine.UI;

namespace Score{
    public class ScoreText : MonoBehaviour
    {
        // Start is called before the first frame update
        private Text scoreText;
        void Start()
        {
            scoreText = GetComponent<Text>();
        }
        public void UpdateScoreText(string text){
            scoreText.text = text;
        }
    }
}
