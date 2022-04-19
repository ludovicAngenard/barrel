using UnityEngine;
namespace player{
    class Player : MonoBehaviour {
        private int life;
        private int score;
        public int getLife(){
            return this.life;
        }
        public  void setLife(int life){
            this.life = life;
        }
        public int getScore(){
            return this.score;
        }
        public void setScore(int score){
            this.score = score;
        }
    }
}