using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1942
{
    class Enemy
    {
        int hp;
        int move;
        Boolean triggered;
        Random r = new Random();

        public Enemy(int hp, int move, Boolean triggered)
        {
            this.hp = hp;
            this.move = move;
        }

        public int gethp()
        {
            return hp;
        }

        public int getMove()
        {
            move = r.Next(3);
            return move;
        }

        public Boolean isTriggered()
        {
            int trigger = r.Next(21);
            if(trigger == 0)
            {
                triggered = true;
                return triggered;            
            }
            triggered = false;
            return triggered;
        }

    }
}
