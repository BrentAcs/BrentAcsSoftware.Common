namespace BrentAcsSoftware.Common.Leisure.Utilities;

// public interface IRandomChanceTableEntry
// {
//    double? Chance { get; }
// }

public interface IRandomChanceTable<T>
{
   T? GetByChance(double roll);
}

public abstract class RandomChanceTable<T> : IRandomChanceTable<T> //where T : IRandomChanceTableEntry
{
   private record Entry<T>(double? Chance, T? Value);

   private IList<Entry<T>> _entries = new List<Entry<T>>();

   protected abstract void BuildTable();

   protected void AddEntry(double? chance, T? value)
   {
      _entries.Add(new Entry<T>(chance, value));

      if (_entries.Count(e => e.Chance is null) > 1)
         throw new Exception("RawEntries contains multiple entries w/ defaulted chance (null).");

      _entries = _entries.OrderBy(i => i.Chance).ToList();
      if (_entries.FirstOrDefault()?.Chance is null)
      {
         var nullChanceEntry = _entries[ 0 ];
         _entries.RemoveAt(0);
         _entries.Add(nullChanceEntry);
      }
   }

   private void ValidateEntries()
   {
      if (_entries.Any())
         return;

      BuildTable();
   }

   public T? GetByChance(double roll)
   {
      ValidateEntries();
      double current = 0;

      foreach (var item in _entries!)
      {
         if (!item.Chance.HasValue)
            break;

         current += item.Chance.Value;
         if (roll < current)
            return item.Value;
      }

      return _entries.Last().Value;
   }
}
