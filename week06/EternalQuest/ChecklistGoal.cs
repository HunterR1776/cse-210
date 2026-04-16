public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredTimes;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int requiredTimes, int bonus)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _requiredTimes = requiredTimes;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int requiredTimes, int bonus, int timesCompleted)
        : base(name, description, points)
    {
        _requiredTimes = requiredTimes;
        _bonus = bonus;
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete()) return 0;
        _timesCompleted++;
        return _timesCompleted == _requiredTimes ? Points + _bonus : Points;
    }

    public override bool IsComplete() => _timesCompleted >= _requiredTimes;

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description}) -- Completed {_timesCompleted}/{_requiredTimes} times";
    }

    public override string GetStringRepresentation()
    {
        return $"{base.GetStringRepresentation()}|{_requiredTimes}|{_bonus}|{_timesCompleted}";
    }
}
