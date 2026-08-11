using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, string points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        int percent = (int)((double)_amountCompleted / _target * 100);
        int filledBars = percent / 10;
        if (filledBars > 10) filledBars = 10;
        string progressBar = "[" + new string('█', filledBars) + new string('░', 10 - filledBars) + "]";
        return $"{status} {GetShortName()} ({GetDescription()}) {progressBar} {percent}% ({_amountCompleted}/{_target})";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_target},{_bonus},{_amountCompleted}";
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }
}