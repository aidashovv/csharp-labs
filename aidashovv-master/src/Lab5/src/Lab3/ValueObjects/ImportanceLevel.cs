namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public class ImportanceLevel
{
    public ImportanceLevel(int level)
    {
        Level = level;
    }

    public int Level { get; private set; }

    public bool IsRead { get; private set; } = false;

    public void ChangeStatus()
    {
        IsRead = true;
    }
}