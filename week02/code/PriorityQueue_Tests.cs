using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Insert 3 elements with different priorities.
    // Enqueue("A", 1), Enqueue("B", 3), Enqueue("C", 2)
    // Expected Result: Dequeue() returns B, then C, then A
    // Requirement(s) tested: 
    // - Higher priority items are dequeued first.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Insert 3 elements with the same priority.
    // Enqueue("X", 5), Enqueue("Y", 5), Enqueue("Z", 5)
    // Expected Result: Dequeue() returns X, then Y, then Z (FIFO order)
    // Requirement(s) tested:
    // - Among items with same priority, dequeue follows FIFO order.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 5);
        pq.Enqueue("Y", 5);
        pq.Enqueue("Z", 5);

        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Call Dequeue() on an empty queue.
    // Expected Result: InvalidOperationException should be thrown with message "The queue is empty."
    // Requirement(s) tested:
    // - Dequeue from empty queue throws appropriate exception.
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
