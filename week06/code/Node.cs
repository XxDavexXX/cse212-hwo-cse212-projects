public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        this.Data = data;
    }

    public void Insert(int value) {
        if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value) {
        if (value == Data) {
            return true;
        } else if (value < Data && Left != null) {
            return Left.Contains(value);
        } else if (value > Data && Right != null) {
            return Right.Contains(value);
        } else {
            return false;
        }
    }

    public int GetHeight() {
        return GetHeightRecursive(this);
    }

    private int GetHeightRecursive(Node node) {
        if (node is null) {
            return 0;
        } else {
            int leftHeight = GetHeightRecursive(node.Left);
            int rightHeight = GetHeightRecursive(node.Right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }

}