using System;
using System.IO;
using System.Linq;
using System.Text;
using Ude;

namespace enconding_converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            var rootPath = args[0];
            var destinationEncoding = args[1];
            var defaultEncoding = args[2];
            var fileExtensions = args[3];
            var considerFileExtensions = fileExtensions != "" ? true : false;
            
            Console.WriteLine();
            Console.WriteLine("#################");
            Console.WriteLine("# CONFIGURATION #");
            Console.WriteLine("#################");
            Console.WriteLine($"Root search path: \t\t{rootPath}");
            Console.WriteLine($"Destination encoding: \t\t{destinationEncoding}");
            Console.WriteLine($"Default encoding: \t\t{defaultEncoding}");
            Console.WriteLine($"Consider file extensions: \t{considerFileExtensions}");
            if (considerFileExtensions)
            {
                Console.WriteLine($"File extensions: \t\t{fileExtensions}");
            }
            
            Console.WriteLine();
            Console.WriteLine("##############");
            Console.WriteLine("# PROCESSING #");
            Console.WriteLine("##############");
            
            DirectoryInfo di = new DirectoryInfo(rootPath);
            
            foreach (var d in di.GetDirectories())
            {
                foreach (var f in d.GetFiles().Where(s => considerFileExtensions ? fileExtensions.Contains(s.Extension) : true ))
                {
                    Encoding encoding;
                    using (var reader = new StreamReader(f.FullName, Encoding.GetEncoding(defaultEncoding), true))
                    {
                        CharsetDetector detector = new CharsetDetector();
                        detector.Feed(reader.BaseStream);
                        detector.DataEnd();
                        
                        encoding = Encoding.GetEncoding(detector.Charset);
                        
                        Console.WriteLine($"{encoding.WebName} {detector.Confidence * 100}% | {f.Extension} | {f.Name.Replace(f.Extension,"")}");
                    }
                    
                    if (encoding.WebName != destinationEncoding)
                    {
                        var fBytes = File.ReadAllBytes(f.FullName);
                        var fBytesConverted = Encoding.Convert(encoding, Encoding.GetEncoding(destinationEncoding), fBytes);
                        File.WriteAllBytes(f.FullName, fBytesConverted);
                            
                        Console.WriteLine($"==> Converted into {destinationEncoding}");
                    }
                }
            }
        }
    }
}