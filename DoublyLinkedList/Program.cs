using System;

namespace DoublyLinkedList
{
    public class BusStop
    {
        public int number;
        public string name;
        public string time;
        public BusStop(int number, string name, string time)
        {
            this.number = number;
            this.name = name;
            this.time = time;
        }
        public BusStop() 
        {

        }
        public static void RegisterData(MyList list)
        {
            Console.WriteLine("How many bus stops?");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter Bus stop number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Bus stop name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter bus stop time: ");
                string time = Console.ReadLine();
                list.AddEnd(new BusStop(number, name, time));
            }
            Console.Clear();
            Console.WriteLine("Bus stops registered!");
        }
    }
    public class Node
    {
        public int numberOfNodes = 0; //keeps track of number of nodes in list
        public Node previous; //doubly linked list, each node knows next and previous.
        public Node next;
        public BusStop busStop; //data will be busstop data
        public Node(BusStop busStop)
        {
            this.busStop = busStop;
            numberOfNodes++; //counting up once a new node which busstop data is made.
        }
    }
    public class MyList
    {
        public Node firstNode;
        public Node current;
        public Node temp;
        public void AddEnd(BusStop busStop) //adding a new node at the end of the list.
        {
            Node node = new Node(busStop); //node to add
            if (firstNode == null)
            {
                firstNode = node; //just one node, firstNode
                firstNode.previous = null;
                firstNode.next = null;
            }
            else
            {
                current = firstNode;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = node;
                node.previous = current;
                node.next = null;
            }

        }
        public void Insert(BusStop busStop, int indexAfter) // inserts new node at index (index after prefered index)
        {
            Node node = new Node(busStop); //node to insert

            int ithNode = 1; //node counter
            current = firstNode;
            while (ithNode != indexAfter)
            {
                current.next = firstNode;
                ithNode++;
            }
            temp = current.next; //inserting temp node to not lose pointers
            current.next = node;
            node.next = temp;
            temp.previous = node;
            node.previous = current;
        }
        public void RemoveAt(int index) //removes node at specified index (index after prefered index)
        {
            int ithNode = 0; //node counter
            current = firstNode;
            if (index == 0) //deleting first node
            {
                firstNode = current.next;
                current.next = null;
                current.previous = null;
            }
            else
            {
                while (ithNode != index)
                {
                    current = current.next;
                    ithNode++;
                }
                if (current.next == null) //end of list
                {
                    current.previous.next = null;
                    current.previous = null;
                }
                else
                {
                    current.previous.next = current.next;
                    current.next.previous = current.previous;
                }
            }
        }
        public void Clear() //clears list
        {
            firstNode = null;
            current = null;
        }
        public void PrintAZ()
        {
            current = firstNode;
            do
            {
                Console.WriteLine("Bus stop number: {0}, Bus stop name: {1}, Bus stop time: {2}", current.busStop.number, current.busStop.name, current.busStop.time);
                current = current.next;
            } while (current != null);
        }
        public void PrintZA()
        {
            current = firstNode;
            while (current.next != null) //goes through the list forwards.
            {
                current = current.next;
            }
            do //going through the list backwards. setting current as previous in every iteration
            {
                Console.WriteLine("Bus stop number: {0}, Bus stop name: {1}, Bus stop time: {2}", current.busStop.number, current.busStop.name, current.busStop.time);
                current = current.previous;
            } while (current != null); //so it displays the first value of list 
        }
        public int Count()
        {
            int count = 0; //define counter
            current = firstNode;
            while (current != null)
            {
                current = current.next;
                count++;
            }
            return count;
        }
        public BusStop ElementAt(int index)
        {
            int counter = 0;
            Node current = firstNode;
            while (current != null)
            {
                if (counter == index)
                {
                    break; //stop loop
                }
                current = current.next;
                counter++;
            }
            //for existing and non existing values 
            if (current != null)
            {
                return current.busStop;
            }
            else
            {
                return null;
            }
        }
    }
    class Program
    {
        static void InsertBusStop(MyList list)
        {
            Console.WriteLine("Enter index after insertion position: ");
            int indexAfter = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Bus stop number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Bus stop name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter bus stop time: ");
            string time = Console.ReadLine();
            try
            {
                list.Insert(new BusStop(number, name, time), indexAfter);
            }
            catch (Exception)
            {
                Console.WriteLine("Insertion unsuccesfull. Try a different index.");
            }
        }
        static void RemoveBusStop(MyList list)
        {
            Console.WriteLine("Enter index you would like to remove: ");
            int index = Convert.ToInt32(Console.ReadLine());
            try
            {
                list.RemoveAt(index);
            }
            catch (Exception)
            {
                Console.WriteLine("Removal unsuccesfull. Check index.");
            }
        }
        static void BusStopByIndex(MyList list)
        {
            Console.WriteLine("Enter index:");
            int index = Convert.ToInt32(Console.ReadLine());
            BusStop temp = new BusStop();
            try
            {
                temp = list.ElementAt(index);
                Console.WriteLine("Found info: ");
                Console.WriteLine("------------------");
                Console.WriteLine("Number: {0}, Name: {1}, Time: {2}", temp.number, temp.name, temp.time);
            }
            catch (Exception)
            {
                Console.WriteLine("No info found, check index.");
            }
        }
        static void Main(string[] args)
        {
            MyList list = new MyList();

            Console.WriteLine("MENU");
            Console.WriteLine("=====================");
            int choice = 0;
            do
            {
                Console.WriteLine("Choose your action: \n\n[1] Register bus stops\n[2] Print info A - Z\n[3] Print info Z - A\n[4] Insert a bus stop\n[5] Display count of bus stops\n[6] Remove a bus stop at an index\n[7] Return info about bus stop at index\n[8] Clear list\n[9] Exit");
                Console.WriteLine("");
                int userInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
                switch (userInput)
                {
                    case 1:
                        BusStop.RegisterData(list);
                        break;
                    case 2:
                        list.PrintAZ();
                        break;
                    case 3:
                        list.PrintZA();
                        break;
                    case 4:
                        InsertBusStop(list);
                        break;
                    case 5:
                        Console.WriteLine("Count: {0}", list.Count());
                        break;
                    case 6:
                        RemoveBusStop(list);
                        break;
                    case 7:
                        BusStopByIndex(list);
                        break;
                    case 8:
                        list.Clear();
                        Console.WriteLine("List cleared!");
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Theres no such choice");
                        Console.ReadLine();
                        break;
                }
            } while (choice != 9);
        }
    }
}
