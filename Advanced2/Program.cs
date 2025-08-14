using AdvancesCsharb2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Numerics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advanced2
{
    internal class Program
    {

        #region Q2
        public static void ReverseArrayList(ArrayList list)
        {
            int left = 0;
            int right = list.Count - 1;
            while (left < right)
            {
                object temp = list[left];
                list[left] = list[right];
                list[right] = temp;

                left++;
                right--;
            }
        }
        #endregion
        #region Q5
        //Given a Queue, implement a function to reverse the elements of a queue using a stack.
        public static void ReverseQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }

        #endregion

        #region Q6

        static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();

                    if ((ch == ')' && top != '(') ||
                        (ch == ']' && top != '[') ||
                        (ch == '}' && top != '{'))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
        #endregion
        #region Q7
        //Given an array, implement a function to remove duplicate elements from an array.
        public static int[] RemoveDuplicates(int[] arr)
        {
            HashSet<int> uniqueElements = new HashSet<int>(arr);
            return uniqueElements.ToArray();
        }
        #endregion
        #region Q8
        //Given an array list, implement a function to remove all odd numbers from it.
        public static void RemoveOddNumbers(ArrayList list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] is int number && number % 2 != 0)
                {
                    list.RemoveAt(i);
                }
            }
        }
        static Stack<int> CreateStack()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            return stack;
        }

        #endregion
        #region Q11
        static List<int> FindIntersection(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            List<int> result = new List<int>();

            foreach (int num in arr1)
            {
                if (freq.ContainsKey(num))
                    freq[num]++;
                else
                    freq[num] = 1;
            }

            foreach (int num in arr2)
            {
                if (freq.ContainsKey(num) && freq[num] > 0)
                {
                    result.Add(num);
                    freq[num]--;
                }
            }

            return result;
        }
        #endregion

        #region Q13
        static void ReverseFirstKElements(Queue<int> queue, int k)
        {
            if (k > queue.Count || k <= 0)
            {
                Console.WriteLine("Invalid value of K");
                return;
            }

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            int remaining = queue.Count - k;
            for (int i = 0; i < remaining; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }
        #endregion
        #region Q12
        static List<int> FindSubList(List<int> arr, int target)
        {
            int start = 0;
            int currentSum = 0;

            for (int end = 0; end < arr.Count; end++)
            {
                currentSum += arr[end];

                while (currentSum > target && start <= end)
                {
                    currentSum -= arr[start];
                    start++;
                }

                if (currentSum == target)
                {
                    List<int> result = new List<int>();
                    for (int i = start; i <= end; i++)
                        result.Add(arr[i]);
                    return result;
                }
            }

            return new List<int>(); 
        }

        #endregion
        static void Main(string[] args)
        {
            #region Q1
            int[] arr = { 5, 2, 1, 5, 2, 7, 9, 3 };

            Console.WriteLine("Array before sort ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Array after sort ");
            Helper<int>.BubbleSort(arr);
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            #endregion

            #region Q2
            ArrayList mylist = new ArrayList() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            Console.WriteLine("arrlist before reverse");
            foreach (var i in mylist)
                Console.Write(i + " ");
            Console.WriteLine();

            ReverseArrayList(mylist);

            Console.WriteLine("arrlist after reverse");
            foreach (var i in mylist)
                Console.Write(i + " ");
            Console.WriteLine();

            #endregion

            #region Q3
            //Given an array consists of numbers with size N and number of queries, in each query you will be given an integer X, and you should print how many numbers in array that is greater than  X.
            //Ex:
            //Input
            //3 3                //Size of array , number of queries
            //11 5 3             //Array 
            //1                  //Query1
            //5                  //Query2
            //13                 //Query 3
            //Output
            //3                  //11,5,3
            // 1                 //11
            //0

            int n = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int[] arr3 = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr3[i] = int.Parse(Console.ReadLine());
            }
            List<int> results = new List<int>();

            for (int i = 0; i < q; i++)
            {
                int x = int.Parse(Console.ReadLine());
                int countt = 0;

                foreach (int num in arr3)
                {
                    if (num > x)
                        countt++;
                }

                results.Add(countt);
            }

            foreach (int res in results)
            {
                Console.WriteLine(res);
            }

            #endregion

            #region Q4
            //Given a number N and an array of N numbers. Determine if it's palindrome or not.
            //Ex:
            //Input:
            //5
            //1 3 2 3 1
            //Output:
            //YES
            int number = int.Parse(Console.ReadLine());
            int[] arr4 = new int[number];
            for (int i = 0; i < number; i++)
            {
                arr4[i] = int.Parse(Console.ReadLine());
            }
            bool isPalindrome = true;
            for (int i = 0; i < number / 2; i++)
            {
                if (arr4[i] != arr4[number - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }

            }
            Console.WriteLine(isPalindrome ? "YES" : "NO");

            #endregion

            #region Q5
            //Given a Queue, implement a function to reverse the elements of a queue using a stack.
            Queue<int> queue = new Queue<int>();
            int size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                queue.Enqueue(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine("Queue before reverse");
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            ReverseQueue(queue);
            Console.WriteLine("Queue after reverse");
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            #endregion

            #region Q6
            string input = Console.ReadLine();

            if (IsBalanced(input))
                Console.WriteLine("Balanced");
            else
                Console.WriteLine("Not Balanced");

            #endregion

            #region Q7
            //Given an array, implement a function to remove duplicate elements from an array.
            int[] arr7 = { 1, 2, 3, 4, 5, 1, 2, 3 };
            Console.WriteLine("Array before removing duplicates:");
            foreach (var item in arr7)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            int[] uniqueArray = RemoveDuplicates(arr7);
            Console.WriteLine("Array after removing duplicates:");
            foreach (var item in uniqueArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            #endregion

            #region Q8
            //Given an array list, implement a function to remove all odd numbers from it.
            ArrayList arrList = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("ArrayList before removing odd numbers:");
            foreach (var item in arrList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            RemoveOddNumbers(arrList);
            Console.WriteLine("ArrayList after removing odd numbers:");
            foreach (var item in arrList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            #endregion
            #region Q9

            //Implement a queue that can hold different data types.
            //And insert the following data:
            //            queue.Enqueue(1)
            //queue.Enqueue(“Apple”)
            //queue.Enqueue(5.28)
            Queue<object> qu = new Queue<object>();
            qu.Enqueue(1);
            qu.Enqueue("Apple");
            qu.Enqueue(5.28);
            Console.WriteLine("Queue with different data types:");
            foreach (var item in qu)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Q10
            Stack<int> stack = CreateStack();

            Console.WriteLine("Enter the target integer:");
            int target = int.Parse(Console.ReadLine());

            int count = 0;
            bool found = false;

            while (stack.Count > 0)
            {
                count++;
                int element = stack.Pop();

                if (element == target)
                {
                    found = true;
                    Console.WriteLine($"Target was found successfully and the count = {count}");
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Target was not found");
            }

            #endregion

            #region Q11
            int[] arr1 = { 1, 2, 3, 4, 4 };
            int[] arr2 = { 10, 4, 4 };

            List<int> intersection = FindIntersection(arr1, arr2);

            Console.WriteLine("Intersection: [" + string.Join(", ", intersection) + "]");

            #endregion
            #region Q12
            List<int> arrr = new List<int>() { 1, 2, 3, 7, 5 };
            int targett = 12;

            List<int> subList = FindSubList(arrr, targett);

            if (subList.Count > 0)
                Console.WriteLine("Sublist: [" + string.Join(", ", subList) + "]");
            else
                Console.WriteLine("No sublist found with the target sum");
        
        #endregion
        #region Q13
        Queue<int> que = new Queue<int>();
        que.Enqueue(1);
        que.Enqueue(2);
        que.Enqueue(3);
        que.Enqueue(4);
        que.Enqueue(5);

        int k = 3;
        Console.WriteLine("Original Queue: " + string.Join(", ", que));

        ReverseFirstKElements(que, k);

        Console.WriteLine($"Queue after reversing first {k} elements: " + string.Join(", ", que));
    }
    #endregion
}


}
