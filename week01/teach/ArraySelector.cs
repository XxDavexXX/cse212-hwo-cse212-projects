public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}

        var l3 = new[] { 'A', 'B', 'C', 'D', 'E'};
        var l4 = new[] { 'F', 'G', 'H', 'I', 'J'};
        select = new[] { 1, 1, 2, 2, 2, 1, 2, 1, 2, 2};
        var charResult = ListSelector(l3, l4, select);
        Console.WriteLine("<char[]>{" + string.Join(", ", charResult) + "}"); // <char[]>{A, A, F, F, F, A, F, A, F, F}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int[] result = new int[select.Length];
        int l1xindex = 0; 
        int l2xindex = 0; 
        int i = 0;

        while (i < select.Length)
        {
            if (select[i] == 1 && l1xindex < list1.Length)
            {
                result[i] = list1[l1xindex];
                l1xindex++;
            }
            else if (select[i] == 2 && l2xindex < list2.Length)
            {
                result[i] = list2[l2xindex];
                l2xindex++;
            }
            i++;
        }

        return result;
    }

    private static char[] ListSelector(char[] list1, char[] list2, int[] select)
    {
        char[] result = new char[select.Length];

        void FillResult(int index)
        {
            int l1xindex = 0;
            int l2xindex = 0; 
            if (index == select.Length)
                return;
            if (select[index] == 1 && l1xindex < list1.Length)
            {
                result[index] = list1[l1xindex]; 
                l1xindex++; 
            }
            else if (select[index] == 2 && l2xindex < list2.Length)
            {
                result[index] = list2[l2xindex];
                l2xindex++; 
            }

            FillResult(index + 1);
        }

        FillResult(0);

        return result;
    }


}