namespace Restaurant.Repos
{
    public abstract class Repositories<T>
    {
        public T Retrieve(int id, List<T> list)
        {
            foreach (T listItem in list)
            {
                //This code no matter what object finds the id value in it and returns that object.
                System.Reflection.PropertyInfo pi = listItem.GetType().GetProperty("Id");
                int itemId = (int)pi.GetValue(listItem, null);

                if (itemId == id)
                {
                    return listItem;
                }
            }
            return default(T);
        }

        public List<T> RetrieveAllFiltered(int id, List<T> list)
        {
            List<T> filteredList = new List<T>();

            foreach (T listItem in list)
            {

                System.Reflection.PropertyInfo pi = listItem.GetType().GetProperty("Id");
                int itemId = (int)pi.GetValue(listItem, null);

                if (itemId == id)
                {
                    filteredList.Add(listItem);
                }
            }
            return filteredList;
        }
    }
}
