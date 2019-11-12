using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace tutorial_01
{
    class Program
    {
        static Func<IEnumerable<int>, IEnumerable<int>> sortFunc;
        static ObservableCollection<int> obserList = new ObservableCollection<int> { 2, -23, 233, 155, 321, 123, -90, 80 };

        static void Main(string[] args)
        {
            Console.WriteLine("please Write number: ");
            obserList.CollectionChanged += ObserList_CollectionChanged;

            sortFunc += SortDesceindig;
            sortFunc += SortAsceindig;

            // var sortedList = sortFunc(new List<int> { 1, 2, -2, 23, 123, -233, 5 });
            var sortedList = sortFunc(obserList);

            obserList.Insert(0, 42);

            //((List<int>)sortedList).ForEach(x => Console.Write($" {x} "));

        }

        public static void ObserList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"collection changed. action {e.Action}, new index is {e.NewStartingIndex}");
        }
        public static IEnumerable<int> SortAsceindig(IEnumerable<int> listToSort)
        {
            Console.WriteLine("sort Ascending..");
            return listToSort.OrderBy(x => x).ToList();
        }
        public static IEnumerable<int> SortDesceindig(IEnumerable<int> listToSort)
        {
            Console.WriteLine("sort Descending..");
            return listToSort.OrderByDescending(x => x).ToList();
        }
    }
}
