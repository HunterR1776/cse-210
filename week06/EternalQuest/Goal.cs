public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    protected int Points => _points;

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();

    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}|{_name}|{_description}|{_points}";
    }
}
