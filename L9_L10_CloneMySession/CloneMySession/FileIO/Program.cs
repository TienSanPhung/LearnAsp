namespace FileIO;

class Program
{
    static void Main(string[] args)
    {
        var path = "C:\\Users\\pts20\\Desktop\\.net\\ASP\\LearnAsp\\L9_L10_CloneMySession\\CloneMySession\\FileIO\\Alice";
       // Dir(path);
       string pathFile =
           @"C:\Users\pts20\Desktop\.net\ASP\LearnAsp\L9_L10_CloneMySession\CloneMySession\FileIO\Alice\TestFile.txt";
       ReadFile(pathFile);
       string pathDest =
           @"C:\Users\pts20\Desktop\.net\ASP\LearnAsp\L9_L10_CloneMySession\CloneMySession\FileIO\Alice\Client\TestFile-coppy.txt";
       usingFile(pathFile, pathDest);
       string pathFolder =
           @"C:\Users\pts20\Desktop\.net\ASP\LearnAsp\L9_L10_CloneMySession\CloneMySession\FileIO\Alice\Customer";
       string nameFile = "TestFolder";
         mkdir(pathFolder, nameFile);
    }
    public static void Dir(string path){
        var dir = new DirectoryInfo(path);
        var directory = dir.GetDirectories();
        foreach (var d in directory)
        {
            Console.WriteLine($@"{d.LastWriteTime:MM/dd/yyyy} {d.LastWriteTime:HH:mm} <DIR> {d.Name}");
        }
        var file = dir.GetFiles();
        foreach (var f in file)
        {
            Console.WriteLine($@"{f.LastWriteTime:MM/dd/yyyy} {f.LastWriteTime:HH:mm} {f.Length,8} {f.Name}");
        }
    }

    public static void ReadFile(string path)
    {
        var buffer = new byte[1024];
        var instream = File.OpenRead(path);
        int n = instream.Read(buffer,0,buffer.Length);
        while (n>0)
        {
            Console.WriteLine(n.ToString());
            n = instream.Read(buffer,0,buffer.Length);
        }
        instream.Close();
    }

    public static void usingFile(string pathSource, string pathDest)
    {
        var buffer = new byte[1024];
        using var instream = File.OpenRead(pathSource);
        using var outstream = File.OpenWrite(pathDest);
        int n = instream.Read(buffer,0,buffer.Length);
        while (n>0)
        {
            Console.WriteLine(n.ToString());
            outstream.Write(buffer,0,n);
            n = instream.Read(buffer,0,buffer.Length);
        }
        
    }

    public static void mkdir(string path, string nameFile)
    {
        string s = string.Join("\\", path, nameFile);
        if (!File.Exists(s))
        {
            var files = File.Create(s);
            
            files.Close();
        }
    }
}