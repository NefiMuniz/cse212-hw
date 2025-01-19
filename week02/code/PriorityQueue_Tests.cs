using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add a single item to the queue and then dequeue it.
    // Expected Result: The item is dequeued successfully, and its value matches the enqueued value.
    // Defect(s) Found: Baseline test, no defect pointed.
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("Item1", result, "The dequeued value should match the enqueued value.");
    }

    [TestMethod]
    // Scenario: Add multiple items with different priorities and dequeue the highest-priority item.
    // Expected Result: The item with the highest priority is dequeued, and its value matches the expected value.
    // Defect(s) Found: The loop in Dequeue does not iterate over the last item, so the last item's priority is ignored.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("MediumPriority", 3);
        priorityQueue.Enqueue("HighPriority", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("HighPriority", result, "The dequeued value should be the item with the highest priority.");
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority and dequeue one item.
    // Expected Result: The first item with the highest priority (closest to the front) is dequeued.
    // Defect(s) Found: The loop in Dequeue incorrectly prioritizes the last item with the highest priority due to the use of ">=".
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 5);
        priorityQueue.Enqueue("SecondHigh", 5);

        var firstResult = priorityQueue.Dequeue();
        var secondResult = priorityQueue.Dequeue();

        // First dequeue should return the first enqueued item with the highest priority
        Assert.AreEqual("FirstHigh", firstResult, "The first dequeued value should be the first item with the highest priority.");
        
        // Second dequeue should return the second enqueued item with the same priority
        Assert.AreEqual("SecondHigh", secondResult, "The second dequeued value should be the second item with the same priority.");
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: No defects expected. This tests proper exception handling for an empty queue.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "Dequeueing an empty queue should throw an exception.");
    }
}