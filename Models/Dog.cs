using System;

namespace CreatureApp.Models
{
    public class Dog : Creature, ICanMakeSound
    {
        private string _lastSound = "";

        public Dog()
        {
            MaxSpeed = 30;
            SpeedStep = 5;
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

        public void MakeSound()
        {
            _lastSound = "Bark!";
        }

        public string GetLastSound()
        {
            return _lastSound;
        }
    }
}