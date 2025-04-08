using System;

namespace CreatureApp.Models
{
    public class Turtle : Creature
    {
        public Turtle()
        {
            MaxSpeed = 10;
            SpeedStep = 1;
            CurrentSpeed = 0;
        }

        public override void Move()
        {
            CurrentSpeed = Math.Min(CurrentSpeed + SpeedStep, MaxSpeed);
        }

        public override void Stop()
        {
            CurrentSpeed = Math.Max(CurrentSpeed - SpeedStep, 0);
        }
    }
}