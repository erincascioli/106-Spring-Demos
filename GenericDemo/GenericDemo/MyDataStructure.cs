using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
	/// <summary>
	/// A structure for holding some data (and mostly
	/// demoing generics)
	/// </summary>
	/// <typeparam name="T">The type of data to hold</typeparam>
	class MyDataStructure<T>
	{
		// Fields for the data we want to hold, and any
		// other important meta data
		private T[] data;
		private int count; // Count is always an int!

        // NOOOOOOOOOOOOOOOOOOOOO
        /*
        public T[] Data
        {
            get { return data; }
        }
        */

        // Indexer property
        public T this[int index]
        {
            get
            {
                // Error check here!  Make sure index is valid. If not, throw an exception.
                return data[index];
            }
            set
            {
                // Error check here!  Make sure index is valid. If not, throw an exception.
                data[index] = value;
            }
        }


		/// <summary>
		/// Gets the count of the list
		/// </summary>
		public int Count { get { return count; } }
		
		/// <summary>
		/// Creates a new data structure with an
		/// internal capacity of 4
		/// </summary>
		public MyDataStructure()
		{
			// Initialize the array
			data = new T[4];
            count = 0;
		}

        /// <summary>
        /// Fills the underlying array with default data of type T
        /// </summary>
        public void FillData()
        {
            // Fill the array with starting data
            for(int i = 0; i < 4; i++)
            {
                data[i] = default(T);
            }
        }

        /// <summary>
        /// This adds an item to the data structure,
        /// provided there is enough room.  If not,
        /// it'll probably blow up
        /// </summary>
        /// <param name="item">The thing to add to the structure</param>
        public void Add(T item)
		{
			// Error checking here would be nice!
			data[count] = item;
			count++;
		}

        /// <summary>
        /// Retrieves a specific index from this data structure
        /// </summary>
        /// <param name="index">Index of data to retrieve</param>
        /// <returns>The data at that index in the underlying array</returns>
        public T GetData(int index)
        {
            // Error check here!  Make sure index is valid. 
            return data[index];
        }
	}
}
