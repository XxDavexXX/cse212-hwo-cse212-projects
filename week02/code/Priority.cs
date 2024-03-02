public static class Priority {
    public static void Test() {
        // Test Cases

        // Test 1
        // Scenario: I add products with different priorities,
        // then we remove them from the queue to verify the order.
        // Expected result: I remove the elements from the queue in descending priority order.
        Console.WriteLine("Test 1");
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("product 1", 3);
        priorityQueue.Enqueue("product 2", 1);
        priorityQueue.Enqueue("product 3", 5);
        priorityQueue.Enqueue("product 4", 2);
        while (priorityQueue.Length > 0) {
            Console.WriteLine(priorityQueue.Dequeue());
        }
        // Defect(s) Found None in the queve.

        Console.WriteLine("---------");

        // Test 2
          // Scenario: Attempting to dequeue an empty priority queue.
          // Expected result: error message is displayed.
        Console.WriteLine("Test 2");
        priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
        // Defect(s) Found: No check for empty queue before dequeuing.

        Console.WriteLine("---------");
    }
}
