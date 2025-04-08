namespace CreatureApp.Models
{
    public abstract class Creature
    {
        public double MaxSpeed { get; protected set; }
        public double CurrentSpeed { get; protected set; }
        public double SpeedStep { get; protected set; }

        public abstract void Move();
        public abstract void Stop();
        
        public virtual string GetState()
        {
            return CurrentSpeed > 0 ? "Moving" : "Standing";
        }
    }

    public interface ICanMakeSound
    {
        void MakeSound();
        string GetLastSound();
    }

    public interface ICanClimbTree
    {
        void ClimbTree();
        string GetClimbStatus();
    }
}