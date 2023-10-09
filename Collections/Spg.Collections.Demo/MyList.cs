namespace Spg.Collections.Demo
{
    public class MyList<T> : List<T> where T : SchoolClass
    {
		public T? this[string roomNumber]
		{
			get 
			{
				return this.SingleOrDefault(x => x.RoomNumber == roomNumber);
			}
		}
    }
}
