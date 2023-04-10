using CollectionConsoleApp;

var list1 = new List<Customer>()
{
    new Customer(){Id = 1, FullName ="Ahmet Can"},
    new Customer(){Id = 2, FullName ="Mehmet Dağ"},
    new Customer(){Id = 3, FullName ="Fatma Güneş"},
    new Customer(){Id = 4, FullName ="Can Bulut"},
    new Customer(){Id = 5, FullName =" Canan Nehir"}
};

// home
var list2 = new List<Customer>()
{
     new Customer(){Id = 1, FullName ="Ahmet Can"},
     new Customer(){Id = 4, FullName ="Can Bulut"},
     new Customer(){Id = 6, FullName ="Melike Güneş"},
};

var result = new List<Customer>();

foreach (var item in list1)
{
    if (list2.Select(c => c.Id).Contains(item.Id)) result.Add(item);
}

result.ForEach(c => Console.WriteLine(c));