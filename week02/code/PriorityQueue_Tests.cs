using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Insert 3 elements with different priorities.
    // Enqueue("A", 1), Enqueue("B", 3), Enqueue("C", 2)
    // Expected Result: Dequeue() returns B, then C, then A
    // Defect(s) Found: Original implementation did not correctly sort by priority.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue(), "Expected 'B' because it has the highest priority (3).");
        Assert.AreEqual("C", pq.Dequeue(), "Expected 'C' because it has the second highest priority (2).");
        Assert.AreEqual("A", pq.Dequeue(), "Expected 'A' because it has the lowest priority (1).");
    }

    [TestMethod]
    // Scenario: Insert 3 elements with the same priority.
    // Enqueue("X", 5), Enqueue("Y", 5), Enqueue("Z", 5)
    // Expected Result: Dequeue() returns X, then Y, then Z (FIFO order)
    // Defect(s) Found: Original implementation did not preserve FIFO order for same priority.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 5);
        pq.Enqueue("Y", 5);
        pq.Enqueue("Z", 5);

        Assert.AreEqual("X", pq.Dequeue(), "Expected 'X' because it was inserted first (FIFO for equal priority).");
        Assert.AreEqual("Y", pq.Dequeue(), "Expected 'Y' because it was inserted second (FIFO for equal priority).");
        Assert.AreEqual("Z", pq.Dequeue(), "Expected 'Z' because it was inserted third (FIFO for equal priority).");
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Call Dequeue() on an empty queue.
    // Expected Result: InvalidOperationException should be thrown with message "The queue is empty."
    // Defect(s) Found: Original implementation did not check for empty queue.
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown when calling Dequeue() on an empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message, "Expected message 'The queue is empty.' when Dequeue is called on an empty queue.");
        }
    }

    [TestMethod]
    // Scenario: Check if queue is empty using IsEmpty().
    // Enqueue one element and dequeue it. Then check IsEmpty().
    // Expected Result: IsEmpty() should return true after all elements are removed.
    // Defect(s) Found: None
    public void TestPriorityQueue_IsEmptyCheck()
    {
        var pq = new PriorityQueue();
        Assert.IsTrue(pq.IsEmpty(), "Expected IsEmpty() to return true on a new empty queue.");

        pq.Enqueue("Only", 1);
        Assert.IsFalse(pq.IsEmpty(), "Expected IsEmpty() to return false after adding one item.");

        pq.Dequeue();
        Assert.IsTrue(pq.IsEmpty(), "Expected IsEmpty() to return true after removing the only item.");
    }
}
