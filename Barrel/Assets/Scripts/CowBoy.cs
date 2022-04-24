using UnityEngine;
namespace cowboy{
    class CowBoy : MonoBehaviour {
        private int life;
        private float sprintSpeed = 8.0f;
        private float walkSpeed = 4.0f;

        public float getWalkSpeed(){
            return walkSpeed;
        }
        public float getSprintSpeed(){
            return sprintSpeed;
        }
        public int getLife(){
            return this.life;
        }
        public  void setLife(int life){
            this.life = life;
        }

    }
}