namespace BrentAcsSoftware.Common.Leisure.Utilities;

public interface IRandomChanceTableEntry
{
   double? Chance { get; }
}

public interface IRandomChanceTable<T>
{
}

public abstract class RandomChanceTable<T> : IRandomChanceTable<T> where T : IRandomChanceTableEntry
{
   protected abstract List<T> RawEntries { get; }

   private IList<T>? _entries;
   private void ValidateEntries()
   {
      if (RawEntries is null)
         throw new Exception("RawEntries is null");
      if (_entries is not null)
         return;

      if(RawEntries.Count(e => e.Chance is null) > 1)
         throw new Exception("RawEntries contains multiple entries w/ defaulted chance (null).");
      
      _entries = RawEntries.OrderBy(i => i.Chance).ToList();
      if (_entries.FirstOrDefault()?.Chance is null)
      {
         var nullChanceEntry = _entries[ 0 ];
         _entries.RemoveAt(0);
         _entries.Add(nullChanceEntry);
      }
   }

   public T GetByChance(double roll)
   {
      ValidateEntries();
      double current = 0;

      foreach (var item in _entries!)
      {
         if (!item.Chance.HasValue)
            break;

         current += item.Chance.Value;
         if (roll < current)
            return item;
      }

      return _entries.Last();
   }
}
