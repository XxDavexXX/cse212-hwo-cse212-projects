public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var service = new CustomerService(10);
        // Console.WriteLine(service);

        // Test Cases

        // Test 1
        // Scenario: Can I add a customer and then serve the customer?
        // Expected Result: This should display the customer that was added
        Console.WriteLine("Test 1");
        var service = new CustomerService(4);
        service.AddNewCustomer();
        service.ServeCustomer();
        // Defect(s) Found: This found that the ServeCustomer should get the customer before deleting from the list

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Can I add two customers and then serve the customers in the right order?
        // Expected Result: This should display the customers in the same order that they were entered
        Console.WriteLine("Test 2");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");
        // Defect(s) Found: None :)

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Can I serve a customer if there is no customer?
        // Expected Result: This should display some error message
        Console.WriteLine("Test 3");
        service = new CustomerService(4);
        service.ServeCustomer();
        // Defect(s) Found: This found that I need to check the length in serve_customer and display an error message

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Does the max queue size get enforced?
        // Expected Result: This should display some error message when the 5th one is added
        Console.WriteLine("Test 4");
        service = new CustomerService(4);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Service Queue: {service}");
        // Defect(s) Found: This found that I need to do >= instead of > in AddNewCustomer

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Does the max size get defaulted to 10 if an invalid value is provided?
        // Expected Result: It should display 10
        Console.WriteLine("Test 5");
        service = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {service}");
        // Defect(s) Found: None :)
    }

    private readonly Queue<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    public class Customer {
        public string Name { get; }
        public string AccountId { get; }
        public string Problem { get; }

        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    public void AddNewCustomer() {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        var customer = new Customer(name, accountId, problem);
        _queue.Enqueue(customer);
    }

    public void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        }

        var customer = _queue.Dequeue();
        Console.WriteLine(customer);
    }

    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
