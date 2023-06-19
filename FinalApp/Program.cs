using FinalApp;
using LinkedList.Singly;
using PriorityQueue;
using Trees;
using Trees.BinaryTree.BinarySearchTree;

Test();

void BinaryTreeInOrderTraverse()
{
    using (var context = new FinalAppDbContext())
    {
        var list = context.Products.Where(p => p.Price%64 == 0).ToList();
        var tree = new BinaryTree<Product>(list);
        var result = BinaryTree<Product>.PostOrderTraverse(tree.Root,new List<Product>());
        foreach (var item in result) Console.WriteLine(item);
    }
}
Console.WriteLine(Math.Pow(1.25,1.25));
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
        var list = context.Products.Where(p => p.Price < 5600 && p.Price >= 5500).ToList();
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
    List<int> list = new List<int>() { 55, 30, 58, 78, 12, 62, 14, 15, 17 };
    var result = new BST<int>(list);
    var traverse = BinaryTree<int>.LevelOrderTraverse(result.Root);
    foreach (var item in traverse) Console.WriteLine(item);
}

List<Product> getPagination(List<Product> list, int page, int pageSize)
{
    return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
}