using System;
using System.Linq;

namespace PredicateExtensions
{
    public static class PredicateExtensions
    {
        public static bool All<T>(this Predicate<T> accPredicate, T x)
        {
            return accPredicate.GetInvocationList().OfType<Predicate<T>>().All(predicate => predicate(x));
        }

        public static bool Any<T>(this Predicate<T> accPredicate, T x)
        {
            return accPredicate.GetInvocationList().OfType<Predicate<T>>().Any(predicate => predicate(x));
        }

        public static bool None<T>(this Predicate<T> accPredicate, T x)
        {
            return !accPredicate.Any(x);
        }
    }
}
