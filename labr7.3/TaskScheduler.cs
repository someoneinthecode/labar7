using System;
using System.Collections.Generic;

public class TaskScheduler<TTask, TPriority>
{
    private SortedDictionary<TPriority, Queue<TTask>> taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
    private Func<TTask> initializeTask;
    private Action<TTask> resetTask;

    public TaskScheduler(Func<TTask> initializeTask, Action<TTask> resetTask)
    {
        this.initializeTask = initializeTask ?? throw new ArgumentNullException(nameof(initializeTask));
        this.resetTask = resetTask ?? throw new ArgumentNullException(nameof(resetTask));
    }

    public void AddTask(TTask task, TPriority priority)
    {
        if (!taskQueue.TryGetValue(priority, out var priorityQueue))
        {
            priorityQueue = new Queue<TTask>();
            taskQueue[priority] = priorityQueue;
        }

        priorityQueue.Enqueue(task);
    }

    public void ExecuteNext(Action<TTask> taskExecution)
    {
        if (taskQueue.Count > 0)
        {
            var highestPriority = taskQueue.Keys.Max();
            var highestPriorityQueue = taskQueue[highestPriority];

            if (highestPriorityQueue.Count > 0)
            {
                var nextTask = highestPriorityQueue.Dequeue();
                taskExecution(nextTask);
                resetTask(nextTask); // Reset task before putting it back in the pool
            }

            if (highestPriorityQueue.Count == 0)
            {
                taskQueue.Remove(highestPriority);
            }
        }
        else
        {
            Console.WriteLine("No tasks in the queue.");
        }
    }

    public TTask GetTaskFromPool()
    {
        return initializeTask();
    }

    public void ReturnTaskToPool(TTask task, TPriority priority)
    {
        AddTask(task, priority);
    }
}