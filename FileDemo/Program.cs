namespace FileDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StreamReader reader = null;

            try
            {
                reader = new StreamReader("../../../Files/data.txt");

                string lineFromFile = null;
                while ((lineFromFile = reader.ReadLine()) != null)
                {
                    Console.WriteLine(lineFromFile);
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("File reading error: " + error.Message);
            }
            finally
            {
                if(reader != null)
                {
                    reader.Close();
                }
            }


            // YOU TRY:
            // Open a StreamWriter with a new file: newData.txt inside the Files folder
            // Write any 3 lines of text to the file
            // Close the stream

            // 5 minutes, then 5 minute break!
            // Look back at resources from 105 if you can't remember :)

            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter("../../../Files/newData.txt");

                writer.WriteLine("Whatever");
                writer.WriteLine("Another line");
            }
            catch (Exception error)
            {
                Console.WriteLine("File writing error: " + error.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}