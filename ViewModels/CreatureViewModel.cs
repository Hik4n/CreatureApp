using System;
using System.Collections.ObjectModel;
using System.Reactive;
using CreatureApp.Models;
using ReactiveUI;

namespace CreatureApp.ViewModels
{
    public class CreatureViewModel : ReactiveObject
    {
        public ObservableCollection<string> CreatureTypes { get; } = new()
        {
            "Panther", "Dog", "Turtle"
        };

        private int _selectedCreatureIndex;
        public int SelectedCreatureIndex
        {
            get => _selectedCreatureIndex;
            set => this.RaiseAndSetIfChanged(ref _selectedCreatureIndex, value);
        }

        private string _creatureInfo = string.Empty;
        public string CreatureInfo
        {
            get => _creatureInfo;
            set => this.RaiseAndSetIfChanged(ref _creatureInfo, value);
        }

        public ReactiveCommand<Unit, Unit> MoveCommand { get; }
        public ReactiveCommand<Unit, Unit> StopCommand { get; }
        public ReactiveCommand<Unit, Unit> MakeSoundCommand { get; }
        public ReactiveCommand<Unit, Unit> ClimbTreeCommand { get; }

        public bool IsPantherSelected => SelectedCreatureIndex == 0;
        public bool IsDogSelected => SelectedCreatureIndex == 1;
        public bool IsTurtleSelected => SelectedCreatureIndex == 2;
        public bool CanMakeSound => IsPantherSelected || IsDogSelected;

        private Creature? _currentCreature;

        public CreatureViewModel()
        {
            MoveCommand = ReactiveCommand.Create(Move);
            StopCommand = ReactiveCommand.Create(Stop);
            MakeSoundCommand = ReactiveCommand.Create(MakeSound);
            ClimbTreeCommand = ReactiveCommand.Create(ClimbTree);

            this.WhenAnyValue(x => x.SelectedCreatureIndex)
                .Subscribe(_ => UpdateCreature());
        }

        private void UpdateCreature()
        {
            _currentCreature = SelectedCreatureIndex switch
            {
                0 => new Panther(),
                1 => new Dog(),
                2 => new Turtle(),
                _ => throw new ArgumentOutOfRangeException()
            };
            UpdateInfo();
        }

        private void Move()
        {
            _currentCreature?.Move();
            UpdateInfo();
        }

        private void Stop()
        {
            _currentCreature?.Stop();
            UpdateInfo();
        }

        private void MakeSound()
        {
            if (_currentCreature is ICanMakeSound soundCreature)
            {
                soundCreature.MakeSound();
                CreatureInfo += $"\n{soundCreature.GetLastSound()}";
            }
        }

        private void ClimbTree()
        {
            if (_currentCreature is Panther panther)
            {
                panther.ClimbTree();
                CreatureInfo += $"\n{panther.GetClimbStatus()}";
            }
        }

        private void UpdateInfo()
        {
            if (_currentCreature == null) return;
            
            CreatureInfo = $"Type: {_currentCreature.GetType().Name}\n" +
                          $"Speed: {_currentCreature.CurrentSpeed}\n" +
                          $"State: {_currentCreature.GetState()}";
        }
    }
}