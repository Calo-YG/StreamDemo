// See https://aka.ms/new-console-template for more information
using System.Text;

Text();
 ReadText();

 List<string> GetText(int lines)
{
    List<string> text = new();
    for (var i = 0; i < 1000; i++)
    {
        text.Add($"我是第{i.ToString()},我的名字记叫文耀广{i.ToString()}");
    }
    return text;
}

void ToText(List<string> textlines,int index)
{
    // Set a variable to the Documents path.
    string docPath =
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    Console.WriteLine(docPath);

    // Write the string array to a new file named "WriteLines.txt".
    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"文耀广{(index+1).ToString()}.txt")))
    {
        foreach (string line in textlines)
            outputFile.WriteLine(line);
    }
}

void Text()
{ 
   for(var i = 0; i < 5; i++)
    {
        var lines = Random.Shared.Next(1000, 1099);
        ToText(GetText(lines), i);
    }
}

   void ReadText()
{
    string docPath =
      Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    MemoryStream ms = new MemoryStream();
    long total = 0;
    for (var i = 0; i < 5; i++)
    {
        using (StreamReader sr = new StreamReader(Path.Combine(docPath, $"文耀广{(i + 1).ToString()}.txt")))
        {
            total += sr.BaseStream.Length;
            char[] buffer = new char[0x1000];
            int numRead;
            while ((numRead =  sr.Read(buffer, 0, buffer.Length)) != 0)
            {
                byte[] bytes = new UTF8Encoding().GetBytes(buffer);
                ms.Write(bytes,0,bytes.Length);
            }

        }
    }
    using (StreamWriter DestinationWriter = File.CreateText(Path.Combine(docPath, $"文耀广--total.txt")))
    {
        var bytes = ms.GetBuffer();
        var charBuffer = Encoding.UTF8.GetChars(bytes);
        DestinationWriter.WriteLine(charBuffer);
    }
    Console.WriteLine($"ms:{ms.Length}---file-total:{total}");
}