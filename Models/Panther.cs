using System;

namespace CreatureApp.Models
{
    public class Panther : Creature, ICanMakeSound, ICanClimbTree
    {
        private string _lastSound = "";
        private bool _isOnTree = false;

        public Panther()
        {
            MaxSpeed = 80;
            SpeedStep = 10;
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
            _lastSound = "Growl!";
        }

        public string GetLastSound()
        {
            return _lastSound;
        }

        public void ClimbTree()
        {
            _isOnTree = !_isOnTree;
        }

        public string GetClimbStatus()
        {
            return _isOnTree ? "Climbed on the tree" : "Descended from the tree";
        }
    }
}