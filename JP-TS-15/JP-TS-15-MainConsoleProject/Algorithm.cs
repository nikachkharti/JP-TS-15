namespace JP_TS_15_MainConsoleProject
{
    //Action --> იმახსოვრებს ისეთ ფუნქციას რომელიც აბრუნებს void_ს
    //Func --> იმახსოვრებს ისეთ ფუნქციას რომელსაც მისაღებ და დასაბრუნებელ პარამეტრებს ვურჩევთ ჩვენ
    //Predicate --> იმახსოვრებს ისეთ ფუნქციას რომელსაც მისაღებ პარამეტრებს ვურჩევთ ჩვენ, დასაბრუნებელი პარამეტრი ყოველითვის Boolean -ია

    public static class Algorithm
    {
        //დაწერეთ უნიკალური ელემენტების პოვნის ფუნქცია Distinct ჯენერიკად
        //დაწერეთ ფუნქცია სახელად Any რომელიც დააბრუნებს true თუ ლისტიდან ერთი ელემენტი მაინც აკმაყოფილებს გადაცემულ პირობას(ჯენერიკად)
        //დაწერეთ ფუნქცია სახელად All რომელიც დააბრუნებს true თუ ლისტიდან ყველა ელემენტი მაინც აკმაყოფილებს გადაცემულ პირობას(ჯენერიკად)

        public static T[] Take<T>(T[] vehicles, int quantity)
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
        public static T[] OrderBy<T>(T[] collection, Func<T, T, bool> comparer)
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
        public static TResult[] Select<TSource, TResult>(TSource[] source, Func<TSource, TResult> selector)
        {
            TResult[] result = new TResult[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = selector(source[i]);
            }

            return result;
        }
        public static List<T> FindAll<T>(T[] collection, Predicate<T> predicate)
        {
            List<T> result = new();

            for (int i = 0; i < collection.Length; i++)
            {
                if (predicate(collection[i]))
                {
                    result.Add(collection[i]);
                }
            }

            return result;
        }
        public static T FirstOrDefault<T>(T[] collection, Func<T, bool> comparer)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if (comparer(collection[i]))
                {
                    return collection[i];
                }
            }

            return default;
        }
        public static int FindIndex<T>(T[] collection, Predicate<T> predicate)
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
        public static int FindLastIndex<T>(T[] collection, Func<T, bool> predicate)
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
    }
}
