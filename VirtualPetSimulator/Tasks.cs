namespace VirtualPetSimulator;

public enum TaskTypes
{
    GeneralTask,
    FeedTask,
    PlayTask
}

[Serializable]
public class Tasks(string? description, int progression, int times, int taskReward, TaskTypes type, bool completed)
{
    public string? description { get; set; } = description;
    public int progression { get; set; } = progression;
    public int times { get; set; } = times;
    public int taskReward { get; set; } = taskReward;
    public TaskTypes type { get; set; } = type;
    public bool completed { get; set; } = completed;

    public static Tasks CreateTask()
    {
        TaskTypes type = Random.Shared.Next(0, 3) switch
        {
            0 => TaskTypes.FeedTask,
            1 => TaskTypes.PlayTask,
            3 => TaskTypes.GeneralTask,
            _ => TaskTypes.GeneralTask
        };
        return new Tasks(GetTaskDescription(type), 0, 5, 100, type, false);
    }

    public static void TaskUi()
    {
        Console.WriteLine("=================");
        Console.WriteLine($"Task description: {Program.CurrentTask.description}");
        Console.WriteLine($"Task progression: {Program.CurrentTask.progression}/{Program.CurrentTask.times}");
        Console.WriteLine($"Task reward: {Program.CurrentTask.taskReward}");
        Console.WriteLine($"Task type: {GetTaskType(Program.CurrentTask.type)}");
        Console.WriteLine($"Task completed: {Program.CurrentTask.completed}");
        Console.WriteLine("=================");
        Console.ReadLine();
        Pet.PetUi();
    }

    public static bool TaskCompleted()
    {
        return Program.CurrentTask.progression == Program.CurrentTask.times;
    }

    public static string GetTaskDescription(TaskTypes type)
    {
        return type switch
        {
            TaskTypes.FeedTask => "Feed your pet 5 times",
            TaskTypes.PlayTask => "Play with your pet 5 times",
            TaskTypes.GeneralTask => "Pet your pet or feed your pet 5 times",
            _ => "Task not found"
        };
    }

    public static string GetTaskType(TaskTypes type)
    {
        return type switch
        {
            TaskTypes.FeedTask => "Feed Task",
            TaskTypes.PlayTask => "Play Task",
            TaskTypes.GeneralTask => "General Task",
            _ => "Task not found"
        };
    }

    public static void GetReward()
    {
        if (Program.CurrentTask.completed)
        {
            Program.Data.Money += Program.CurrentTask.taskReward;
        }
    }
}