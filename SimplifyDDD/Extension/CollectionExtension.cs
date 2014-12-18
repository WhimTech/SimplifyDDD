using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SimplifyDDD.Entity;

namespace SimplifyDDD.Extension
{
    public static class CollectionExtension
    {
        public static void UpdateCollection<T>(this ICollection<T> oldCollection, ICollection<T> newCollection) where T : IEntity
        {
            oldCollection = oldCollection == null ? new Collection<T>() : oldCollection;
            newCollection = newCollection == null ? new Collection<T>() : newCollection;
            var oldDictionary = oldCollection.ToDictionary(item => item.Id);
            var newDictionary = newCollection.ToDictionary(item => item.Id);
            var toRemoveKeys = oldDictionary.Keys
                .Where(ent => !newDictionary.Keys.Contains(ent)).ToList();
            var toAddKeys = newDictionary.Keys
                .Where(ent => !oldDictionary.Keys.Contains(ent)).ToList();
            foreach (var key in toRemoveKeys)
            {
                oldCollection.Remove(oldDictionary[key]);
            }
            foreach (var key in toAddKeys)
            {
                oldCollection.Add(newDictionary[key]);
            }
        }
    }
}
