predicate-extensions
====================

"All" and "Any" extension methods for predicates.
They allow to perform conjunction and disjunction of InvocationList in brief and easy way.


Samples
====================
accPredicate.All(x)

accPredicate.Any(x)

(predicate1 + predicate2).All(x)

All() and Any() are just null-safe shortcuts for 
accPredicate.GetInvocationList().OfType<Predicate<T>>().All(predicate => predicate(x))


====================
Can be usefull for filtering collections:

var xs = new []{1, 2, 3, 4, 5, 6, 7, 8, 9};

xs.Where((greaterThan5Predicate + evenPredicate).All) would be [6, 8]

xs.Where((greaterThan5Predicate + evenPredicate).Any) would be [2, 4, 6, 7, 8, 9]
