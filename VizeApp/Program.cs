using PriorityQueue;
using Trees;
using Trees.BinaryTree.BinarySearchTree;
using VizeApp;
using LinkedList.Singly;

BSTPagination();

void BSTPagination()
{
    using (var context = new VizeAppDbContext())
    {
        var list = context.Employees.ToList();
        var result = getPagination(list, 7, 7);
        var tree = new BST<Employee>(result);
        var emp = tree.Root.Left.Left.Value;
        tree.Remove(tree.Root, emp);
        var inOrder = BinaryTree<Employee>.InOrderIterationTraverse(tree.Root);
        foreach (var item in inOrder) Console.WriteLine(item);
    }
}

void SinglyPaging()
{
    using (var context = new VizeAppDbContext())
    {
        var list = context.Employees.ToList();
        var result = getPagination(list, 25, 33);
        var singly = new SinglyLinkedList<Employee>();
        foreach (var item in result) singly.AddFirst(item);
        var sorted = singly.OrderBy(e => e.Salary).First();
        var sortedDesc = singly.OrderByDescending(e => e.Salary).First();
        Console.WriteLine($"Minimum Salary: {sorted.Salary}");
        Console.WriteLine($"Maximum Salary: {sortedDesc.Salary}");

        decimal sum = 0;
        foreach (Employee emp in singly) sum += emp.Salary;
        Console.WriteLine($"Ortalama Maaş: {sum / singly.Count}");
        Console.WriteLine($"Toplam Maaş: {sum}");
    }
}

void SinglyRemoveLast()
{
    using (var context = new VizeAppDbContext())
    {
        var list = context.Employees.Where(p => p.Salary>=250 && p.Salary<=500).ToList();
        var singly = new SinglyLinkedList<Employee>();
        foreach (var item in list) singly.AddFirst(item);
        for (int i = 0; i < 128; i++)
            singly.RemoveLast();
        decimal sum = 0;
        foreach (Employee emp in singly) sum+=emp.Salary;
        Console.WriteLine(sum/singly.Count);
        Console.WriteLine(sum);
        var result = singly.OrderBy(e => e.Salary).First();
        Console.WriteLine(result);
    }
}

void BinaryTreeInOrderTraverse()
{
    using (var context = new VizeAppDbContext())
    {
        var list = context.Employees.Where(p => p.Salary % 250 == 0).ToList();
        var tree = new BinaryTree<Employee>(list);
        var result = BinaryTree<Employee>.LevelOrderTraverse(tree.Root);
        foreach (var item in result) Console.WriteLine(item);
    }
}

void ArrayRemove()
{
    using (var context = new VizeAppDbContext())
    {
        var list = context.Employees.ToArray();
        var array = new Array.Array<Employee>();
        foreach (var item in list) array.Add(item);
        for (int i = 0; i < 800; i++) array.RemoveItem(0);
        Console.WriteLine($"Kapasite: {array.Capacity}");
        Console.WriteLine($"Sakladığı Eleman Sayısı: {array.Count}");
        Console.WriteLine($"İlk Eleman: {array.GetItem(0)}");
    }
}

void MaxHeapDelete()
{
    using (var context = new VizeAppDbContext())
    {
        var list = context.Employees.Where(p => p.Salary <= 950 && p.Salary >= 900).ToList();
        var maxHeap = new MaxHeap<Employee>(list);
        var result = new List<Employee>();
        for (int i = 0; i < 5; i++)
        {
            var c = maxHeap.DeleteMinMax();
            result.Add(c);
        }
        foreach (var item in result) Console.WriteLine(item);
    }
}

void GetProductPaging()
{
    using (var context = new VizeAppDbContext())
    {
        var list = context.Employees.ToList();
        var result = getPagination(list, 7, 7);
        var tree = new BST<Employee>(result);
        var traverse = BinaryTree<Employee>.LevelOrderTraverse(tree.Root);

        foreach (var item in traverse) Console.WriteLine(item);
    }
}

void GetProductPagingHeap()
{
    using (var context = new VizeAppDbContext())
    {
        var list = context.Employees.ToList();
        var result = getPagination(list, 10, 10);
        var heap = new MinHeap<Employee>(result);
        foreach (var item in heap) Console.WriteLine(item);
        //Console.WriteLine(heap.Array.GetItem(5));
    }
}

void Test()
{
    List<int> list = new List<int>() { 55, 30, 58, 78, 12, 62, 14, 15, 17 };
    var result = new BST<int>(list);
    var traverse = BinaryTree<int>.LevelOrderTraverse(result.Root);
    foreach (var item in traverse) Console.WriteLine(item);
}

List<Employee> getPagination(List<Employee> list, int page, int pageSize)
{
    return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
}