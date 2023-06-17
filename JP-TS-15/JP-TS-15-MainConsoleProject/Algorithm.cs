namespace JP_TS_15_MainConsoleProject
{
    //Action --> იმახსოვრებს ისეთ ფუნქციას რომელიც აბრუნებს void_ს
    //Func --> იმახსოვრებს ისეთ ფუნქციას რომელსაც მისაღებ და დასაბრუნებელ პარამეტრებს ვურჩევთ ჩვენ
    //Predicate --> იმახსოვრებს ისეთ ფუნქციას რომელსაც მისაღებ პარამეტრებს ვურჩევთ ჩვენ, დასაბრუნებელი პარამეტრი ყოველითვის Boolean -ია

    public static class Algorithm
    {
        public static T[] Take<T>(this T[] vehicles, int quantity)
        {
            if (vehicles.Length <= quantity)
                throw new ArgumentOutOfRangeException("Insuficcinet data");

            T[] result = new T[quantity];
            for (int i = 0; i < quantity; i++)
            {
                result[i] = vehicles[i];
            }

            return result;
        }
        public static T[] OrderBy<T>(this T[] collection, Func<T, T, bool> comparer)
        {
            for (int i = 0; i < collection.Length - 1; i++)
            {
                for (int j = i + 1; j < collection.Length; j++)
                {
                    if (comparer(collection[j], collection[i]))
                    {
                        T temporary = collection[j];
                        collection[j] = collection[i];
                        collection[i] = temporary;
                    }
                }
            }

            return collection;
        }
        public static TResult[] MySelect<TSource, TResult>(this TSource[] source, Func<TSource, TResult> selector)
        {
            TResult[] result = new TResult[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = selector(source[i]);
            }

            return result;
        }
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }


        public static T MyFirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> comparer)
        {
            foreach (var item in collection)
            {
                if (comparer(item))
                {
                    return item;
                }
            }

            return default;
        }



        public static int FindIndex<T>(this T[] collection, Predicate<T> predicate)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (predicate(collection[i]))
                {
                    return i;
                }
            }

            return -1;
        }
        public static int FindLastIndex<T>(this T[] collection, Func<T, bool> predicate)
        {
            for (int i = collection.Length - 1; i >= 0; i--)
            {
                if (predicate(collection[i]))
                {
                    return i;
                }
            }
            return -1;
        }
        static List<T> Distinct<T>(this T[] mass)
        {
            List<T> result = new();
            for (int i = 0; i < mass.Length; i++)
            {
                bool notUnique = false;
                for (int j = 0; j < mass.Length; j++)
                {
                    if (mass[i].Equals(mass[j]) && i != j)
                    {
                        notUnique = true;
                        break;
                    }
                }

                if (!notUnique)
                {
                    result.Add(mass[i]);
                }
            }

            return result;
        }
        public static bool Any<T>(this T[] collection, Predicate<T> predicate)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (predicate(collection[i]))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool All<T>(this T[] collection, Predicate<T> predicate)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (!predicate(collection[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
