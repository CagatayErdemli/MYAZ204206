using FinalApp;
using LinkedList.Singly;
using PriorityQueue;
using Trees;
using Trees.BinaryTree.BinarySearchTree;

BSTPagination();

void BSTPagination()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.ToList();
        var result = getPagination(list, 7, 7);
        var tree = new BST<Product>(result);
        var product = tree.Root.Left.Value;
        tree.Remove(tree.Root, product);
        var inOrder = BinaryTree<Product>.InOrderIterationTraverse(tree.Root);
        foreach (var item in inOrder) Console.WriteLine(item);
    }
}

void SinglyPaging()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.ToList();
        var result = getPagination(list, 25, 33);
        var singly = new SinglyLinkedList<Product>();
        foreach (var item in result) singly.AddFirst(item);
        var sorted = singly.OrderBy(e => e.Price).First();
        var sortedDesc = singly.OrderByDescending(e => e.Price).First();
        Console.WriteLine($"Minimum Price: {sorted.Price}");
        Console.WriteLine($"Maximum Price: {sortedDesc.Price}");

        decimal sum = 0;
        foreach (Product product in singly) sum += product.Price;
        Console.WriteLine($"Ortalama Price: {sum / singly.Count}");
        Console.WriteLine($"Toplam Price: {sum}");
    }
}

void SinglyRemoveLast()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.Where(p => p.Price >= 250 && p.Price <= 500).ToList();
        var singly = new SinglyLinkedList<Product>();
        foreach (var item in list) singly.AddFirst(item);
        for (int i = 0; i < 128; i++)
            singly.RemoveLast();
        decimal sum = 0;
        foreach (Product product in singly) sum += product.Price;
        Console.WriteLine($"Ortalama - {sum / singly.Count}");
        Console.WriteLine($"Toplam - {sum}");
        var result = singly.OrderBy(e => e.Price).First();
        Console.WriteLine($"En Küçük - {result}");
    }
}

void BinaryTreeInOrderTraverse()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.Where(p => p.Price%4 == 0).ToList();
        var tree = new BinaryTree<Product>(list);
        var result = BinaryTree<Product>.PostOrderTraverse(tree.Root,new List<Product>());
        foreach (var item in result) Console.WriteLine(item);
    }
}

void ArrayRemove()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.ToArray();
        var array = new Array.Array<Product>();
        foreach (var item in list) array.Add(item);
        for (int i=0; i<800;i++) array.RemoveItem(0);
        Console.WriteLine($"Kapasite: {array.Capacity}");
        Console.WriteLine($"Sakladığı Eleman Sayısı: {array.Count}");
        Console.WriteLine($"İlk Eleman: {array.GetItem(0)}");
    }
}

void MaxHeapDelete()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.Where(p => p.Price < 550 && p.Price >= 500).ToList();
        var maxHeap = new MaxHeap<Product>(list);
        var result = new List<Product>();
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
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.ToList();
        var result = getPagination(list, 7, 7);
        var tree = new BST<Product>(result);
        var traverse = BinaryTree<Product>.LevelOrderTraverse(tree.Root);

        foreach (var item in traverse) Console.WriteLine(item);
    }
}

void GetProductPagingHeap()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.ToList();
        var result = getPagination(list, 10, 10);
        var heap = new MinHeap<Product>(result);
        //foreach (var item in heap) Console.WriteLine(item);
        Console.WriteLine(heap.Array.GetItem(4));
    }
}

void Test()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.ToList();
        foreach (var item in list) Console.WriteLine(item);
    }
}

List<Product> getPagination(List<Product> list, int page, int pageSize)
{
    return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
}