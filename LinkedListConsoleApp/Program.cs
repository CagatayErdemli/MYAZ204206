using LinkedList.Singly;

var linkedList = new SinglyLinkedList<int>();
linkedList.AddLast(10);
linkedList.AddLast(20);
linkedList.AddLast(30);

Console.WriteLine(linkedList.Head.Value);
Console.WriteLine(linkedList.Head.Next.Value);
Console.WriteLine(linkedList.Head.Next.Next.Value);